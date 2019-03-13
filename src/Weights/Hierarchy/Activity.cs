using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JsonSubTypes;

namespace Weights {
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubType(typeof(Run),Discriminator.Run)]
    [JsonSubtypes.KnownSubType(typeof(Walk), Discriminator.Walk)]
    [JsonSubtypes.KnownSubType(typeof(Swim), Discriminator.Swim)]
    public abstract class Activity {
        public enum Discriminator {
            Run=0,
            Walk=1,
            Swim=2
        }
        public abstract Discriminator Kind { get; } 
    }

   
}
