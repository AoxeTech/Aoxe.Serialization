using System;
using ProtoBuf;

namespace UnitTest
{
    public class TestModel<T>
    {
        public T Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public Gender Gender { get; set; }
    }
}