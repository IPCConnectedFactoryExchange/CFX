using System;
using System.Data.SqlClient;
using CFX;
using CFX.Transport;

namespace CFXExampleEndpoint
{
    public class MessageDBWriter
    {
        private AmqpCFXEndpoint endpoint = null;

        public void EstablishBrokerSubscription()
        {
            string myCFXHandle = "Vendor1.Model1.Machine1234";
            string myBrokerUri = "amqp://mybroker:5672";
            string myBrokerQueue = "/queue/EventQueue1";

            endpoint = new AmqpCFXEndpoint();
            endpoint.OnCFXMessageReceived += Endpoint_OnCFXMessageReceived;
            endpoint.Open(myCFXHandle);
            endpoint.AddSubscribeChannel(new Uri(myBrokerUri), myBrokerQueue);
        }

        public void CloseBrokerSubscription()
        {
            if (endpoint != null)
            {
                endpoint.Close();
                endpoint = null;
            }
        }

        private void Endpoint_OnCFXMessageReceived(AmqpChannelAddress source, CFXEnvelope message)
        {
            WriteMessage(message);
        }

        public void WriteMessage(CFXEnvelope cfxMessage)
        {
            string connectionString = @"Data Source=aishqcfx01v\sqlexpress;Initial Catalog=CFXDemo;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection( connectionString))
            {
                string json = cfxMessage.ToJson().Replace("'", "''");

                string sql = string.Format("INSERT INTO CFXMessages (CFXHandle, TimeStamp, MessageName, MessageData) VALUES('{0}','{1}','{2}','{3}')",
                cfxMessage.Source, cfxMessage.TimeStamp.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fff"), cfxMessage.MessageName, json);

                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
