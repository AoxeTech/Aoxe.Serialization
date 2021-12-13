namespace Zaabee.ZeroFormatter.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperStreamTest()
    {
        var testModel = TestModelFactory.Create();
        var stream = ZeroFormatterHelper.ToStream(testModel);
        var unPackResult = ZeroFormatterHelper.FromStream<TestModel>(stream)!;

        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(unPackResult.Id, unPackResult.Age, unPackResult.CreateTime, unPackResult.Name,
                unPackResult.Gender));
    }

    [Fact]
    public void HelperStreamToStreamNullTest()
    {
        var stream = ZeroFormatterHelper.ToStream(typeof(TestModel), null);
        var ms = new MemoryStream();
        ZeroFormatterHelper.Pack(typeof(TestModel), null, ms);
    }

    [Fact]
    public void HelperStreamPackNullTest()
    {
        ZeroFormatterHelper.Pack<TestModel>(TestModelFactory.Create(), null);
    }

    [Fact]
    public void HelperStreamFromStreamNullTest()
    {
        Assert.Null(ZeroFormatterHelper.FromStream<TestModel>(null));
    }
}