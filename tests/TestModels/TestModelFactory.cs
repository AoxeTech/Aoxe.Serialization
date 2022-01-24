using System;

namespace TestModels;

public static class TestModelFactory
{
    public static TestModel Create() => new()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = new DateTime(2000, 1, 1),
        Name = "apple",
        Gender = Gender.Female
    };
}