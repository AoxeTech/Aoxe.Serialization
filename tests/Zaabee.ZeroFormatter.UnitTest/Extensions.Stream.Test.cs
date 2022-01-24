namespace Zaabee.ZeroFormatter.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeStreamTest()
    {
        var testModel = TestModelFactory.Create();

        var stream0 = testModel.ToStream();
        var result0 = stream0.FromStream<TestModel>()!;

        var stream1 = new MemoryStream();
        testModel.PackTo(stream1);
        var result1 = stream1.FromStream<TestModel>()!;

        var stream2 = new MemoryStream();
        stream2.PackBy(testModel);
        var result2 = stream2.FromStream<TestModel>()!;

#if NET48
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name,
                testModel.Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime.ToLocalTime(), result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name,
                testModel.Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime.ToLocalTime(), result1.Name, result1.Gender));

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name,
                testModel.Gender),
            Tuple.Create(result2.Id, result2.Age, result2.CreateTime.ToLocalTime(), result2.Name, result2.Gender));
#else
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name,
                testModel.Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name,
                testModel.Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name,
                testModel.Gender),
            Tuple.Create(result2.Id, result2.Age, result2.CreateTime, result2.Name, result2.Gender));
#endif
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
        object testModel = TestModelFactory.Create();

        var stream0 = testModel.ToStream(typeof(TestModel));
        var result0 = (TestModel)stream0.FromStream(typeof(TestModel))!;

        var stream1 = new MemoryStream();
        testModel.PackTo(typeof(TestModel), stream1);
        var result1 = (TestModel)stream1.FromStream(typeof(TestModel))!;

        var stream2 = new MemoryStream();
        stream2.PackBy(typeof(TestModel), testModel);
        var result2 = (TestModel)stream2.FromStream(typeof(TestModel))!;

#if NET48
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name,
                ((TestModel)testModel).Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime.ToLocalTime(), result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name,
                ((TestModel)testModel).Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime.ToLocalTime(), result1.Name, result1.Gender));

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name,
                ((TestModel)testModel).Gender),
            Tuple.Create(result2.Id, result2.Age, result2.CreateTime.ToLocalTime(), result2.Name, result2.Gender));
#else
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name,
                ((TestModel)testModel).Gender),
            Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name,
                ((TestModel)testModel).Gender),
            Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));

        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name,
                ((TestModel)testModel).Gender),
            Tuple.Create(result2.Id, result2.Age, result2.CreateTime, result2.Name, result2.Gender));
#endif
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