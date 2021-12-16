namespace Zaabee.Xml.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeXmlTest()
    {
        var testModel = TestModelFactory.Create();
        var xml = testModel.ToXml();
        var result = xml.FromXml<TestModel>()!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void GenericTypeXmlNullTest()
    {
        TestModel? nullModel = null;
        string? nullXml = null;
        var emptyXml = nullModel.ToXml();
        Assert.Null(emptyXml.FromXml<TestModel>());
        Assert.Null(nullXml.FromXml<TestModel>());
    }

    [Fact]
    public void NonGenericTypeXmlTest()
    {
        object testModel = TestModelFactory.Create();
        var xml = testModel.ToXml(typeof(TestModel));
        var result = (TestModel)xml.FromXml(typeof(TestModel))!;
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void NonGenericTypeXmlNullTest()
    {
        object? nullModel = null;
        string? nullXml = null;
        var emptyXml = nullModel.ToXml(typeof(TestModel));
        Assert.Null(emptyXml.FromXml(typeof(TestModel)));
        Assert.Null(nullXml.FromXml(typeof(TestModel)));
    }
}