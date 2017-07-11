using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX
{
    public class Measurement
    {
        public Measurement()
        {
        }

        public Measurement(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public string Units
        {
            get;
            set;
        }

        public DateTime? SampleTime
        {
            get;
            set;
        }

        public double MeasuredValue
        {
            get;
            set;
        }

        public double NominalValue
        {
            get;
            set;
        }

        public double MinimumValue
        {
            get;
            set;
        }

        public double MaximumValue
        {
            get;
            set;
        }
    }
}
