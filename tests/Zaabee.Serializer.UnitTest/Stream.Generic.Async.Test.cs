namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task IniStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new Ini.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task JilStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

#if !NET48
    [Fact]
    public async Task MemoryPackStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new MemoryPack.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public async Task MessagePackStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new MessagePack.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task MsgPackStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new MsgPack.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task NetJsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new NetJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task NewtonsoftJsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new NewtonsoftJson.Serializer(), TestModelHelper.Create());

#if !NET48
    [Fact]
    public async Task SpanJsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new SpanJson.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public async Task SystemTextJsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new SystemTextJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task TomletStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new Tomlet.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task Utf8JsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new Utf8Json.Serializer(), TestModelHelper.Create());

    private static async Task StreamGenericAsyncTest(
        IStreamSerializerAsync serializerAsync,
        TestModel model)
    {
        var stream = new MemoryStream();
        await serializerAsync.PackAsync(model, stream);
        var deserializeModel = (await serializerAsync.FromStreamAsync<TestModel>(stream))!;

        TestModelHelper.AssertEqual(model, deserializeModel);
    }
}