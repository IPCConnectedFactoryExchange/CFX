using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class InstalledComponent
    {
        public InstalledComponent(bool setDateTime = false)
        {
            if (setDateTime) InstallationTime = DateTime.Now;
        }

        public string ReferenceDesignator
        {
            get;
            set;
        }

        public DateTime? InstallationTime
        {
            get;
            set;
        }
    }
}
