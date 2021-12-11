namespace Zaabee.Binary.UnitTest;

public partial class BinaryExtensionsUnitTest
{
    [Fact]
    public void ExtensionsStreamTest()
    {
        var testModel = TestModelFactory.Create();

        var stream1 = testModel.ToStream();
        var stream2 = new MemoryStream();
        testModel.PackTo(stream2);
        var stream3 = new MemoryStream();
        stream3.PackBy(testModel);

        var unPackResult1 = stream1.FromStream<TestModel>();
        var unPackResult2 = stream2.FromStream<TestModel>();
        var unPackResult3 = stream3.FromStream<TestModel>();

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

        Assert.Equal(0, BinaryHelper.ToStream(null).Length);
        Assert.Null(BinaryHelper.FromStream<TestModel>(null));
        var ms = new MemoryStream();
        BinaryHelper.Pack(null, ms);
        Assert.Equal(0, ms.Length);
        Assert.Equal(0, ms.Position);
    }

    [Fact]
    public void ExtensionsToStreamNullTest()
    {
        TestModel? nullValue = null;
        Assert.Equal(0, nullValue.ToStream().Length);
    }

    [Fact]
    public void ExtensionsPackToNullTest()
    {
        TestModel? nullValue = null;
        var stream = new MemoryStream();
        nullValue.PackTo(stream);
        Assert.Equal(0, stream.Length);
    }

    [Fact]
    public void ExtensionsPackByNullTest()
    {
        TestModel? nullValue = null;
        var stream = new MemoryStream();
        stream.PackBy(nullValue);
        Assert.Equal(0, stream.Length);
    }

    [Fact]
    public void ExtensionsUnpackNullTest()
    { 
        MemoryStream? nullStream = null;
        Assert.Null(nullStream.FromStream<TestModel>());
    }
}