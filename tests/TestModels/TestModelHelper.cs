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

    public static bool CompareTestModel(TestModel first, TestModel second) =>
        first.Id == second.Id
        && first.Age == second.Age
        && first.Name == second.Name
        && first.Gender == second.Gender;

    public static bool CompareTestModels(IList<TestModel> first, IList<TestModel> second) =>
        first.Count == second.Count
        && first.All(p => second.Any(q => CompareTestModel(p, q)));
}