namespace Zaabee.MsgPack.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public async Task GenericTypeStreamAsyncTest()
    {
        var testModel = TestModelFactory.Create();

        var stream0 = testModel.ToStream();
        var result0 = (await stream0.FromStreamAsync<TestModel>())!;

        var stream1 = new MemoryStream();
        await testModel.PackToAsync(stream1);
        var result1 = (await stream1.FromStreamAsync<TestModel>())!;

        var stream2 = new MemoryStream();
        await stream2.PackByAsync(testModel);
        var result2 = (await stream2.FromStreamAsync<TestModel>())!;

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result2.Id, result2.Age, result2.CreateTime, result2.Name, result2.Gender));
    }

    [Fact]
    public async Task GenericTypeStreamAsyncNullTest()
    {
        TestModel? nullModel = null;

        var emptyStream = nullModel.ToStream();
        Assert.Null(emptyStream.FromStream<TestModel>());

        MemoryStream? nullStream = null;
        await nullStream.PackByAsync(nullModel);
        await nullModel.PackToAsync(nullStream);

        await Stream.Null.FromStreamAsync<TestModel>();
    }

    [Fact]
    public async Task NonGenericTypeStreamAsyncTest()
    {
        object testModel = TestModelFactory.Create();

        var stream0 = testModel.ToStream(typeof(TestModel));
        var result0 = (TestModel)(await stream0.FromStreamAsync(typeof(TestModel)))!;

        var stream1 = new MemoryStream();
        await testModel.PackToAsync(typeof(TestModel), stream1);
        var result1 = (TestModel)(await stream1.FromStreamAsync(typeof(TestModel)))!;

        var stream2 = new MemoryStream();
        await stream2.PackByAsync(typeof(TestModel), testModel);
        var result2 = (TestModel)(await stream2.FromStreamAsync(typeof(TestModel)))!;

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result2.Id, result2.Age, result2.CreateTime, result2.Name, result2.Gender));
    }

    [Fact]
    public async Task NonGenericTypeStreamAsyncNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream(typeof(TestModel));
        Assert.Null(await emptyStream.FromStreamAsync(typeof(TestModel)));

        MemoryStream? nullStream = null;
        await nullStream.PackByAsync(typeof(TestModel), nullModel);
        await nullModel.PackToAsync(typeof(TestModel), nullStream);

        await Stream.Null.FromStreamAsync(typeof(TestModel));
    }
}