namespace Zaabee.Tomlet.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public async Task GenericTypeStreamAsyncTest()
    {
        var testModel = TestModelHelper.Create();

        var stream0 = testModel.ToStream();
        var result0 = (await stream0.FromStreamAsync<TestModel>())!;

        var stream1 = new MemoryStream();
        await testModel.PackToAsync(stream1);
        var result1 = (await stream1.FromStreamAsync<TestModel>())!;

        var stream2 = new MemoryStream();
        await stream2.PackByAsync(testModel);
        var result2 = (await stream2.FromStreamAsync<TestModel>())!;

        Assert.Equal(testModel, result0);
        Assert.Equal(testModel, result1);
        Assert.Equal(testModel, result2);
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
        object? testModel = TestModelHelper.Create();

        var stream0 = testModel.ToStream();
        var result0 = (await stream0.FromStreamAsync(typeof(TestModel)))!;

        var stream1 = new MemoryStream();
        await testModel.PackToAsync(stream1);
        var result1 = (await stream1.FromStreamAsync(typeof(TestModel)))!;

        var stream2 = new MemoryStream();
        await stream2.PackByAsync(testModel);
        var result2 = (await stream2.FromStreamAsync(typeof(TestModel)))!;

        Assert.Equal((TestModel)testModel, (TestModel)result0);
        Assert.Equal((TestModel)testModel, (TestModel)result1);
        Assert.Equal((TestModel)testModel, (TestModel)result2);
    }

    [Fact]
    public async Task NonGenericTypeStreamAsyncNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream(typeof(object));
        Assert.Null(await emptyStream.FromStreamAsync(typeof(object)));

        MemoryStream? nullStream = null;
        await nullStream.PackByAsync(typeof(object), nullModel);
        await nullModel.PackToAsync(typeof(object), nullStream);

        await Stream.Null.FromStreamAsync(typeof(object));
    }
}
