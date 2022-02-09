namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task JilStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new Jil.Serializer(Options.ISO8601Utc), new Jil.Serializer(Options.ISO8601Utc),
            TestModelFactory.Create());

    [Fact]
    public async Task MessagePackStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new MessagePack.Serializer(), new MessagePack.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task MsgPackStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new MsgPack.Serializer(), new MsgPack.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task NewtonsoftJsonStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new NewtonsoftJson.Serializer(), new NewtonsoftJson.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task SystemTextJsonStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new SystemTextJson.Serializer(), new SystemTextJson.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task Utf8JsonStreamNonGenericAsyncTest() =>
        await StreamNonGenericAsyncTest(new Utf8Json.Serializer(), new Utf8Json.Serializer(), TestModelFactory.Create());

    private async Task StreamNonGenericAsyncTest(IStreamSerializer serializer, IStreamSerializerAsync streamSerializerAsync,
        TestModel model)
    {
        var type = typeof(TestModel);
        var stream = new MemoryStream();
        await streamSerializerAsync.PackAsync(model, stream);
        var deserializeModel = (TestModel)(await streamSerializerAsync.FromStreamAsync(type, stream))!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}