namespace Zaabee.Tomlyn.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeTomlTest()
    {
        var testModel = TestModelHelper.Create();
        var toml = testModel.ToToml();
        var result = toml.FromToml<TestModel>()!;

        Assert.Equal(testModel, result);
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
        var emptyToml = nullModel.ToToml();
        Assert.Null(emptyToml.FromToml());
        Assert.Null(nullToml.FromToml());
    }

    [Fact]
    public void ObjectTomlNullTest()
    {
        object? nullModel = null;
        string? nullToml = null;
        var emptyToml = nullModel.ToToml();
        Assert.Null(emptyToml.FromToml());
        Assert.Null(nullToml.FromToml());
    }
}