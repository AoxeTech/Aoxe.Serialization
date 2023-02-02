namespace Zaabee.SystemTextJson.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeJsonTest()
    {
        var testModel = TestModelHelper.Create();
        var json = testModel.ToJson();
        var result = json.FromJson<TestModel>()!;
        
        TestModelHelper.AssertEqual(testModel, result);
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
        
        TestModelHelper.AssertEqual((TestModel)testModel, result);
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