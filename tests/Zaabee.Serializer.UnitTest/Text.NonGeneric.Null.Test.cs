namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractTextNonGenericNullTest() =>
        TextNonGenericNullTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilTextNonGenericNullTest() =>
        TextNonGenericNullTest(new Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonTextNonGenericNullTest() =>
        TextNonGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SharpYamlTextNonGenericNullTest() =>
        TextNonGenericNullTest(new SharpYaml.Serializer());

    [Fact]
    public void SystemTextJsonTextNonGenericNullTest() =>
        TextNonGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonTextNonGenericNullTest() =>
        TextNonGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlTextNonGenericNullTest() =>
        TextNonGenericNullTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetTextNonGenericNullTest() =>
        TextNonGenericNullTest(new YamlDotNet.Serializer());

    private static void TextNonGenericNullTest(ITextSerializer serializer)
    {
        var type = typeof(TestModel);
        var text = serializer.ToText(type, null);
        var deserializeModel = serializer.FromText(type, text);
        Assert.Null(deserializeModel);
    }
}