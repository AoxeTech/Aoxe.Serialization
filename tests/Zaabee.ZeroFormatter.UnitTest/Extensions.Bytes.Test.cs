namespace Zaabee.ZeroFormatter.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeBytesTest()
    {
        var testModel = TestModelFactory.Create();
        testModel.CreateTime = testModel.CreateTime;
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>()!;
#if NET48
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime.ToLocalTime(), result.Name, result.Gender));
#else
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
#endif
    }

    [Fact]
    public void GenericTypeBytesNullTest()
    {
        TestModel? nullModel = null;
        Assert.Null(nullModel.ToBytes().FromBytes<TestModel>());
        Assert.Null(Array.Empty<byte>().FromBytes<TestModel>());
    }

    [Fact]
    public void NonGenericTypeBytesTest()
    {
        object testModel = TestModelFactory.Create();
        var bytes = testModel.ToBytes(typeof(TestModel));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;
#if NET48
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime.ToLocalTime(), result.Name, result.Gender));
#else
        Assert.Equal(
            Tuple.Create(((TestModel)testModel).Id, ((TestModel)testModel).Age,
                ((TestModel)testModel).CreateTime, ((TestModel)testModel).Name, ((TestModel)testModel).Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
#endif
    }

    [Fact]
    public void NonGenericTypeBytesNullTest()
    {
        object? nullModel = null;
        Assert.Null(nullModel.ToBytes(typeof(TestModel)).FromBytes(typeof(TestModel)));
        Assert.Null(Array.Empty<byte>().FromBytes(typeof(TestModel)));
    }
}