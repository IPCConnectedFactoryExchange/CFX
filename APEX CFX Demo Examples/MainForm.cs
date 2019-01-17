using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CFX;
using CFX.Transport;
using CFX.ResourcePerformance;
using CFX.InformationSystem.UnitValidation;
using CFX.Structures;

namespace APEX_CFX_Demo_Examples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private AmqpCFXEndpoint MyEndpoint
        {
            get;
            set;
        }

        private string MyCFXHandle
        {
            get
            {
                return txtMyHandle.Text;
            }
            set
            {
                txtMyHandle.Text = value;
            }
        }

        private bool IsOpen
        {
            get
            {
                if (MyEndpoint == null) return false;
                return MyEndpoint.IsOpen;
            }
        }

        private Uri CFXDemoEventBroker
        {
            get
            {
                return new Uri("amqp://cfxbroker.connectedfactoryexchange.com");
            }
        }

        private string CFXDemoEventBrokerExchange
        {
            get
            {
                return "/exchange/AegisCloud";
            }

        }

        private string FactoryLogixMESEndpointUri
        {
            get
            {
                return "amqp://factorylogix.connectedfactoryexchange.com";
            }
        }

        private string FactoryLogixMESEndpointHandle
        {
            get
            {
                return "Aegis.FactoryLogix";
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtMyHandle.Text = APEX_CFX_Demo_Examples.Properties.Settings.Default.MyCFXHandle;
            LastState = (ResourceState)APEX_CFX_Demo_Examples.Properties.Settings.Default.LastState;
            LastStateChange = APEX_CFX_Demo_Examples.Properties.Settings.Default.LastStateChange;

            RefreshUI();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            APEX_CFX_Demo_Examples.Properties.Settings.Default.MyCFXHandle = txtMyHandle.Text;
            APEX_CFX_Demo_Examples.Properties.Settings.Default.LastState = (int)LastState;
            APEX_CFX_Demo_Examples.Properties.Settings.Default.LastStateChange = LastStateChange;
            APEX_CFX_Demo_Examples.Properties.Settings.Default.Save();

            CloseEndpoint();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenEndpoint();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseEndpoint();
        }

        private void btnPublishStateChange_Click(object sender, EventArgs e)
        {
            SendStateChange();
        }

        private void btnMakeValidateRequest_Click(object sender, EventArgs e)
        {
            SendValidationRequest();
        }

        private void OpenEndpoint()
        {
            CloseEndpoint();    // Just in case already open

            // Initialize Diagnostic Logging (messages will appear in Debug Output Window)
            // You can also use write diagnostic messages to a file by specifying the
            // CFX.Utilities.AppLog.LogFilePath property.  Set to the full path and filename
            // of your log file (folder must already exist).
            CFX.Utilities.AppLog.LoggingEnabled = true;
            CFX.Utilities.AppLog.AmqpTraceEnabled = true;
            CFX.Utilities.AppLog.LoggingLevel = CFX.Utilities.LogMessageType.Debug
                                                | CFX.Utilities.LogMessageType.Error
                                                | CFX.Utilities.LogMessageType.Info 
                                                | CFX.Utilities.LogMessageType.Warn;

            // Create endpoint, and initialize with you CFX handle.
            // Endpoints DO NOT need to receive and process requests for the show, 
            // they only need to MAKE requests.  So, no need to specify request processor.
            MyEndpoint = new AmqpCFXEndpoint();
            MyEndpoint.Open(MyCFXHandle);

            // Test to make sure you have connectivity to the CFX Demo broker.
            Exception ex = null;
            if (!MyEndpoint.TestPublishChannel(CFXDemoEventBroker, CFXDemoEventBrokerExchange, out ex))
            {
                // Problem connecting.
                AddToResults($"ERROR:  Unable to connect to broker {CFXDemoEventBroker} Exchange {CFXDemoEventBrokerExchange}\nERROR MESSAGE:  {ex.Message}");
                CloseEndpoint();
                return;
            }
            else
            {
                AddToResults("CONNECTION TO BROKER SUCCESSFUL");
            }

            // Add a publish channel to the CFX Demo broker.  All "Event" type messages
            // will be published to this channel
            MyEndpoint.AddPublishChannel(new Uri("amqp://cfxbroker.connectedfactoryexchange.com"), "/exchange/AegisCloud");

            // Set request timeout to 30 seconds
            AmqpCFXEndpoint.RequestTimeout = TimeSpan.FromSeconds(30);

            // Update buttons
            RefreshUI();
        }

        private void CloseEndpoint()
        {
            if (MyEndpoint != null)
            {
                MyEndpoint.Close();
                MyEndpoint = null;
            }

            RefreshUI();
        }

        private DateTime LastStateChange;
        private ResourceState LastState = ResourceState.PRD;

        private void SendStateChange()
        {
            if (!IsOpen) return;

            TimeSpan duration = TimeSpan.FromSeconds(1);
            if (LastStateChange != DateTime.MinValue)
            {
                duration = LastStateChange - DateTime.Now;
                LastStateChange = DateTime.Now;
            }

            ResourceState oldState = LastState;
            ResourceState newState = ResourceState.USD;

            if (oldState == ResourceState.USD)
                newState = ResourceState.PRD;
            else
                newState = ResourceState.USD;

            LastState = newState;

            // Create a CFXEnvelope containing a new StationStateChanged message            
            CFXEnvelope env = new CFXEnvelope(new StationStateChanged()
            {
                OldState = oldState,
                NewState = newState,
                OldStateDuration = duration,
            });

            // Publish the message.
            MyEndpoint.Publish(env);

            AddToResults($"MESSAGE PUBLISHED:\n {env.ToJson(true)}");
        }

        private void SendValidationRequest()
        {
            if (!IsOpen) return;

            // Create a request to ask the MES system (FactoryLogix) to validate a production unit (given its barcode)
            // Specify UnitRouteValidation (unit is at the correct step in the overall process)
            // and UnitStatusValidation (unit has not been failed, and is ok to be processed).
            // Unit with barcode TESTUNIT1000 has been initialized in FactoryLogix at the laser marker, but has not
            // yet been processed at stencil printer, etc.  So, it will fail if validated at any station other than
            // the stencil printer (the next step is stencil printing).
            CFXEnvelope env = new CFXEnvelope()
            {
                Source = MyEndpoint.CFXHandle,
                Target = FactoryLogixMESEndpointHandle,
                MessageBody = new ValidateUnitsRequest()
                {
                    PrimaryIdentifier = "TESTUNIT1000",
                    Validations = new List<ValidationType>(new ValidationType []
                    {
                        ValidationType.UnitRouteValidation,
                        ValidationType.UnitStatusValidation
                    })
                }
            };

            // BE SURE to specify yourself as the Source, and also
            // to specify the FactoryLogix CFX handle as the Target.
            env.Source = MyCFXHandle;
            env.Target = FactoryLogixMESEndpointHandle;

            MakeRequest(env);

            // Create a second request to ask the MES system (FactoryLogix) to validate
            // a different barcode.  This barcode has already been successfully processed
            // through the whole SMT line, so it will pass validation as any station in SMT.
            env = new CFXEnvelope()
            {
                Source = MyEndpoint.CFXHandle,
                Target = FactoryLogixMESEndpointHandle,
                MessageBody = new ValidateUnitsRequest()
                {
                    PrimaryIdentifier = "TESTUNIT1001",
                    Validations = new List<ValidationType>(new ValidationType[]
                    {
                        ValidationType.UnitRouteValidation,
                        ValidationType.UnitStatusValidation
                    })
                }
            };

            // BE SURE to specify yourself as the Source, and also
            // to specify the FactoryLogix CFX handle as the Target.
            env.Source = MyCFXHandle;
            env.Target = FactoryLogixMESEndpointHandle;

            MakeRequest(env);
        }

        private void MakeRequest(CFXEnvelope env)
        {
            CFXEnvelope response = null;

            try
            {
                response = MyEndpoint.ExecuteRequest(FactoryLogixMESEndpointUri, env);
            }
            catch (Exception ex)
            {
                AddToResults($"ERROR OCCURRED MAKING REQUEST TO {FactoryLogixMESEndpointUri}, handle {FactoryLogixMESEndpointHandle}.\nERROR MESSAGE:  {ex.Message} \n{ex.StackTrace}");
            }

            if (response.MessageBody is NotSupportedResponse)
            {
                NotSupportedResponse r = response.MessageBody as NotSupportedResponse;
                AddToResults($"NOT SUPPORTED RESPONSE: {r.RequestResult.ResultCode.ToString()}.\n{r.RequestResult.Message}");
            }
            else if (response.MessageBody is ValidateUnitsResponse)
            {
                ValidateUnitsResponse r = response.MessageBody as ValidateUnitsResponse;
                if (r.Result.Result != StatusResult.Success)
                    AddToResults($"ERROR OCCURRED PROCESSING VALIDATATION REQUEST: {r.PrimaryResult.Result.ToString()}.\n{r.PrimaryResult.Message}");
                else
                    AddToResults($"VALIDATATION RESULT RECEIVED: {r.PrimaryResult.Result.ToString()}.\n{r.PrimaryResult.Message}");
            }
            else
            {
                AddToResults($"UNEXPLAINED RESPONSE:  {response.MessageName}\n{response.ToJson(true)}");
            }
        }

        private void RefreshUI()
        {
            if (MyEndpoint != null)
            {
                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                btnPublishStateChange.Enabled = true;
                btnMakeValidateRequest.Enabled = true;
            }
            else
            {
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                btnPublishStateChange.Enabled = false;
                btnMakeValidateRequest.Enabled = false;
            }
        }

        private void AddToResults(string message)
        {
            List<string> messages = message.Split('\n').ToList();
            lstResults.Items.AddRange(messages.ToArray());
            int visibleItems = lstResults.ClientSize.Height / lstResults.ItemHeight;
            lstResults.TopIndex = Math.Max(lstResults.Items.Count - visibleItems + 1, 0);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Join("\r\n", lstResults.Items.OfType<string>().ToArray()));
        }
    }
}
