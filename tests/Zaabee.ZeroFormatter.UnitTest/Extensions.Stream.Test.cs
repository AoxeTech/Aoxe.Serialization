namespace Zaabee.ZeroFormatter.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeStreamTest()
    {
        var testModel = TestModelHelper.Create();

        var stream0 = testModel.ToStream();
        var result0 = stream0.FromStream<TestModel>()!;

        var stream1 = new MemoryStream();
        testModel.PackTo(stream1);
        var result1 = stream1.FromStream<TestModel>()!;

        var stream2 = new MemoryStream();
        stream2.PackBy(testModel);
        var result2 = stream2.FromStream<TestModel>()!;

        Assert.True(TestModelHelper.CompareTestModel(testModel, result0));
        Assert.True(TestModelHelper.CompareTestModel(testModel, result1));
        Assert.True(TestModelHelper.CompareTestModel(testModel, result2));
    }

    [Fact]
    public void GenericTypeStreamNullTest()
    {
        TestModel? nullModel = null;

        var emptyStream = nullModel.ToStream();
        Assert.Null(emptyStream.FromStream<TestModel>());

        MemoryStream? nullStream = null;
        nullStream.PackBy(nullModel);
        nullModel.PackTo(nullStream);

        Stream.Null.FromStream<TestModel>();
    }

    [Fact]
    public void NonGenericTypeStreamTest()
    {
        object testModel = TestModelHelper.Create();

        var stream0 = testModel.ToStream(typeof(TestModel));
        var result0 = (TestModel)stream0.FromStream(typeof(TestModel))!;

        var stream1 = new MemoryStream();
        testModel.PackTo(typeof(TestModel), stream1);
        var result1 = (TestModel)stream1.FromStream(typeof(TestModel))!;

        var stream2 = new MemoryStream();
        stream2.PackBy(typeof(TestModel), testModel);
        var result2 = (TestModel)stream2.FromStream(typeof(TestModel))!;

        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result0));
        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result1));
        Assert.True(TestModelHelper.CompareTestModel((TestModel)testModel, result2));
    }

    [Fact]
    public void NonGenericTypeStreamNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream(typeof(TestModel));
        Assert.Null(emptyStream.FromStream(typeof(TestModel)));

        MemoryStream? nullStream = null;
        nullStream.PackBy(typeof(TestModel), nullModel);
        nullModel.PackTo(typeof(TestModel), nullStream);

        Stream.Null.FromStream(typeof(TestModel));
    }
}