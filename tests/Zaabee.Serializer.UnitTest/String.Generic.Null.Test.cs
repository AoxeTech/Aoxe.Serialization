namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractStringGenericNullTest() =>
        StringGenericNullTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilStringGenericNullTest() =>
        StringGenericNullTest(new Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringGenericNullTest() =>
        StringGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringGenericNullTest() =>
        StringGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringGenericNullTest() =>
        StringGenericNullTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlStringGenericNullTest() =>
        StringGenericNullTest(new Xml.Serializer());

    private static void StringGenericNullTest(ITextSerializer serializer)
    {
        TestModel? model = null;
        var text = serializer.ToText(model);
        Assert.Empty(text);
        var deserializeModel = serializer.FromText<TestModel>(null);
        Assert.Null(deserializeModel);
    }
}