namespace Zaabee.YamlDotNet.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeJsonTest()
    {
        var testModel = TestModelFactory.Create();
        var json = testModel.ToYaml();
        var result = json.FromYaml<TestModel>()!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void GenericTypeJsonNullTest()
    {
        TestModel? nullModel = null;
        string? nullJson = null;
        var emptyJson = nullModel.ToYaml();
        Assert.Null(emptyJson.FromYaml<TestModel>());
        Assert.Null(nullJson.FromYaml<TestModel>());
    }

    [Fact]
    public void NonGenericTypeJsonTest()
    {
        object testModel = TestModelFactory.Create();
        var json = testModel.ToYaml();
        var result = (TestModel)json.FromYaml(typeof(TestModel))!;
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void NonGenericTypeJsonNullTest()
    {
        object? nullModel = null;
        string? nullJson = null;
        var emptyJson = nullModel.ToYaml();
        Assert.Null(emptyJson.FromYaml(typeof(TestModel)));
        Assert.Null(nullJson.FromYaml(typeof(TestModel)));
    }

    [Fact]
    public void ObjectJsonTest()
    {
        object testModel = TestModelFactory.Create();
        var json = testModel.ToYaml();
        var result = (TestModel)json.FromYaml(typeof(TestModel))!;
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void ObjectJsonNullTest()
    {
        object? nullModel = null;
        string? nullJson = null;
        var emptyJson = nullModel.ToYaml();
        Assert.Null(emptyJson.FromYaml(typeof(TestModel)));
        Assert.Null(nullJson.FromYaml(typeof(TestModel)));
    }
}