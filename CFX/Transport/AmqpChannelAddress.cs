using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Transport
{
    /// <summary>
    /// Represetns and AMQP source or target, comprised of a network address, and an AMQP source or target address.
    /// (eg.  amqps://user1:password1@myamqpbroker.company1.com, amqp://broker3.company1.com, etc.)
    /// </summary>
    public class AmqpChannelAddress
    {
        /// <summary>
        /// The network address of the AMQP source or target.  May include user and port information in
        /// standard Uri format. (eg.  amqps://user1:password1@myamqpbroker.company1.com, amqp://broker3.company1.com, 
        /// amqps://myamqpbroker.company1.com:8856, etc.).
        /// </summary>
        public Uri Uri
        {
            get;
            set;
        }

        /// <summary>
        /// The AMQP 1.0 source or target address (eg.  /exchange/exchange1, /queue/queue1, etc.)
        /// </summary>
        public string Address
        {
            get;
            set;
        }
    }
}
