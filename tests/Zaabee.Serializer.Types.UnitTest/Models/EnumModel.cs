namespace Zaabee.Serializer.Types.UnitTest.Models;

#if !NET48
[MemoryPackable]
#endif
[MessagePackObject]
[Serializable]
[ProtoContract]
[ZeroFormattable]
public partial class EnumModel
{
    [Key(0)] [ProtoMember(1)] [Index(0)] public virtual Color Color { get; set; }
    public static EnumModel Instance() => new();
}

public enum Color
{
    Red,
    Green,
    Blue
}