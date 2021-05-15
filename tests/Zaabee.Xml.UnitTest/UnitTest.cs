using System.Text;
using Xunit;

namespace Zaabee.Xml.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void DefaultSetTest()
        {
            Assert.Equal(XmlHelper.DefaultEncoding, Encoding.UTF8);
            XmlHelper.DefaultEncoding = Encoding.UTF8;
            Assert.Equal(XmlHelper.DefaultEncoding, Encoding.UTF8);
        }
    }
}