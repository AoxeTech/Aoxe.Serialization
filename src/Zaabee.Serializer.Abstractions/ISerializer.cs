namespace Zaabee.Serializer.Abstractions
{
    public interface ISerializer : IBytesSerializer, IStreamSerializer, IStringSerializer
    {
        string BytesToString(byte[] bytes);
        byte[] StringToBytes(string text);
    }
}