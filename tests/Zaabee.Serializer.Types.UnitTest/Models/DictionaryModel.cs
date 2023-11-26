namespace Zaabee.Serializer.Types.UnitTest.Models;

#if !NET48
[MemoryPackable]
#endif
[MessagePackObject]
[Serializable]
[ProtoContract]
[ZeroFormattable]
public partial class DictionaryModel
{
    [Key(0)][ProtoMember(1)][Index(0)] public virtual Dictionary<string, string> Dictionary { get; set; } = new();

    public static DictionaryModel Instance() => new();
}