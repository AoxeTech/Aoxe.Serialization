namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractTextGenericNullTest() =>
        TextGenericNullTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniTextGenericNullTest() =>
        TextGenericNullTest(new Ini.Serializer());

    [Fact]
    public void JilTextGenericNullTest() =>
        TextGenericNullTest(new Jil.Serializer());

    [Fact]
    public void NetJsonTextGenericNullTest() =>
        TextGenericNullTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonTextGenericNullTest() =>
        TextGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SharpYamlTextGenericNullTest() =>
        TextGenericNullTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonTextGenericNullTest() =>
        TextGenericNullTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonTextGenericNullTest() =>
        TextGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonTextGenericNullTest() =>
        TextGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlTextGenericNullTest() =>
        TextGenericNullTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetTextGenericNullTest() =>
        TextGenericNullTest(new YamlDotNet.Serializer());

    private static void TextGenericNullTest(ITextSerializer serializer)
    {
        TestModel? model = null;
        var text = serializer.ToText(model);
        var deserializeModel = serializer.FromText<TestModel>(text);
        Assert.Null(deserializeModel);
    }
}