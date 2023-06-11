namespace Types.UnitTest;

public class GuidTest
{
#if !NET48
    [Fact]
    public void MemoryPackGuidTest() => GuidSerializeTest(new Zaabee.MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackGuidTest() => GuidSerializeTest(new Zaabee.MessagePack.Serializer());
    
    private static void GuidSerializeTest(IBytesSerializer bytesSerializer)
    {
        var guid = Guid.NewGuid();
        Assert.Equal(guid, bytesSerializer.FromBytes<Guid>(bytesSerializer.ToBytes(guid)));
    }
}