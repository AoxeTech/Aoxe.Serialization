namespace Aoxe.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void SharpYamlYamlNonGenericNullTest() =>
        YamlNonGenericNullTest(new SharpYaml.Serializer());

    [Fact]
    public void YamlDotNetYamlNonGenericNullTest() =>
        YamlNonGenericNullTest(new YamlDotNet.Serializer());

    private static void YamlNonGenericNullTest(IYamlSerializer serializer)
    {
        var type = typeof(TestModel);
        var yaml = serializer.ToYaml(type, null);
        var deserializeModel = serializer.FromYaml(type, yaml);
        Assert.Null(deserializeModel);
    }
}
