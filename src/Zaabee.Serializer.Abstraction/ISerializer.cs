namespace Zaabee.Serializer.Abstraction
{
    public interface ISerializer : IBytesSerializer, IStreamSerializer, IStringSerializer
    {
        string BytesToString(byte[] bytes);
        byte[] StringToBytes(string text);
    }
}