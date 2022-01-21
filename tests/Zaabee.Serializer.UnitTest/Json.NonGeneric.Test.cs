namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void JilJsonNonGenericTest() =>
        JsonNonGenericTest(new Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonJsonNonGenericTest() =>
        JsonNonGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonJsonNonGenericTest() =>
        JsonNonGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonJsonNonGenericTest() =>
        JsonNonGenericTest(new Utf8Json.Serializer());

    private static void JsonNonGenericTest(IJsonSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var json = serializer.ToJson(type, model);
        var deserializeModel = (TestModel)serializer.FromJson(type, json)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}