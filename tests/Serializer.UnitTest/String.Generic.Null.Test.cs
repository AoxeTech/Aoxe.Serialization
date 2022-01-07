namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractStringGenericNullTest() =>
        StringGenericNullTest(new Zaabee.DataContractSerializer.Serializer());

    [Fact]
    public void JilStringGenericNullTest() =>
        StringGenericNullTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringGenericNullTest() =>
        StringGenericNullTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringGenericNullTest() =>
        StringGenericNullTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringGenericNullTest() =>
        StringGenericNullTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStringGenericNullTest() =>
        StringGenericNullTest(new Zaabee.Xml.Serializer());

    private static void StringGenericNullTest(ITextSerializer serializer)
    {
        TestModel? model = null;
        var text = serializer.ToText(model);
        Assert.Empty(text);
        var deserializeModel = serializer.FromText<TestModel>(null);
        Assert.Null(deserializeModel);
    }
}