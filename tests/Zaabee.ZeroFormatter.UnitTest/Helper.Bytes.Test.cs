namespace Zaabee.ZeroFormatter.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperBytesTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = ZeroFormatterHelper.ToBytes(testModel);
        var result = (TestModel)ZeroFormatterHelper.FromBytes(typeof(TestModel), bytes)!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void HelperSerializeNullTest()
    {
        var bytes = ZeroFormatterHelper.ToBytes(typeof(TestModel), null);
    }

    [Fact]
    public void HelperDeserializeNullTest()
    {
        Assert.Null(ZeroFormatterHelper.FromBytes<TestModel>(null));
    }
}