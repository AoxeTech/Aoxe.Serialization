namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void SharpYamlYamlGenericTest() => YamlGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void YamlDotNetYamlGenericTest() => YamlGenericTest(new YamlDotNet.Serializer());

    private static void YamlGenericTest(IYamlSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var yaml = serializer.ToYaml(model);
        var deserializeModel = serializer.FromYaml<TestModel>(yaml)!;

        Assert.Equal(model, deserializeModel);
    }
}
