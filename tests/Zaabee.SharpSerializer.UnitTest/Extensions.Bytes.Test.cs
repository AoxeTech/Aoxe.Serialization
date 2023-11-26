namespace Zaabee.SharpSerializer.UnitTest;

public class MyClass
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeBytesTest()
    {
        var myObject = new MyClass { Id = 1, Name = "Example" };

        // 使用 SharpSerializer 进行序列化
        var serializer = new Polenter.Serialization.SharpSerializer();
        var ms = new MemoryStream();
        serializer.Serialize(myObject, ms);
        ms.Seek(0, SeekOrigin.Begin);

        // 使用 SharpSerializer 进行反序列化
        var deserializedObject = serializer.Deserialize(ms) as MyClass;

        // 使用反序列化后的对象
        if (deserializedObject != null)
        {
            Console.WriteLine($"Deserialized Object: Id = {deserializedObject.Id}, Name = {deserializedObject.Name}");
        }


        var testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>()!;

        Assert.Equal(testModel, result);
    }

    [Fact]
    public void GenericTypeBytesNullTest()
    {
        TestModel? nullModel = null;
        byte[]? nullBytes = null;
        Assert.Null(nullModel.ToBytes().FromBytes<TestModel>());
        Assert.Null(Array.Empty<byte>().FromBytes<TestModel>());
        Assert.Null(nullBytes.FromBytes<TestModel>());
    }

    [Fact]
    public void NonGenericTypeBytesTest()
    {
        object testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes(typeof(TestModel));
        var result = (TestModel)bytes.FromBytes(typeof(TestModel))!;

        Assert.Equal((TestModel)testModel, result);
    }

    [Fact]
    public void NonGenericTypeBytesNullTest()
    {
        object? nullModel = null;
        byte[]? nullBytes = null;
        Assert.Null(nullModel.ToBytes(typeof(TestModel)).FromBytes(typeof(TestModel)));
        Assert.Null(Array.Empty<byte>().FromBytes(typeof(TestModel)));
        Assert.Null(nullBytes.FromBytes(typeof(TestModel)));
    }
}