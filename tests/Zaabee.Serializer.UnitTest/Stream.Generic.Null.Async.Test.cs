namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task JilStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new Jil.Serializer(Options.ISO8601Utc),
            new Jil.Serializer(Options.ISO8601Utc));

    [Fact]
    public async Task MessagePackStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new MessagePack.Serializer(), new MessagePack.Serializer());

    [Fact]
    public async Task MsgPackStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new MsgPack.Serializer(), new MsgPack.Serializer());

    [Fact]
    public async Task NewtonsoftJsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new NewtonsoftJson.Serializer(), new NewtonsoftJson.Serializer());

    [Fact]
    public async Task SystemTextJsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new SystemTextJson.Serializer(), new SystemTextJson.Serializer());

    [Fact]
    public async Task Utf8JsonStreamGenericNullAsyncTest() =>
        await StreamGenericNullAsyncTest(new Utf8Json.Serializer(), new Utf8Json.Serializer());

    private async Task StreamGenericNullAsyncTest(IStreamSerializer serializer, IStreamSerializerAsync serializerAsync)
    {
        TestModel? model = null;
        var stream = new MemoryStream();
        await serializerAsync.PackAsync(model, stream);
        var deserializeModel = await serializerAsync.FromStreamAsync<TestModel>(stream);
        Assert.Null(deserializeModel);
    }
}