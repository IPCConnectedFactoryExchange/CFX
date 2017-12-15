using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    public class GetLoadedMaterialsResponse : CFXMessage
    {
        public GetLoadedMaterialsResponse()
        {
            Materials = new List<MaterialLocation>();
        }

        public RequestResult Result
        {
            get;
            set;
        }

        public List<MaterialLocation> Materials
        {
            get;
            set;
        }
    }
}
