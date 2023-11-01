namespace Zaabee.Tomlet.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeTomlTest()
    {
        var testModel = TestModelHelper.Create();
        var toml = testModel.ToToml();
        var result = toml.FromToml<TestModel>()!;

        TestModelHelper.AssertEqual(testModel, result);
    }

    [Fact]
    public void GenericTypeTomlNullTest()
    {
        TestModel? nullModel = null;
        string? nullToml = null;
        var emptyToml = nullModel.ToToml();
        Assert.Null(emptyToml.FromToml<TestModel>());
        Assert.Null(nullToml.FromToml<TestModel>());
    }

    [Fact]
    public void NonGenericTypeTomlNullTest()
    {
        object? nullModel = null;
        string? nullToml = null;
        var emptyToml = nullModel.ToToml(typeof(object));
        Assert.Null(emptyToml.FromToml(typeof(object)));
        Assert.Null(nullToml.FromToml(typeof(object)));
    }

    [Fact]
    public void ObjectTomlNullTest()
    {
        object? nullModel = null;
        string? nullToml = null;
        var emptyToml = nullModel.ToToml(typeof(object));
        Assert.Null(emptyToml.FromToml(typeof(object)));
        Assert.Null(nullToml.FromToml(typeof(object)));
    }
}