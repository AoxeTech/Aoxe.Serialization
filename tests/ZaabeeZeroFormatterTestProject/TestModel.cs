using System;
using ZeroFormatter;

namespace ZaabeeZeroFormatterTestProject
{
    [ZeroFormattable]
    public class TestModel
    {
        [Index(0)]
        public virtual Guid Id { get; set; }
        [Index(1)]
        public virtual int Age { get; set; }
        [Index(2)]
        public virtual string Name { get; set; }
        [Index(3)]
        public virtual DateTime CreateTime { get; set; }
        [Index(4)]
        public virtual Gender Gender { get; set; }
    }
}