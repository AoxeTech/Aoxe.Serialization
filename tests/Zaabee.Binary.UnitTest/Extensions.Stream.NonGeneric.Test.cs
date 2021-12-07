namespace Zaabee.Binary.UnitTest;

public partial class BinaryExtensionsUnitTest
{
    [Fact]
    public void ExtensionsStreamNonGenericTest()
    {
        var testModel = TestModelFactory.Create();

        var stream1 = testModel.ToStream();
        var stream2 = new MemoryStream();
        testModel.PackTo(stream2);
        var stream3 = new MemoryStream();
        stream3.PackBy(testModel);

        var unPackResult1 = (TestModel)stream1.Unpack();
        var unPackResult2 = (TestModel)stream2.Unpack();
        var unPackResult3 = (TestModel)stream3.Unpack();

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
        Assert.Equal(0, nullValue.ToStream().Length);
    }

    [Fact]
    public void ExtensionsPackToNonGenericNullTest()
    {
        TestModel? nullValue = null;
        var stream = new MemoryStream();
        nullValue.PackTo(stream);
        Assert.Equal(0, stream.Length);
    }

    [Fact]
    public void ExtensionsPackByNonGenericNullTest()
    {
        TestModel? nullValue = null;
        var stream = new MemoryStream();
        stream.PackBy(nullValue);
        Assert.Equal(0, stream.Length);
    }

    [Fact]
    public void ExtensionsUnpackNonGenericNullTest()
    {
        MemoryStream? nullStream = null;
        Assert.Null(nullStream.Unpack());
    }
}