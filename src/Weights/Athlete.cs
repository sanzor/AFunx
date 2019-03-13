using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weights {
    public class Athlete {
        public string Name { get; set; }
        public double Age { get; set; }
        [JsonProperty]
        public Activity Activity { get; set; }
    }
}
