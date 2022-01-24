namespace CodeTimer.Cases;

public partial class Case
{
    public void ToStream(int iteration)
    {
        Console.WriteLine("ToStream go!");

        Runner.Initialize();

        Console.WriteLine(Runner.Time("BinaryHelper ToStream", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.ToStream(_testModel)));
#pragma warning restore CS0618
        Console.WriteLine(Runner.Time("DataContractHelper ToStream", iteration,
            () => DataContractHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("JilHelper ToStream", iteration,
            () => JilHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("MessagePackHelper ToStream", iteration,
            () => MessagePackHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("MsgPackHelper ToStream", iteration,
            () => MsgPackHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("NewtonsoftJsonHelper ToStream", iteration,
            () => NewtonsoftJsonHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("ProtobufHelper ToStream", iteration,
            () => ProtobufHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("SharpYamlHelper ToStream", iteration,
            () => SharpYamlHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("SystemTextJsonHelper ToStream", iteration,
            () => SystemTextJsonHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("Utf8JsonHelper ToStream", iteration,
            () => Utf8JsonHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("XmlHelper ToStream", iteration,
            () => XmlHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("YamlDotNetHelper ToStream", iteration,
            () => YamlDotNetHelper.ToStream(_testModel)));
        Console.WriteLine(Runner.Time("ZeroFormatterHelper ToStream", iteration,
            () => ZeroFormatterHelper.ToStream(_testModel)));

        Console.WriteLine("\r\nToStream complete!\r\n");
    }
}