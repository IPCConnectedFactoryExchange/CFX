using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CFX;
using NJsonSchema;

namespace CFXExampleEndpoint
{
    internal class SchemaGenerator
    {
        public void GenerateSchemas(string outputPath)
        {
            string folder = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(folder)) throw new ArgumentException("outputPath is not valid");

            var assy = Assembly.GetAssembly(typeof(CFXMessage));
            List<Type> types = new List<Type>(assy.GetTypes());

            foreach (Type type in types.Where(t => t.BaseType == typeof(CFXMessage)))
            {
                var schema = JsonSchema.FromType(type);
                var schemaJson = schema.ToJson();
                using (StreamWriter writer = new StreamWriter($"{outputPath}\\{type.FullName}.schema.json"))
                {
                    writer.Write(schemaJson);
                }
            }

        }
    }
}
