using System;

namespace CardSharp {
    public class Shuffler {
        private readonly IRandomizer<int> randomizer;

        public Shuffler(IRandomizer<int> randomizer) {
            this.randomizer = randomizer;
        }

        public Deck<T> FisherYates<T>(Deck<T> deck) {
            Deck<T> shuffledDeck = new Deck<T>(deck);
            for (int i = deck.Count - 1; i > 1;  i--) {
                int swapIndex = randomizer.Next();
                shuffledDeck.Swap(i, swapIndex);
            }
            return shuffledDeck;
        }
    }
}
