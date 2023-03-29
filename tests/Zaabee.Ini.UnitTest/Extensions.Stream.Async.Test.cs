namespace Zaabee.Ini.UnitTest;

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
    public async Task NonGenericTypeStreamAsyncTest()
    {
        object testModel = TestModelHelper.Create();

        var stream0 = testModel.ToStream(typeof(TestModel));
        var result0 = (TestModel)(await stream0.FromStreamAsync(typeof(TestModel)))!;

        var stream1 = new MemoryStream();
        await testModel.PackToAsync(typeof(TestModel), stream1);
        var result1 = (TestModel)(await stream1.FromStreamAsync(typeof(TestModel)))!;

        var stream2 = new MemoryStream();
        await stream2.PackByAsync(typeof(TestModel), testModel);
        var result2 = (TestModel)(await stream2.FromStreamAsync(typeof(TestModel)))!;
        
        TestModelHelper.AssertEqual((TestModel)testModel, result0);
        TestModelHelper.AssertEqual((TestModel)testModel, result1);
        TestModelHelper.AssertEqual((TestModel)testModel, result2);
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

    [Fact]
    public async Task ObjectStreamAsyncTest()
    {
        object testModel = TestModelHelper.Create();

        var stream0 = testModel.ToStream();
        var result0 = (TestModel)(await stream0.FromStreamAsync(typeof(TestModel)))!;

        var stream1 = new MemoryStream();
        await testModel.PackToAsync(stream1);
        var result1 = (TestModel)(await stream1.FromStreamAsync(typeof(TestModel)))!;

        var stream2 = new MemoryStream();
        await stream2.PackByAsync(testModel);
        var result2 = (TestModel)(await stream2.FromStreamAsync(typeof(TestModel)))!;
        
        TestModelHelper.AssertEqual((TestModel)testModel, result0);
        TestModelHelper.AssertEqual((TestModel)testModel, result1);
        TestModelHelper.AssertEqual((TestModel)testModel, result2);
    }

    [Fact]
    public async Task ObjectStreamAsyncNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream();
        Assert.Null(await emptyStream.FromStreamAsync(typeof(TestModel)));

        MemoryStream? nullStream = null;
        await nullStream.PackByAsync(nullModel);
        await nullModel.PackToAsync(nullStream);

        await Stream.Null.FromStreamAsync(typeof(TestModel));
    }
}