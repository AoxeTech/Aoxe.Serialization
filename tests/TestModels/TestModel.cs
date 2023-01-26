namespace TestModels;

[MessagePackObject]
[Serializable]
[ProtoContract]
[ZeroFormattable]
public class TestModel
{
    [Key(0)] [ProtoMember(1)] [Index(0)] public virtual Guid Id { get; set; }
    [Key(1)] [ProtoMember(2)] [Index(1)] public virtual int Age { get; set; }
    [Key(2)] [ProtoMember(3)] [Index(2)] public virtual string? Name { get; set; }
    [Key(3)] [ProtoMember(4)] [Index(3)] public virtual Gender Gender { get; set; }
}