namespace Zaabee.Serializer.Abstraction
{
    public interface ITextSerializer
    {
        string SerializeToText<T>(T t);
        T DeserializeFromText<T>(T t);
    }
}