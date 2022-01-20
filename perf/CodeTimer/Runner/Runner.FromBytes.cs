namespace CodeTimer.Runner;

public partial class Runner
{
    public void FromBytes(int iteration)
    {
#pragma warning disable CS0618
        var binaryBytes = BinaryHelper.ToBytes(_testModel);
#pragma warning restore CS0618
        var dataContractBytes = DataContractHelper.ToBytes(_testModel);
        var jilBytes = JilHelper.ToBytes(_testModel);
        var messagePackBytes = MessagePackHelper.ToBytes(_testModel);
        var msgPackBytes = MsgPackHelper.ToBytes(_testModel);
        var newtonsoftJsonBytes = NewtonsoftJsonHelper.ToBytes(_testModel);
        var protobufBytes = ProtobufHelper.ToBytes(_testModel);
        var sharpYamlBytes = SharpYamlHelper.ToBytes(_testModel);
        var systemTextJsonBytes = SystemTextJsonHelper.ToBytes(_testModel);
        var utf8JsonBytes = Utf8JsonHelper.ToBytes(_testModel);
        var xmlBytes = XmlHelper.ToBytes(_testModel);
        var yamlDotNetBytes = YamlDotNetHelper.ToBytes(_testModel);
        var zeroFormatterBytes = ZeroFormatterHelper.ToBytes(_testModel);

        Console.WriteLine("FromBytes go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper FromBytes", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.FromBytes<TestModel>(binaryBytes)));
#pragma warning restore CS0618
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper FromBytes", iteration,
            () => DataContractHelper.FromBytes<TestModel>(dataContractBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper FromBytes", iteration,
            () => JilHelper.FromBytes<TestModel>(jilBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper FromBytes", iteration,
            () => MessagePackHelper.FromBytes<TestModel>(messagePackBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper FromBytes", iteration,
            () => MsgPackHelper.FromBytes<TestModel>(msgPackBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper FromBytes", iteration,
            () => NewtonsoftJsonHelper.FromBytes<TestModel>(newtonsoftJsonBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper FromBytes", iteration,
            () => ProtobufHelper.FromBytes<TestModel>(protobufBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper FromBytes", iteration,
            () => SharpYamlHelper.FromBytes<TestModel>(sharpYamlBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper FromBytes", iteration,
            () => SystemTextJsonHelper.FromBytes<TestModel>(systemTextJsonBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper FromBytes", iteration,
            () => Utf8JsonHelper.FromBytes<TestModel>(utf8JsonBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper FromBytes", iteration,
            () => XmlHelper.FromBytes<TestModel>(xmlBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper FromBytes", iteration,
            () => YamlDotNetHelper.FromBytes<TestModel>(yamlDotNetBytes)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper FromBytes", iteration,
            () => ZeroFormatterHelper.FromBytes<TestModel>(zeroFormatterBytes)));
        
        Console.WriteLine("\r\nFromBytes complete!\r\n");
    }
}