namespace Benchmark;

public static class TestModelFactory
{
    public static TestModel Create() =>
        new()
        {
            Id = new Random().Next(0, 100),
            Age = new Random().Next(0, 100),
            Name = "apple"
        };
}