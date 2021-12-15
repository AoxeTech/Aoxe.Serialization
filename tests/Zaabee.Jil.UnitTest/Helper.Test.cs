namespace Zaabee.Jil.UnitTest;

public partial class HelperTest
{
    [Fact]
    public void DefaultSetTest()
    {
        JilHelper.DefaultEncoding = Encoding.UTF8;
        Assert.Equal(JilHelper.DefaultEncoding, Encoding.UTF8);
    }
}