namespace Aoxe.Tomlyn.UnitTest;

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

        Assert.Equal(testModel, result0);
        Assert.Equal(testModel, result1);
        Assert.Equal(testModel, result2);
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
    public void NonGenericTypeStreamNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream();
        Assert.Null(emptyStream.FromStream());

        MemoryStream? nullStream = null;
        nullStream.PackBy(nullModel);
        nullModel.PackTo(nullStream);

        Stream.Null.FromStream();
    }

    [Fact]
    public void ObjectStreamNullTest()
    {
        object? nullModel = null;

        var emptyStream = nullModel.ToStream();
        Assert.Null(emptyStream.FromStream());

        MemoryStream? nullStream = null;
        nullStream.PackBy(nullModel);
        nullModel.PackTo(nullStream);

        Stream.Null.FromStream();
    }
}
