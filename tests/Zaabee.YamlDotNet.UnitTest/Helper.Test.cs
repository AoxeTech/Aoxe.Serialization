namespace Zaabee.YamlDotNet.UnitTest;

public partial class HelperTest
{
    [Fact]
    public void DefaultSetTest()
    {
        YamlDotNetHelper.DefaultEncoding = Encoding.UTF8;
        Assert.Equal(YamlDotNetHelper.DefaultEncoding, Encoding.UTF8);
    }
}