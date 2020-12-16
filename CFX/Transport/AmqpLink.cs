using System;
using System.Collections.Generic;
using System.Text;
using Amqp;

namespace CFX.Transport
{
    internal abstract class AmqpLink
    {
        public AmqpLink(string address)
        {
            Address = address;
        }

        public Session Session
        {
            get;
            set;
        }

        public AmqpObject Link
        {
            get;
            protected set;
        }

        public bool IsClosed
        {
            get
            {
                if (Link == null) return true;
                return Link.IsClosed;
            }
        }

        public string Address
        {
            get;
            set;
        }

        public LinkType LinkType
        {
            get;
            protected set;
        }

        public virtual void Dispose()
        {
            if (Link != null)
            {
                if (!Link.IsClosed) Link.Close();
                Link = null;
            }
        }

        public virtual void CloseLink()
        {
            if (Link != null && !Link.IsClosed) Link.Close();
            Link = null;
        }

        public virtual bool CreateLink(Session session)
        {
            Link = null;
            if (session.IsClosed || session.Connection.IsClosed) return false;
            return true;
        }

        public virtual bool CreateLink(Session session, MessageCallback callback)
        {
            return CreateLink(session);
        }
    }

    /// <summary>
    /// An enumeration indicating the type of link
    /// </summary>
    internal enum LinkType
    {
        /// <summary>
        /// Sender link
        /// </summary>
        Sender,
        /// <summary>
        /// Receiver link
        /// </summary>
        Receiver
    }
}
