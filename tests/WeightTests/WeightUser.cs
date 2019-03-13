using System;
using System.Collections.Generic;
using System.Text;
using Weights;

namespace WeightTests {
    
    class WeightUser {
        
        [Weight(Constants.WeightUser.Distance, nameof(Constants.WeightUser.Distance))]
        public double Distance { get; set; }
        [Weight(Constants.WeightUser.Time, nameof(Constants.WeightUser.Time))]
        public int Time { get; set; }
        [Weight(Constants.WeightUser.Coins, nameof(Constants.WeightUser.Coins))]
        public int Coins { get; set; }
    }
}
