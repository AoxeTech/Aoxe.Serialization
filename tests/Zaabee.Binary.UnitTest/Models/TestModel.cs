﻿using System;

namespace Zaabee.Binary.UnitTest.Models
{
    [Serializable]
    public class TestModel
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public Gender Gender { get; set; }
    }
}