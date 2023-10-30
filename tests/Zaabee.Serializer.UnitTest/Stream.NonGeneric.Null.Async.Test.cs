namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task IniStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new Ini.Serializer());

    [Fact]
    public async Task JilStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new Jil.Serializer(Options.ISO8601Utc));

#if !NET48
    [Fact]
    public async Task MemoryPackStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public async Task MessagePackStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new MessagePack.Serializer());

    [Fact]
    public async Task MsgPackStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new MsgPack.Serializer());

    [Fact]
    public async Task NetJsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new NetJson.Serializer());

    [Fact]
    public async Task NewtonsoftJsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new NewtonsoftJson.Serializer());

#if !NET48
    [Fact]
    public async Task SpanJsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new SpanJson.Serializer());
#endif

    [Fact]
    public async Task SystemTextJsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new SystemTextJson.Serializer());

    [Fact]
    public async Task Utf8JsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new Utf8Json.Serializer());

    private async Task StreamNonGenericNullAsyncTest(IStreamSerializerAsync serializerAsync)
    {
        var type = typeof(TestModel);
        var stream = new MemoryStream();
        await serializerAsync.PackAsync(type, null, stream);
        var deserializeModel = await serializerAsync.FromStreamAsync(type, stream);
        Assert.Null(deserializeModel);
    }
}