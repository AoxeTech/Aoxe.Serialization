namespace Aoxe.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractXmlGenericNullTest() =>
        XmlGenericNullTest(new DataContractSerializer.Serializer());

    [Fact]
    public void XmlXmlGenericNullTest() => XmlGenericNullTest(new Xml.Serializer());

    private static void XmlGenericNullTest(IXmlSerializer serializer)
    {
        TestModel? model = null;
        var xml = serializer.ToXml(model);
        var deserializeModel = serializer.FromXml<TestModel>(xml);
        Assert.Null(deserializeModel);
    }
}
