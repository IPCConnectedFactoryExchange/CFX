using CFX.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppendixNotesTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            txtVersion.Text = Properties.Settings.Default.cfxVersion;
        }


        public string GetChanges(string newVersion)
        {
            List<string> lines = new List<string>();

            Assembly assembly = Assembly.GetAssembly(typeof(CFX.CFXEnvelope));

            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttribute<CreatedVersionAttribute>(false)?.CreatedVersion == newVersion)
                {
                    if (type.IsEnum)
                        lines.Add($"New Enumeration:  {type.FullName}");
                    else
                        lines.Add($"New Class:  {type.FullName}");
                    continue;
                }

                foreach (PropertyInfo prop in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Where(p => p.GetCustomAttribute<CreatedVersionAttribute>()?.CreatedVersion == newVersion))
                {
                    lines.Add($"New Property:  {type.FullName} :: {prop.Name}");
                }

                if (type.IsEnum)
                {
                    foreach (MemberInfo mi in type.GetMembers().Where(mi => mi.GetCustomAttribute<CreatedVersionAttribute>()?.CreatedVersion == newVersion))
                    {
                        lines.Add($"New Enum Value:  {type.FullName} :: {mi.Name}");
                    }
                }
            }

            lines.Sort();
            StringBuilder report = new StringBuilder();
            lines.ForEach(l => report.AppendLine(l));

            System.Diagnostics.Debug.WriteLine(report.ToString());
            System.Windows.Forms.Clipboard.SetText(report.ToString());
            return report.ToString();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var result = GetChanges(txtVersion.Text);
            txtResults.Text = result;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.cfxVersion = txtVersion.Text;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            txtResults.Width = this.Width - 52;
            txtResults.Height = this.Height - 120;
        }
    }
}
