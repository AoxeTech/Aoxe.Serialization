namespace Zaabee.Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public async Task JilStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new Jil.Serializer(Options.ISO8601Utc), new Jil.Serializer(Options.ISO8601Utc),
            TestModelFactory.Create());

    [Fact]
    public async Task MessagePackStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new MessagePack.Serializer(), new MessagePack.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task MsgPackStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new MsgPack.Serializer(), new MsgPack.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task NewtonsoftJsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new NewtonsoftJson.Serializer(), new NewtonsoftJson.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task SystemTextJsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new SystemTextJson.Serializer(), new SystemTextJson.Serializer(),
            TestModelFactory.Create());

    [Fact]
    public async Task Utf8JsonStreamGenericAsyncTest() =>
        await StreamGenericAsyncTest(new Utf8Json.Serializer(), new Utf8Json.Serializer(), TestModelFactory.Create());

    private async Task StreamGenericAsyncTest(IStreamSerializer serializer, IStreamSerializerAsync serializerAsync,
        TestModel model)
    {
        var stream = new MemoryStream();
        await serializerAsync.PackAsync(model, stream);
        var deserializeModel = await serializerAsync.FromStreamAsync<TestModel>(stream);

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel!.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }
}