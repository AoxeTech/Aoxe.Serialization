using System;
using ProtoBuf;

namespace Benchmark
{
    [Serializable]
    [ProtoContract]
    public class TestModel
    {
        [ProtoMember(1)] public virtual Guid Id { get; set; }
        [ProtoMember(2)] public virtual int Age { get; set; }
        [ProtoMember(3)] public virtual string Name { get; set; }
        [ProtoMember(4)] public virtual DateTime CreateTime { get; set; }
        [ProtoMember(5)] public virtual Gender Gender { get; set; }
    }
}