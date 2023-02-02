using Xunit;

namespace TestModels;

public static class TestModelHelper
{
    public static TestModel Create() => new()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        Name = "apple",
        Gender = Gender.Female
    };

    public static List<TestModel> Create(int quantity) =>
        quantity.Range(0).Select(_ => new TestModel
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            Name = "apple",
            Gender = Gender.Female
        }).ToList();

    public static void AssertEqual(TestModel? first, TestModel? second)
    {
        Assert.NotNull(first);
        Assert.NotNull(second);
        Assert.Equal(first.Id, second.Id);
        Assert.Equal(first.Age, second.Age);
        Assert.Equal(first.Name, second.Name);
        Assert.Equal(first.Gender, second.Gender);
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