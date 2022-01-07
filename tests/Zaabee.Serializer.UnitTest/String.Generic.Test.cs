namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractStringGenericTest() =>
        StringGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void JilStringGenericTest() =>
        StringGenericTest(new Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringGenericTest() =>
        StringGenericTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringGenericTest() =>
        StringGenericTest(new SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringGenericTest() =>
        StringGenericTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlStringGenericTest() =>
        StringGenericTest(new Xml.Serializer());

    private static void StringGenericTest(ITextSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var bytes = serializer.ToText(model);
        var deserializeModel = serializer.FromText<TestModel>(bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}