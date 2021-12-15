namespace CodeTimer.Runner;

public partial class Runner
{
    public void ToBytes(int iteration)
    {
        Console.WriteLine("ToBytes go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper", iteration,
            () => BinaryHelper.ToBytes(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper", iteration,
            () => MessagePackHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper", iteration,
            () => MsgPackHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper", iteration,
            () => ProtobufHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.ToBytes<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper", iteration,
            () => ZeroFormatterHelper.ToBytes<TestModel>(_testModel));
        
        Console.WriteLine("ToBytes complete!");
    }
}