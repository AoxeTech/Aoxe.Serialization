using System;

namespace Zaabee.SystemTextJson.UnitTest.Models
{
    public class TestModel
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public Gender Gender { get; set; }
    }
}