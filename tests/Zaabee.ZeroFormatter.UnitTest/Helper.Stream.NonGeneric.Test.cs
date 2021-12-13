namespace Zaabee.ZeroFormatter.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperStreamNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var stream = ZeroFormatterHelper.ToStream(typeof(TestModel), testModel);
        var unPackResult = (TestModel)ZeroFormatterHelper.FromStream(typeof(TestModel), stream)!;

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult.Id, unPackResult.Age, unPackResult.CreateTime, unPackResult.Name,
                unPackResult.Gender));
    }

    [Fact]
    public void HelperStreamToStreamNonGenericNullTest()
    {
        var stream = ZeroFormatterHelper.ToStream(typeof(TestModel), null);
        var ms = new MemoryStream();
        ZeroFormatterHelper.Pack(typeof(TestModel), null, ms);
    }

    [Fact]
    public void HelperStreamPackNonGenericNullTest()
    {
        ZeroFormatterHelper.Pack(typeof(TestModel), TestModelFactory.Create(), null);
    }

    [Fact]
    public void HelperStreamFromStreamNonGenericNullTest()
    {
        Assert.Null(ZeroFormatterHelper.FromStream(typeof(TestModel), null));
    }
}