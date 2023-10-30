namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task IniStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new Ini.Serializer());

    [Fact]
    public async Task JilStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new Jil.Serializer(Options.ISO8601Utc));

#if !NET48
    [Fact]
    public async Task MemoryPackStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public async Task MessagePackStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new MessagePack.Serializer());

    [Fact]
    public async Task MsgPackStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new MsgPack.Serializer());

    [Fact]
    public async Task NetJsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new NetJson.Serializer());

    [Fact]
    public async Task NewtonsoftJsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new NewtonsoftJson.Serializer());

#if !NET48
    [Fact]
    public async Task SpanJsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new SpanJson.Serializer());
#endif

    [Fact]
    public async Task SystemTextJsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new SystemTextJson.Serializer());

    [Fact]
    public async Task Utf8JsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new Utf8Json.Serializer());

    private async Task StreamGenericNullAsyncTest(
        IStreamSerializerAsync serializerAsync)
    {
        TestModel? model = null;
        var stream = new MemoryStream();
        await serializerAsync.PackAsync(model, stream);
        var deserializeModel = await serializerAsync.FromStreamAsync<TestModel>(stream);
        Assert.Null(deserializeModel);
    }
}