using System;
using System.Collections.Generic;
using System.Text;

namespace Weights {
    public class Weight {
        public string Name { get; set; }
        public double Value { get; set; }
        public Weight(string Name,double Value) {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
