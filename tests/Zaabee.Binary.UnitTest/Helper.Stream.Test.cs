namespace Zaabee.Binary.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperStreamTest()
    {
        var testModel = TestModelFactory.Create();
        var stream = BinaryHelper.Pack(testModel);
        var unPackResult = stream.Unpack<TestModel>();

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult.Id, unPackResult.Age, unPackResult.CreateTime, unPackResult.Name,
                unPackResult.Gender));
    }

    [Fact]
    public void HelperStreamPackNullTest()
    {
        Assert.Equal(0, BinaryHelper.Pack(null).Length);
        var ms = new MemoryStream();
        BinaryHelper.Pack(null, ms);
        Assert.Equal(0, ms.Length);
        Assert.Equal(0, ms.Position);
    }

    [Fact]
    public void HelperStreamUnpackNullTest()
    {
        Assert.Null(BinaryHelper.Unpack<TestModel>(null));
    }
}