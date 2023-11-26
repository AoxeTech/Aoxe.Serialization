namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void IniIniNonGenericNullTest() => IniNonGenericNullTest(new Ini.Serializer());

    private static void IniNonGenericNullTest(IIniSerializer serializer)
    {
        var type = typeof(TestModel);
        var ini = serializer.ToIni(type, null);
        var deserializeModel = serializer.FromIni(type, ini);
        Assert.Null(deserializeModel);
    }
}
