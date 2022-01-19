namespace Zaabee.SharpYaml.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeYamlTest()
    {
        var testModel = TestModelFactory.Create();
        var yaml = testModel.ToYaml();
        var result = yaml.FromYaml<TestModel>()!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime.ToUniversalTime(), result.Name, result.Gender));
    }

    [Fact]
    public void GenericTypeYamlNullTest()
    {
        TestModel? nullModel = null;
        string? nullYaml = null;
        var emptyYaml = nullModel.ToYaml();
        Assert.Null(emptyYaml.FromYaml<TestModel>());
        Assert.Null(nullYaml.FromYaml<TestModel>());
    }

    [Fact]
    public void NonGenericTypeYamlTest()
    {
        object testModel = TestModelFactory.Create();
        var yaml = testModel.ToYaml(typeof(TestModel));
        var result = (TestModel)yaml.FromYaml(typeof(TestModel))!;
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime.ToUniversalTime(), result.Name, result.Gender));
    }

    [Fact]
    public void NonGenericTypeYamlNullTest()
    {
        object? nullModel = null;
        string? nullYaml = null;
        var emptyYaml = nullModel.ToYaml(typeof(TestModel));
        Assert.Null(emptyYaml.FromYaml(typeof(TestModel)));
        Assert.Null(nullYaml.FromYaml(typeof(TestModel)));
    }

    [Fact]
    public void ObjectYamlTest()
    {
        object testModel = TestModelFactory.Create();
        var yaml = testModel.ToYaml();
        var result = (TestModel)yaml.FromYaml(typeof(TestModel))!;
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime.ToUniversalTime(), result.Name, result.Gender));
    }

    [Fact]
    public void ObjectYamlNullTest()
    {
        object? nullModel = null;
        string? nullYaml = null;
        var emptyYaml = nullModel.ToYaml();
        Assert.Null(emptyYaml.FromYaml(typeof(TestModel)));
        Assert.Null(nullYaml.FromYaml(typeof(TestModel)));
    }
}