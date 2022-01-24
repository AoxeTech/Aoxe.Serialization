namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractTextNonGenericTest() =>
        TextNonGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilTextNonGenericTest() =>
        TextNonGenericTest(new Jil.Serializer(Options.ISO8601Utc));

    [Fact]
    public void NewtonsoftJsonTextNonGenericTest() =>
        TextNonGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SharpYamlTextNonGenericTest() =>
        TextNonGenericTest(new SharpYaml.Serializer());

    [Fact]
    public void SystemTextJsonTextNonGenericTest() =>
        TextNonGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonTextNonGenericTest() =>
        TextNonGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlTextNonGenericTest() =>
        TextNonGenericTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetTextNonGenericTest() =>
        TextNonGenericTest(new YamlDotNet.Serializer());

    private static void TextNonGenericTest(ITextSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var text = serializer.ToText(type, model);
        var deserializeModel = (TestModel)serializer.FromText(type, text)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}