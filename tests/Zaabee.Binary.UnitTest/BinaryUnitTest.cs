using System;
using Zaabee.Binary.UnitTest.Models;

namespace Zaabee.Binary.UnitTest
{
    public partial class BinaryUnitTest
    {
        private static TestModel GetTestModel() =>
            new()
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1).ToUniversalTime(),
                Name = "apple",
                Gender = Gender.Female
            };
    }
}