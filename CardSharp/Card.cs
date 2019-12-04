namespace CardSharp {
    public class Card<T> {
        public Card() { }
        public Card(T data) {
            Data = data;
        }

        public T Data { get; set; }
    }
}
