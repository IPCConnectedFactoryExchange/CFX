using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Transport
{
    internal class AmqpCFXLink
    {
        public Uri Uri
        {
            get;
            set;
        }

        public AmqpCFXLinkType LinkType
        {
            get;
            set;
        }

        public Amqp.AmqpObject Link
        {
            get;
            set;
        }

    }

    internal enum AmqpCFXLinkType
    {
        Sender,
        Receiver
    }
}
