namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task JilStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new Jil.Serializer(Options.ISO8601Utc),
            new Jil.Serializer(Options.ISO8601Utc));

    [Fact]
    public async Task MessagePackStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new MessagePack.Serializer(), new MessagePack.Serializer());

    [Fact]
    public async Task MsgPackStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new MsgPack.Serializer(), new MsgPack.Serializer());

    [Fact]
    public async Task NewtonsoftJsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new NewtonsoftJson.Serializer(), new NewtonsoftJson.Serializer());

    [Fact]
    public async Task SystemTextJsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new SystemTextJson.Serializer(), new SystemTextJson.Serializer());

    [Fact]
    public async Task Utf8JsonStreamNonGenericNullAsyncTest() =>
        await StreamNonGenericNullAsyncTest(new Utf8Json.Serializer(), new Utf8Json.Serializer());

    private async Task StreamNonGenericNullAsyncTest(IStreamSerializer serializer,
        IStreamSerializerAsync serializerAsync)
    {
        var type = typeof(TestModel);
        var stream = new MemoryStream();
        await serializerAsync.PackAsync(type, null, stream);
        var deserializeModel = await serializerAsync.FromStreamAsync(type, stream);
        Assert.Null(deserializeModel);
    }
}