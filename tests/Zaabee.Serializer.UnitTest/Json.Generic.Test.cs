namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void JilJsonGenericTest() =>
        JsonGenericTest(new Jil.Serializer(Options.ISO8601Utc));

    [Fact]
    public void NetJsonJsonGenericTest() =>
        JsonGenericTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonJsonGenericTest() =>
        JsonGenericTest(new NewtonsoftJson.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonJsonGenericTest() =>
        JsonGenericTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonJsonGenericTest() =>
        JsonGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonJsonGenericTest() =>
        JsonGenericTest(new Utf8Json.Serializer());

    private static void JsonGenericTest(IJsonSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var json = serializer.ToJson(model);
        var deserializeModel = serializer.FromJson<TestModel>(json)!;
        
        TestModelHelper.AssertEqual(model, deserializeModel);
    }
}