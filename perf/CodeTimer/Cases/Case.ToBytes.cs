namespace CodeTimer.Cases;

public partial class Case
{
    public void ToBytes(int iteration)
    {
        Console.WriteLine("ToBytes go!");

        Runner.Initialize();

        Console.WriteLine(Runner.Time("BinaryHelper ToBytes", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.ToBytes(_testModel)));
#pragma warning restore CS0618
        Console.WriteLine(Runner.Time("DataContractHelper ToBytes", iteration,
            () => DataContractHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("JilHelper ToBytes", iteration,
            () => JilHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("MemoryPackHelper ToBytes", iteration,
            () => MemoryPackHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("MessagePackHelper ToBytes", iteration,
            () => MessagePackHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("MsgPackHelper ToBytes", iteration,
            () => MsgPackHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("NewtonsoftJsonHelper ToBytes", iteration,
            () => NewtonsoftJsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("ProtobufHelper ToBytes", iteration,
            () => ProtobufHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("SharpYamlHelper ToBytes", iteration,
            () => SharpYamlHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("SystemTextJsonHelper ToBytes", iteration,
            () => SystemTextJsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("Utf8JsonHelper ToBytes", iteration,
            () => Utf8JsonHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("XmlHelper ToBytes", iteration,
            () => XmlHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("YamlDotNetHelper ToBytes", iteration,
            () => YamlDotNetHelper.ToBytes(_testModel)));
        Console.WriteLine(Runner.Time("ZeroFormatterHelper ToBytes", iteration,
            () => ZeroFormatterHelper.ToBytes(_testModel)));

        Console.WriteLine("\r\nToBytes complete!\r\n");
    }
}