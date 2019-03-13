namespace Weights {
    public class Swim : Activity {
        [Weight(60)]
        public double Laps { get; set; }
        public override Discriminator Kind =>Discriminator.Swim;
    }
}