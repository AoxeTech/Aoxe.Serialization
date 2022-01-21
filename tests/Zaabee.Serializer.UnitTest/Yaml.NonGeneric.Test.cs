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
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var yaml = serializer.ToYaml(type, model);
        var deserializeModel = (TestModel)serializer.FromYaml(type, yaml)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime.ToUniversalTime(),
                deserializeModel.Name, deserializeModel.Gender));
    }
}