namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractXmlNonGenericTest() =>
        XmlNonGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void XmlXmlNonGenericTest() =>
        XmlNonGenericTest(new Xml.Serializer());

    private static void XmlNonGenericTest(IXmlSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var xml = serializer.ToXml(type, model);
        var deserializeModel = (TestModel)serializer.FromXml(type, xml)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}