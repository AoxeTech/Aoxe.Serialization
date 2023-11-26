namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void IniIniNonGenericTest() => IniNonGenericTest(new Ini.Serializer());

    private static void IniNonGenericTest(IIniSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var type = typeof(TestModel);
        var ini = serializer.ToIni(type, model);
        var deserializeModel = (TestModel)serializer.FromIni(type, ini)!;

        Assert.Equal(model, deserializeModel);
    }
}
