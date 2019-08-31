using System;
using ProtoBuf;
using ZeroFormatter;

namespace Benchmark
{
    [Serializable]
    [ProtoContract]
    [ZeroFormattable]
    public class TestModel
    {
        [ProtoMember(1)] [Index(0)] public virtual Guid Id { get; set; }
        [ProtoMember(2)] [Index(1)] public virtual int Age { get; set; }
        [ProtoMember(3)] [Index(2)] public virtual string Name { get; set; }
        [ProtoMember(4)] [Index(3)] public virtual DateTime CreateTime { get; set; }
        [ProtoMember(5)] [Index(4)] public virtual Gender Gender { get; set; }
    }
}