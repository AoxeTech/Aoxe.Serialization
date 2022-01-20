namespace CodeTimer.Runner;

public partial class Runner
{
    public void ToBytes(int iteration)
    {
        Console.WriteLine("ToBytes go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.ToBytes(_testModel)));
#pragma warning restore CS0618
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper", iteration,
            () => MessagePackHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper", iteration,
            () => MsgPackHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper", iteration,
            () => ProtobufHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper", iteration,
            () => SharpYamlHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper", iteration,
            () => YamlDotNetHelper.ToBytes(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper", iteration,
            () => ZeroFormatterHelper.ToBytes(_testModel)));

        Console.WriteLine("\r\nToBytes complete!\r\n");
    }
}