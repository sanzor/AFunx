using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace Weights {
    [AttributeUsage(AttributeTargets.Property)]
    public class WeightAttribute : Attribute {
        public WeightAttribute(double val,[CallerMemberName]string Name=null) {
            this.Weight = new Weight(Name, val);
        }
        public Weight Weight { get; set; }
    }
}
