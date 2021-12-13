using System.Linq.Expressions;

namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void JilStringGenericTest() =>
        StringGenericTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringGenericTest() =>
        StringGenericTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringGenericTest() =>
        StringGenericTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringGenericTest() =>
        StringGenericTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStringGenericTest() =>
        StringGenericTest(new Zaabee.Xml.Serializer());

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

    private static void StringGenericNullTest(ITextSerializer serializer)
    {
        TestModel? model = null;
        var text = serializer.ToText(model);
        Assert.Empty(text);
        var deserializeModel = serializer.FromText<TestModel>(null);
        Assert.Null(deserializeModel);
    }
}