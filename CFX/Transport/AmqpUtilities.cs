using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amqp;

namespace CFX.Transport
{
    public static class AmqpUtilities
    {
        public static Message MessageFromEnvelope(CFXEnvelope env)
        {
            Message msg = new Message(env.ToBytes());
            msg.Properties = new Amqp.Framing.Properties
            {
                MessageId = env.UniqueID.ToString(),
                CreationTime = env.TimeStamp
            };

            return msg;
        }

        public static CFXEnvelope EnvelopeFromMessage(Message msg)
        {
            if (msg.Body is byte[]) return CFXEnvelope.FromBytes((byte[])msg.Body);

            throw new ArgumentException("AMQP Message Body does not contain a valid CFX Envelope");
        }
    }
}
