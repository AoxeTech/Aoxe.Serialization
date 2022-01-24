namespace CodeTimer.Cases;

public partial class Case
{
    public void FromBytes(int iteration)
    {
#pragma warning disable CS0618
        var binaryBytes = BinaryHelper.ToBytes(_testModel);
#pragma warning restore CS0618
        var dataContractBytes = DataContractHelper.ToBytes<TestModel>(_testModel);
        var jilBytes = JilHelper.ToBytes<TestModel>(_testModel);
        var messagePackBytes = MessagePackHelper.ToBytes<TestModel>(_testModel);
        var msgPackBytes = MsgPackHelper.ToBytes<TestModel>(_testModel);
        var newtonsoftJsonBytes = NewtonsoftJsonHelper.ToBytes<TestModel>(_testModel);
        var protobufBytes = ProtobufHelper.ToBytes<TestModel>(_testModel);
        var sharpYamlBytes = SharpYamlHelper.ToBytes<TestModel>(_testModel);
        var systemTextJsonBytes = SystemTextJsonHelper.ToBytes<TestModel>(_testModel);
        var utf8JsonBytes = Utf8JsonHelper.ToBytes<TestModel>(_testModel);
        var xmlBytes = XmlHelper.ToBytes<TestModel>(_testModel);
        var yamlDotNetBytes = YamlDotNetHelper.ToBytes(_testModel);
        var zeroFormatterBytes = ZeroFormatterHelper.ToBytes<TestModel>(_testModel);

        Console.WriteLine("FromBytes go!");
        
        Runner.Initialize();

        Console.WriteLine(Runner.Time("BinaryHelper FromBytes", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.FromBytes<TestModel>(binaryBytes)));
#pragma warning restore CS0618
        Console.WriteLine(Runner.Time("DataContractHelper FromBytes", iteration,
            () => DataContractHelper.FromBytes<TestModel>(dataContractBytes)));
        Console.WriteLine(Runner.Time("JilHelper FromBytes", iteration,
            () => JilHelper.FromBytes<TestModel>(jilBytes)));
        Console.WriteLine(Runner.Time("MessagePackHelper FromBytes", iteration,
            () => MessagePackHelper.FromBytes<TestModel>(messagePackBytes)));
        Console.WriteLine(Runner.Time("MsgPackHelper FromBytes", iteration,
            () => MsgPackHelper.FromBytes<TestModel>(msgPackBytes)));
        Console.WriteLine(Runner.Time("NewtonsoftJsonHelper FromBytes", iteration,
            () => NewtonsoftJsonHelper.FromBytes<TestModel>(newtonsoftJsonBytes)));
        Console.WriteLine(Runner.Time("ProtobufHelper FromBytes", iteration,
            () => ProtobufHelper.FromBytes<TestModel>(protobufBytes)));
        Console.WriteLine(Runner.Time("SharpYamlHelper FromBytes", iteration,
            () => SharpYamlHelper.FromBytes<TestModel>(sharpYamlBytes)));
        Console.WriteLine(Runner.Time("SystemTextJsonHelper FromBytes", iteration,
            () => SystemTextJsonHelper.FromBytes<TestModel>(systemTextJsonBytes)));
        Console.WriteLine(Runner.Time("Utf8JsonHelper FromBytes", iteration,
            () => Utf8JsonHelper.FromBytes<TestModel>(utf8JsonBytes)));
        Console.WriteLine(Runner.Time("XmlHelper FromBytes", iteration,
            () => XmlHelper.FromBytes<TestModel>(xmlBytes)));
        Console.WriteLine(Runner.Time("YamlDotNetHelper FromBytes", iteration,
            () => YamlDotNetHelper.FromBytes<TestModel>(yamlDotNetBytes)));
        Console.WriteLine(Runner.Time("ZeroFormatterHelper FromBytes", iteration,
            () => ZeroFormatterHelper.FromBytes<TestModel>(zeroFormatterBytes)));
        
        Console.WriteLine("\r\nFromBytes complete!\r\n");
    }
}