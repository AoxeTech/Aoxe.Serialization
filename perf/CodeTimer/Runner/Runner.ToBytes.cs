namespace CodeTimer.Runner;

public partial class Runner
{
    public void ToBytes(int iteration)
    {
        Console.WriteLine("ToBytes go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper ToBytes", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.ToBytes(_testModel)));
#pragma warning restore CS0618
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper ToBytes", iteration,
            () => DataContractHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper ToBytes", iteration,
            () => JilHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper ToBytes", iteration,
            () => MessagePackHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper ToBytes", iteration,
            () => MsgPackHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper ToBytes", iteration,
            () => NewtonsoftJsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper ToBytes", iteration,
            () => ProtobufHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper ToBytes", iteration,
            () => SharpYamlHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper ToBytes", iteration,
            () => SystemTextJsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper ToBytes", iteration,
            () => Utf8JsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper ToBytes", iteration,
            () => XmlHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper ToBytes", iteration,
            () => YamlDotNetHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper ToBytes", iteration,
            () => ZeroFormatterHelper.ToBytes(_testModel)));

        Console.WriteLine("\r\nToBytes complete!\r\n");
    }
}