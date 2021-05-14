using System.Text;
using Xunit;

namespace Zaabee.Jil.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void DefaultSetTest()
        {
            JilHelper.DefaultEncoding = Encoding.UTF32;
            JilHelper.DefaultOptions = null;
            Assert.Equal(Encoding.UTF32, JilHelper.DefaultEncoding);
            Assert.Null(JilHelper.DefaultOptions);
        }
    }
}