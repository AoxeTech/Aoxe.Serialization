namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void JilJsonNonGenericTest() =>
        JsonNonGenericTest(new Jil.Serializer(Options.ISO8601Utc));

    [Fact]
    public void NetJsonJsonNonGenericTest() =>
        JsonNonGenericTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonJsonNonGenericTest() =>
        JsonNonGenericTest(new NewtonsoftJson.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonJsonNonGenericTest() =>
        JsonNonGenericTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonJsonNonGenericTest() =>
        JsonNonGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonJsonNonGenericTest() =>
        JsonNonGenericTest(new Utf8Json.Serializer());

    private static void JsonNonGenericTest(IJsonSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var type = typeof(TestModel);
        var json = serializer.ToJson(type, model);
        var deserializeModel = (TestModel)serializer.FromJson(type, json)!;
        
        TestModelHelper.AssertEqual(model, deserializeModel);
    }
}