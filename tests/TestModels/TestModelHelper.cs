namespace TestModels;

public static class TestModelHelper
{
    public static TestModel Create() => new()
    {
        Id = new Random().Next(0, 100),
        Age = new Random().Next(0, 100),
        Name = "apple"
    };

    public static List<TestModel> Create(int quantity) =>
        quantity.Range(0).Select(_ => new TestModel
        {
            Id = new Random().Next(0, 100),
            Age = new Random().Next(0, 100),
            Name = "apple"
        }).ToList();
}