namespace Zaabee.YamlDotNet.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeYamlTest()
    {
        var testModel = TestModelHelper.Create();
        var yaml = testModel.ToYaml();
        var result = yaml.FromYaml<TestModel>()!;
        
        Assert.True(TestModelHelper.CompareTestModel(testModel, result));
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
        object testModel = TestModelHelper.Create();
        var yaml = testModel.ToYaml();
        var result = (TestModel)yaml.FromYaml(typeof(TestModel))!;
        
        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result));
    }

    [Fact]
    public void NonGenericTypeYamlNullTest()
    {
        object? nullModel = null;
        string? nullYaml = null;
        var emptyYaml = nullModel.ToYaml();
        Assert.Null(emptyYaml.FromYaml(typeof(TestModel)));
        Assert.Null(nullYaml.FromYaml(typeof(TestModel)));
    }

    [Fact]
    public void ObjectYamlTest()
    {
        object testModel = TestModelHelper.Create();
        var yaml = testModel.ToYaml();
        var result = (TestModel)yaml.FromYaml(typeof(TestModel))!;
        
        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result));
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