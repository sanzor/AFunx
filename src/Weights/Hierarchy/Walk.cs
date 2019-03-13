namespace Weights {
    public class Walk : Activity {
        [Weight(16.33)]
        public double Pace { get; set; }
        public override Discriminator Kind => Discriminator.Walk;
    }
}