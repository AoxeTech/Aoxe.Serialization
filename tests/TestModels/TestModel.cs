﻿namespace TestModels;

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
    [Key(3)] [ProtoMember(4)] [Index(3)] public virtual Gender Gender { get; set; }
}