namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractXmlNonGenericNullTest() =>
        XmlNonGenericNullTest(new DataContractSerializer.Serializer());

    [Fact]
    public void SharpSerializerXmlNonGenericNullTest() =>
        XmlNonGenericNullTest(new SharpSerializer.Serializer());

    [Fact]
    public void XmlXmlNonGenericNullTest() => XmlNonGenericNullTest(new Xml.Serializer());

    private static void XmlNonGenericNullTest(IXmlSerializer serializer)
    {
        var type = typeof(TestModel);
        var xml = serializer.ToXml(type, null);
        var deserializeModel = serializer.FromXml(type, xml);
        Assert.Null(deserializeModel);
    }
}
