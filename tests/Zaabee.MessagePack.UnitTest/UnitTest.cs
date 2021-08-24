using MessagePack;
using Xunit;

namespace Zaabee.MessagePack.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void DefaultSetTest()
        {
            Assert.Null(MessagePackHelper.DefaultOptions);
            MessagePackHelper.DefaultOptions = MessagePackSerializerOptions.Standard;
            Assert.NotNull(MessagePackHelper.DefaultOptions);
        }
    }
}