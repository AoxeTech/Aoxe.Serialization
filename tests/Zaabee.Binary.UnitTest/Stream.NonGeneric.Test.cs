namespace Zaabee.Binary.UnitTest;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
public partial class BinaryUnitTest
{
    [Fact]
    public void StreamNonGenericTest()
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
}