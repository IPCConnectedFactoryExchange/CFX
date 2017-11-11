using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.DataObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Materials
{
    public class MaterialsLoaded : CFXMessage
    {
        public MaterialsLoaded() : base()
        {
            MaterialLocations = new List<MaterialLocation>();
        }

        public List<MaterialLocation> MaterialLocations
        {
            get;
            protected set;
        }
    }
}
