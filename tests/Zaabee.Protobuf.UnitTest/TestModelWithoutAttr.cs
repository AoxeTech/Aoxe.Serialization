using System;
using System.Collections.Generic;

namespace Zaabee.Protobuf.UnitTest
{
    public class TestModelWithoutAttr
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public Gender Gender { get; set; }
        public Dictionary<Guid, TestModelWithoutAttr> Kids { get; set; }
    }

    public class TestSubModelWithoutAttr : TestModelWithoutAttr
    {
        public long LongId { get; set; }
    }
}