namespace Zaabee.Serializer.Types.UnitTest.Models;

#if !NET48
[MemoryPackable]
#endif
[MessagePackObject]
[Serializable]
[ProtoContract]
[ZeroFormattable]
public partial class GuidModel
{
    [Key(0)] [ProtoMember(1)] [Index(0)] public virtual Guid Id { get; set; } = Guid.NewGuid();
    public static GuidModel Instance() => new();
}