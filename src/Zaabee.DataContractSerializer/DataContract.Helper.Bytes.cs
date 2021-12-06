namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    public static byte[] Serialize<TValue>(TValue value) =>
        DataContractSerializer.Serialize(value);
        
    public static byte[] Serialize(Type type, object? value) =>
        value is null ? Array.Empty<byte>() : DataContractSerializer.Serialize(type, value);
        
    public static TValue? Deserialize<TValue>(byte[] bytes) =>
        bytes.IsNullOrEmpty() ? default : DataContractSerializer.Deserialize<TValue>(bytes);
        
    public static object? Deserialize(Type type, byte[] bytes) =>
        bytes.IsNullOrEmpty() ? default : DataContractSerializer.Deserialize(type, bytes);
}