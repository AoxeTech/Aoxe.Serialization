namespace CodeTimer.Runner;

public partial class Runner
{
    public void FromBytes(int iteration)
    {
        var binaryBytes = BinaryHelper.ToBytes(_testModel);
        var dataContractBytes = DataContractHelper.ToBytes(_testModel);
        var jilBytes = JilHelper.ToBytes(_testModel);
        var messagePackBytes = MessagePackHelper.ToBytes(_testModel);
        var msgPackBytes = MsgPackHelper.ToBytes(_testModel);
        var newtonsoftJsonBytes = NewtonsoftJsonHelper.ToBytes(_testModel);
        var protobufBytes = ProtobufHelper.ToBytes(_testModel);
        var systemTextJsonBytes = SystemTextJsonHelper.ToBytes(_testModel);
        var utf8JsonBytes = Utf8JsonHelper.ToBytes(_testModel);
        var xmlBytes = XmlHelper.ToBytes(_testModel);
        var zeroFormatterBytes = ZeroFormatterHelper.ToBytes(_testModel);
        
        Console.WriteLine("FromBytes go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper", iteration,
            () => BinaryHelper.FromBytes<TestModel>(binaryBytes));
        Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.FromBytes<TestModel>(dataContractBytes));
        Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.FromBytes<TestModel>(jilBytes));
        Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper", iteration,
            () => MessagePackHelper.FromBytes<TestModel>(messagePackBytes));
        Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper", iteration,
            () => MsgPackHelper.FromBytes<TestModel>(msgPackBytes));
        Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.FromBytes<TestModel>(newtonsoftJsonBytes));
        Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper", iteration,
            () => ProtobufHelper.FromBytes<TestModel>(protobufBytes));
        Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.FromBytes<TestModel>(systemTextJsonBytes));
        Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.FromBytes<TestModel>(utf8JsonBytes));
        Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.FromBytes<TestModel>(xmlBytes));
        Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper", iteration,
            () => ZeroFormatterHelper.FromBytes<TestModel>(zeroFormatterBytes));
        
        Console.WriteLine("FromBytes complete!");
    }
}