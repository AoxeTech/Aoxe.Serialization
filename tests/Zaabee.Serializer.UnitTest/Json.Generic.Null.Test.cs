namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void JilJsonGenericNullTest() =>
        JsonGenericNullTest(new Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonJsonGenericNullTest() =>
        JsonGenericNullTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonJsonGenericNullTest() =>
        JsonGenericNullTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonJsonGenericNullTest() =>
        JsonGenericNullTest(new Utf8Json.Serializer());

    private static void JsonGenericNullTest(IJsonSerializer serializer)
    {
        TestModel? model = null;
        var json = serializer.ToJson(model);
        var deserializeModel = serializer.FromJson<TestModel>(json);
        Assert.Null(deserializeModel);
    }
}