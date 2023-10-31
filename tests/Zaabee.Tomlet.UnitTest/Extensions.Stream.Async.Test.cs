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

        TestModelHelper.AssertEqual(testModel, result0);
        TestModelHelper.AssertEqual(testModel, result1);
        TestModelHelper.AssertEqual(testModel, result2);
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
    public async Task NonGenericTypeStreamAsyncNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream();
        Assert.Null(await emptyStream.FromStreamAsync());

        MemoryStream? nullStream = null;
        await nullStream.PackByAsync(nullModel);
        await nullModel.PackToAsync(nullStream);

        await Stream.Null.FromStreamAsync();
    }

    [Fact]
    public async Task ObjectStreamAsyncNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream();
        Assert.Null(await emptyStream.FromStreamAsync());

        MemoryStream? nullStream = null;
        await nullStream.PackByAsync(nullModel);
        await nullModel.PackToAsync(nullStream);

        await Stream.Null.FromStreamAsync();
    }
}