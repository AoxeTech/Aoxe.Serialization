namespace TestModels;

#if !NETSTANDARD2_0
[MemoryPackable]
#endif
[MessagePackObject]
[Serializable]
[ProtoContract]
[ZeroFormattable]
public partial class TestModel
{
    [Key(0)] [ProtoMember(1)] [Index(0)] public virtual int Id { get; set; }
    [Key(1)] [ProtoMember(2)] [Index(1)] public virtual int Age { get; set; }
    [Key(2)] [ProtoMember(3)] [Index(2)] public virtual string? Name { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not TestModel target) return false;
        return Id == target.Id && Age == target.Age && Name == target.Name;
    }

    protected bool Equals(TestModel other) =>
        Id == other.Id && Age == other.Age && Name == other.Name;

#if !NETSTANDARD2_0
    public override int GetHashCode() =>
        HashCode.Combine(Id, Age, Name);
#endif
}