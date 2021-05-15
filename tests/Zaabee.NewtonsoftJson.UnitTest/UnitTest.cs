using System.Text;
using Xunit;

namespace Zaabee.NewtonsoftJson.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void DefaultSetTest()
        {
            NewtonsoftJsonHelper.DefaultEncoding = Encoding.UTF8;
            NewtonsoftJsonHelper.DefaultSettings = null;
            Assert.Equal(NewtonsoftJsonHelper.DefaultEncoding, Encoding.UTF8);
            Assert.Null(NewtonsoftJsonHelper.DefaultSettings);
        }
    }
}