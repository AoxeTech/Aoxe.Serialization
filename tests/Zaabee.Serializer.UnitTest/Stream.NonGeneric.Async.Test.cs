namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task JilStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new Jil.Serializer(Options.ISO8601Utc), TestModelHelper.Create());

#if !NET48
    [Fact]
    public async Task MemoryPackStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new MemoryPack.Serializer(), TestModelHelper.Create());
#endif

    [Fact]
    public async Task MessagePackStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new MessagePack.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task MsgPackStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new MsgPack.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task NewtonsoftJsonStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new NewtonsoftJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task SystemTextJsonStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new SystemTextJson.Serializer(), TestModelHelper.Create());

    [Fact]
    public async Task Utf8JsonStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new Utf8Json.Serializer(), TestModelHelper.Create());

    private async Task StreamNonGenericAsyncTest(
        IStreamSerializerAsync streamSerializerAsync,
        TestModel model)
    {
        var type = typeof(TestModel);
        var stream = new MemoryStream();
        await streamSerializerAsync.PackAsync(model, stream);
        var deserializeModel = (TestModel)(await streamSerializerAsync.FromStreamAsync(type, stream))!;

        TestModelHelper.AssertEqual(model, deserializeModel);
    }
}