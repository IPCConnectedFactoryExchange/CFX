using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class RequestResult
    {
        public RequestResult() { }

        public StatusResult Result
        {
            get;
            set;
        }

        public int ResultCode
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}
