namespace Zaabee.Serializer.Types.UnitTest.Models;

#if !NET48
[MemoryPackable]
#endif
[MessagePackObject]
[Serializable]
[ProtoContract]
[ZeroFormattable]
public partial class TupleModel
{
    [Key(0)] [ProtoMember(1)] [Index(0)] public virtual Tuple<string, string> Tuple { get; set; }
    [Key(1)] [ProtoMember(2)] [Index(1)] public virtual List<Tuple<string, string>> Tuples { get; set; } = new();

    public static TupleModel Instance() => new();
}