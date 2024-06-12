namespace Aoxe.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void IniIniGenericNullTest() => IniGenericNullTest(new Ini.Serializer());

    private static void IniGenericNullTest(IIniSerializer serializer)
    {
        TestModel? model = null;
        var ini = serializer.ToIni(model);
        var deserializeModel = serializer.FromIni<TestModel>(ini);
        Assert.Null(deserializeModel);
    }
}
