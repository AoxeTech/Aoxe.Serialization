using System.Text;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }
    }
}