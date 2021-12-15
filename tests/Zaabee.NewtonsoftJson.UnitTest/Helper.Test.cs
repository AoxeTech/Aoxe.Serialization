namespace Zaabee.NewtonsoftJson.UnitTest;

public partial class HelperTest
{
    [Fact]
    public void DefaultSetTest()
    {
        NewtonsoftJsonHelper.DefaultEncoding = Encoding.UTF8;
        Assert.Equal(NewtonsoftJsonHelper.DefaultEncoding, Encoding.UTF8);
    }
}