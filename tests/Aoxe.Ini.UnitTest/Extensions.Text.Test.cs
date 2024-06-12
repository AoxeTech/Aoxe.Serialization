namespace Aoxe.Ini.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeIniTest()
    {
        var testModel = TestModelHelper.Create();
        var ini = testModel.ToIni() ?? throw new ArgumentNullException("testModel.ToIni()");
        var result = ini.FromIni<TestModel>()!;

        Assert.Equal(testModel, result);
    }

    [Fact]
    public void GenericTypeIniNullTest()
    {
        TestModel? nullModel = null;
        string? nullIni = null;
        var emptyIni = nullModel.ToIni();
        Assert.Null(emptyIni.FromIni<TestModel>());
        Assert.Null(nullIni.FromIni<TestModel>());
    }

    [Fact]
    public void NonGenericTypeIniTest()
    {
        object testModel = TestModelHelper.Create();
        var ini =
            testModel.ToIni(typeof(TestModel))
            ?? throw new ArgumentNullException("testModel.ToIni(typeof(TestModel))");
        var result = (TestModel)ini.FromIni(typeof(TestModel))!;

        Assert.Equal((TestModel)testModel, result);
    }

    [Fact]
    public void NonGenericTypeIniNullTest()
    {
        object? nullModel = null;
        string? nullIni = null;
        var emptyIni = nullModel.ToIni(typeof(TestModel));
        Assert.Null(emptyIni.FromIni(typeof(TestModel)));
        Assert.Null(nullIni.FromIni(typeof(TestModel)));
    }

    [Fact]
    public void ObjectIniTest()
    {
        object testModel = TestModelHelper.Create();
        var ini = testModel.ToIni();
        var result = (TestModel)ini.FromIni(typeof(TestModel))!;

        Assert.Equal((TestModel)testModel, result);
    }

    [Fact]
    public void ObjectIniNullTest()
    {
        object? nullModel = null;
        string? nullIni = null;
        var emptyIni = nullModel.ToIni();
        Assert.Null(emptyIni.FromIni(typeof(TestModel)));
        Assert.Null(nullIni.FromIni(typeof(TestModel)));
    }
}
