namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractStringNonGenericTest() =>
        StringNonGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilStringNonGenericTest() =>
        StringNonGenericTest(new Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringNonGenericTest() =>
        StringNonGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringNonGenericTest() =>
        StringNonGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringNonGenericTest() =>
        StringNonGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlStringNonGenericTest() =>
        StringNonGenericTest(new Xml.Serializer());

    private static void StringNonGenericTest(ITextSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.ToText(type, model);
        var deserializeModel = (TestModel)serializer.FromText(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}