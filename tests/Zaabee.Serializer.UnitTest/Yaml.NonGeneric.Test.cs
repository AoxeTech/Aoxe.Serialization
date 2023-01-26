namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void SharpYamlYamlNonGenericTest() =>
        YamlNonGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void YamlDotNetYamlNonGenericTest() =>
        YamlNonGenericTest(new YamlDotNet.Serializer());

    private static void YamlNonGenericTest(IYamlSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var type = typeof(TestModel);
        var yaml = serializer.ToYaml(type, model);
        var deserializeModel = (TestModel)serializer.FromYaml(type, yaml)!;
        
        Assert.True(TestModelHelper.CompareTestModel(model, deserializeModel));
    }
}