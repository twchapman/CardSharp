namespace CardSharp {
    public class Shuffler {
        private readonly IRandomizer<int> randomizer;

        public Shuffler(IRandomizer<int> randomizer) {
            this.randomizer = randomizer;
        }

        public void FisherYates<T>(Deck<T> deck) {
            for (int current = 0; current < deck.Count - 1; current++) {
                int swapTo = current + randomizer.Next(deck.Count - current);
                deck.Swap(current, swapTo);
            }
        }
    }
}
