namespace Weights {

    public class Run : Activity {
        [Weight(6.55)]
        public double Distance { get; set; }
        public override Discriminator Kind => Discriminator.Run;
    }
}