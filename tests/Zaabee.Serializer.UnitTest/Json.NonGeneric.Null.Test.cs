namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void JilJsonNonGenericNullTest() =>
        JsonNonGenericNullTest(new Jil.Serializer());

    [Fact]
    public void NetJsonJsonNonGenericNullTest() =>
        JsonNonGenericNullTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonJsonNonGenericNullTest() =>
        JsonNonGenericNullTest(new NewtonsoftJson.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonJsonNonGenericNullTest() =>
        JsonNonGenericNullTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonJsonNonGenericNullTest() =>
        JsonNonGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonJsonNonGenericNullTest() =>
        JsonNonGenericNullTest(new Utf8Json.Serializer());

    private static void JsonNonGenericNullTest(IJsonSerializer serializer)
    {
        var type = typeof(TestModel);
        var json = serializer.ToJson(type, null);
        var deserializeModel = serializer.FromJson(type, json);
        Assert.Null(deserializeModel);
    }
}