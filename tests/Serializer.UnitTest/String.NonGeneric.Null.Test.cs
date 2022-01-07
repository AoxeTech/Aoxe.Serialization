namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.DataContractSerializer.Serializer());

    [Fact]
    public void JilStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.Xml.Serializer());

    private static void StringNonGenericNullTest(ITextSerializer serializer)
    {
        var type = typeof(TestModel);
        var text = serializer.ToText(type, null);
        Assert.Empty(text);
        var deserializeModel = serializer.FromText(type, null);
        Assert.Null(deserializeModel);
    }
}