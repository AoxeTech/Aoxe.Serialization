using System.Text;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public static Options DefaultOptions { get; set; }
    }
}