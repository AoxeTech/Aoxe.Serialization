using System;
using ProtoBuf;

namespace ZaabeeProtobufTestProject
{
    [ProtoContract]
    public class TestModel<T>
    {
        [ProtoMember(1)]
        public T Id { get; set; }
        [ProtoMember(2)]
        public int Age { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(4)]
        public DateTime CreateTime { get; set; }
        [ProtoMember(5)]
        public Gender Gender { get; set; }
    }
}