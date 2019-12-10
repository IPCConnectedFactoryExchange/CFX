using System;

namespace CFX.Production
{
    internal class CFX_VersionAttribute : Attribute
    {
        private string versionIdentifier;

        public CFX_VersionAttribute(string versionIdentifier)
        {
            this.versionIdentifier = versionIdentifier;
        }
    }
}