namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void SharpYamlYamlGenericTest() =>
        YamlGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void YamlDotNetYamlGenericTest() =>
        YamlGenericTest(new YamlDotNet.Serializer());

    private static void YamlGenericTest(IYamlSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var yaml = serializer.ToYaml(model);
        var deserializeModel = serializer.FromYaml<TestModel>(yaml)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}