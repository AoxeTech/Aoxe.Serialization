namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractXmlGenericTest() =>
        XmlGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void XmlXmlGenericTest() =>
        XmlGenericTest(new Xml.Serializer());

    private static void XmlGenericTest(IXmlSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var xml = serializer.ToXml(model);
        var deserializeModel = serializer.FromXml<TestModel>(xml)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}