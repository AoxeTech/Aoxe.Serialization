namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void IniIniGenericTest() =>
        IniGenericTest(new Ini.Serializer());

    private static void IniGenericTest(IIniSerializer serializer)
    {
        var model = TestModelHelper.Create();
        var ini = serializer.ToIni(model);
        var deserializeModel = serializer.FromIni<TestModel>(ini)!;
        
        TestModelHelper.AssertEqual(model, deserializeModel);
    }
}