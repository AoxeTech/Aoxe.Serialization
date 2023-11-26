namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    private static readonly ConcurrentDictionary<
        Type,
        System.Runtime.Serialization.DataContractSerializer
    > SerializerCache = new();

    private static System.Runtime.Serialization.DataContractSerializer GetSerializer(Type type) =>
        SerializerCache.GetOrAdd(
            type,
            new System.Runtime.Serialization.DataContractSerializer(type)
        );
}
