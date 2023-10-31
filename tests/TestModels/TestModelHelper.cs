using Xunit;

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

    public static void AssertEqual(TestModel? first, TestModel? second)
    {
        Assert.NotNull(first);
        Assert.NotNull(second);
        Assert.Equal(first.Id, second.Id);
        Assert.Equal(first.Age, second.Age);
        Assert.Equal(first.Name, second.Name);
    }
    
    public static void AssertEqual(IList<TestModel>? first, IList<TestModel>? second)
    {
        Assert.NotNull(first);
        Assert.NotNull(second);
        Assert.Equal(first.Count, second.Count);
        for (var i = 0; i < first.Count; i++)
            AssertEqual(first[i], second[i]);
    }
}