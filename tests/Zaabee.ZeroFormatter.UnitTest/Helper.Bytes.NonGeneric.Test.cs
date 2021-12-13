namespace Zaabee.ZeroFormatter.UnitTest;

public partial class BinaryHelperUnitTest
{
    [Fact]
    public void HelperBytesNonGenericTest()
    {
        var testModel = TestModelFactory.Create();
        var bytes = ZeroFormatterHelper.ToBytes(typeof(TestModel), testModel);
        var result = (TestModel)ZeroFormatterHelper.FromBytes(typeof(TestModel), bytes)!;
        Assert.Equal(
            Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
            Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
    }

    [Fact]
    public void HelperSerializeNonGenericNullTest()
    {
        var bytes = ZeroFormatterHelper.ToBytes(typeof(TestModel), null);
    }

    [Fact]
    public void HelperDeserializeNonGenericNullTest()
    {
        Assert.Null(ZeroFormatterHelper.FromBytes(typeof(TestModel), null));
    }
}