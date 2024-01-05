namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractTextGenericTest() =>
        TextGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniTextGenericTest() => TextGenericTest(new Ini.Serializer());

    [Fact]
    public void JilTextGenericTest() => TextGenericTest(new Jil.Serializer(Options.ISO8601Utc));

    [Fact]
    public void NetJsonTextGenericTest() => TextGenericTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonTextGenericTest() => TextGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SharpYamlTextGenericTest() => TextGenericTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonTextGenericTest() => TextGenericTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonTextGenericTest() => TextGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void TomletTextGenericTest() => TextGenericTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonTextGenericTest() => TextGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlTextGenericTest() => TextGenericTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetGenericTest() => TextGenericTest(new YamlDotNet.Serializer());

    private static void TextGenericTest(ITextSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var text = serializer.ToText(model);
        var deserializeModel = serializer.FromText<TestModel>(text)!;

        Assert.Equal(model, deserializeModel);
    }
}
