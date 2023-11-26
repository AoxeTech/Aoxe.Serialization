namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void SharpYamlYamlGenericNullTest() => YamlGenericNullTest(new SharpYaml.Serializer());

    [Fact]
    public void YamlDotNetYamlGenericNullTest() => YamlGenericNullTest(new YamlDotNet.Serializer());

    private static void YamlGenericNullTest(IYamlSerializer serializer)
    {
        TestModel? model = null;
        var yaml = serializer.ToYaml(model);
        var deserializeModel = serializer.FromYaml<TestModel>(yaml);
        Assert.Null(deserializeModel);
    }
}
