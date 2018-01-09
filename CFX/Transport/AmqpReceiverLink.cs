using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using CFX.Utilities;

namespace CFX.Transport
{
    internal class AmqpReceiverLink : AmqpLink, IDisposable
    {
        public AmqpReceiverLink(string address) : base(address)
        {
            LinkType = LinkType.Receiver;
        }

        private int linkCredit = 300;

        public ReceiverLink ReceiverLink
        {
            get
            {
                return Link as ReceiverLink;
            }
            set
            {
                Link = value;
            }
        }

        public override bool CreateLink(Session session, MessageCallback callback)
        {
            if (!base.CreateLink(session)) return false;

            ReceiverLink receiver = null;

            Task.Run(() =>
            {
                try
                {
                    Amqp.Framing.Source s = new Amqp.Framing.Source()
                    {
                        Address = this.Address,
                        Durable = AmqpCFXEndpoint.DurableReceiverSetting.Value
                    };

                    receiver = new ReceiverLink(session, Address, s, null);
                    receiver.Start(linkCredit, callback);
                }
                catch (Exception ex)
                {
                    AppLog.Error(ex);
                    receiver = null;
                }
            }).Wait();

            ReceiverLink = receiver;
            return true;
        }
    }
}
