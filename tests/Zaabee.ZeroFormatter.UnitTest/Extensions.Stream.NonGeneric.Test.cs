namespace Zaabee.ZeroFormatter.UnitTest;

public partial class BinaryExtensionsUnitTest
{
    [Fact]
    public void ExtensionsStreamNonGenericTest()
    {
        var testModel = TestModelFactory.Create();

        var stream1 = testModel.ToStream(typeof(TestModel));
        var stream2 = new MemoryStream();
        testModel.PackTo(typeof(TestModel), stream2);
        var stream3 = new MemoryStream();
        stream3.PackBy(typeof(TestModel), testModel);

        var unPackResult1 = (TestModel)stream1.FromStream(typeof(TestModel))!;
        var unPackResult2 = (TestModel)stream2.FromStream(typeof(TestModel))!;
        var unPackResult3 = (TestModel)stream3.FromStream(typeof(TestModel))!;

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                unPackResult1.Gender));
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                unPackResult2.Gender));
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                unPackResult3.Gender));
    }

    [Fact]
    public void ExtensionsToStreamNonGenericNullTest()
    {
        TestModel? nullValue = null;
        var stream = nullValue.ToStream(typeof(TestModel));
    }

    [Fact]
    public void ExtensionsPackToNonGenericNullTest()
    {
        TestModel? nullValue = null;
        var stream = new MemoryStream();
        nullValue.PackTo(typeof(TestModel), stream);
    }

    [Fact]
    public void ExtensionsPackByNonGenericNullTest()
    {
        TestModel? nullValue = null;
        var stream = new MemoryStream();
        stream.PackBy(typeof(TestModel), nullValue);
    }

    [Fact]
    public void ExtensionsUnpackNonGenericNullTest()
    {
        MemoryStream? nullStream = null;
        Assert.Null(nullStream.FromStream(typeof(TestModel)));
    }
}