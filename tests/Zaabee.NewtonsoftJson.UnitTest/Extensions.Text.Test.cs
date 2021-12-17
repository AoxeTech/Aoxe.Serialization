namespace Zaabee.NewtonsoftJson.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeJsonTest()
    {
        var testModel = TestModelFactory.Create();
        var json = testModel.ToJson();
        var result = json.FromJson<TestModel>()!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void GenericTypeJsonNullTest()
    {
        TestModel? nullModel = null;
        string? nullJson = null;
        var emptyJson = nullModel.ToJson();
        Assert.Null(emptyJson.FromJson<TestModel>());
        Assert.Null(nullJson.FromJson<TestModel>());
    }

    [Fact]
    public void NonGenericTypeJsonTest()
    {
        object testModel = TestModelFactory.Create();
        var json = testModel.ToJson(typeof(TestModel));
        var result = (TestModel)json.FromJson(typeof(TestModel))!;
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
        var emptyJson = nullModel.ToJson(typeof(TestModel));
        Assert.Null(emptyJson.FromJson(typeof(TestModel)));
        Assert.Null(nullJson.FromJson(typeof(TestModel)));
    }
}