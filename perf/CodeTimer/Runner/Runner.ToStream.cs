namespace CodeTimer.Runner;

public partial class Runner
{
    public void ToStream(int iteration)
    {
        Console.WriteLine("ToStream go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.ToStream(_testModel)));
#pragma warning restore CS0618
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper", iteration,
            () => MessagePackHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper", iteration,
            () => MsgPackHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper", iteration,
            () => ProtobufHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper", iteration,
            () => SharpYamlHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper", iteration,
            () => YamlDotNetHelper.ToStream(_testModel)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper", iteration,
            () => ZeroFormatterHelper.ToStream(_testModel)));

        Console.WriteLine("\r\nToStream complete!\r\n");
    }
}