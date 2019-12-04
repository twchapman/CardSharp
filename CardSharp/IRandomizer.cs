namespace CardSharp {
    public interface IRandomizer<T> {
        T Next(int max);
    }
}