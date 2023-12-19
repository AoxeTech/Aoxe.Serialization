namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void DataContractXmlGenericTest() =>
        XmlGenericTest(new DataContractSerializer.Serializer());

    [Fact]
    public void SharpSerializerXmlGenericTest() => XmlGenericTest(new SharpSerializer.Serializer());

    [Fact]
    public void XmlXmlGenericTest() => XmlGenericTest(new Xml.Serializer());

    private static void XmlGenericTest(IXmlSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var xml = serializer.ToXml(model);
        var deserializeModel = serializer.FromXml<TestModel>(xml)!;

        Assert.Equal(model, deserializeModel);
    }
}
