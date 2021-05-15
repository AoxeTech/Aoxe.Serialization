using Xunit;

namespace Zaabee.Utf8Json.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void DefaultSetTest()
        {
            Utf8JsonHelper.DefaultJsonFormatterResolver = null;
            Assert.Null(Utf8JsonHelper.DefaultJsonFormatterResolver);
        }
    }
}