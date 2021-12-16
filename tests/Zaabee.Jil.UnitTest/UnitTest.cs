namespace Zaabee.Jil.UnitTest;

public class UnitTest
{
    [Fact]
    public void DefaultSetTest()
    {
        JilHelper.DefaultEncoding = Encoding.UTF32;
        Assert.Equal(Encoding.UTF32, JilHelper.DefaultEncoding);
    }
}