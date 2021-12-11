namespace Zaabee.Binary.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperStreamNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var stream = BinaryHelper.ToStream(testModel);
        var unPackResult = (TestModel)stream.FromStream();

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult.Id, unPackResult.Age, unPackResult.CreateTime, unPackResult.Name,
                unPackResult.Gender));
    }

    [Fact]
    public void HelperStreamPackNonGenericNullTest()
    {
        Assert.Equal(0, BinaryHelper.ToStream(null).Length);
        var ms = new MemoryStream();
        BinaryHelper.Pack(null, ms);
        Assert.Equal(0, ms.Length);
        Assert.Equal(0, ms.Position);
    }

    [Fact]
    public void HelperStreamUnpackNonGenericNullTest()
    {
        Assert.Null(BinaryHelper.FromStream(null));
    }
}