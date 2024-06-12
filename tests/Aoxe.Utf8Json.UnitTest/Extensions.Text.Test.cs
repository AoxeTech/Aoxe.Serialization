namespace Aoxe.Utf8Json.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeJsonTest()
    {
        var testModel = TestModelHelper.Create();
        var json = testModel.ToJson();
        var result = json.FromJson<TestModel>()!;

        Assert.Equal(testModel, result);
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
        object testModel = TestModelHelper.Create();
        var json = testModel.ToJson(typeof(TestModel));
        var result = (TestModel)json.FromJson(typeof(TestModel))!;

        Assert.Equal((TestModel)testModel, result);
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

    [Fact]
    public void ObjectJsonTest()
    {
        object testModel = TestModelHelper.Create();
        var json = testModel.ToJson();
        var result = (TestModel)json.FromJson(typeof(TestModel))!;

        Assert.Equal((TestModel)testModel, result);
    }

    [Fact]
    public void ObjectJsonNullTest()
    {
        object? nullModel = null;
        string? nullJson = null;
        var emptyJson = nullModel.ToJson();
        Assert.Null(emptyJson.FromJson(typeof(TestModel)));
        Assert.Null(nullJson.FromJson(typeof(TestModel)));
    }
}
