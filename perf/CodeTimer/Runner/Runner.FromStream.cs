namespace CodeTimer.Runner;

public partial class Runner
{
    public void FromStream(int iteration)
    {
#pragma warning disable CS0618
        var binaryStream = BinaryHelper.ToStream(_testModel);
#pragma warning restore CS0618
        var dataContractStream = DataContractHelper.ToStream(_testModel);
        var jilStream = JilHelper.ToStream(_testModel);
        var messagePackStream = MessagePackHelper.ToStream(_testModel);
        var msgPackStream = MsgPackHelper.ToStream(_testModel);
        var newtonsoftJsonStream = NewtonsoftJsonHelper.ToStream(_testModel);
        var protobufStream = ProtobufHelper.ToStream(_testModel);
        var sharpYamlStream = SharpYamlHelper.ToStream(_testModel);
        var systemTextJsonStream = SystemTextJsonHelper.ToStream(_testModel);
        var utf8JsonStream = Utf8JsonHelper.ToStream(_testModel);
        var xmlStream = XmlHelper.ToStream(_testModel);
        var yamlDotNetStream = YamlDotNetHelper.ToStream(_testModel);
        var zeroFormatterStream = ZeroFormatterHelper.ToStream(_testModel);

        Console.WriteLine("FromStream go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper", iteration,
#pragma warning disable CS0618
            () => BinaryHelper.FromStream<TestModel>(binaryStream));
#pragma warning restore CS0618
        Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.FromStream<TestModel>(dataContractStream));
        Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.FromStream<TestModel>(jilStream));
        Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper", iteration,
            () => MessagePackHelper.FromStream<TestModel>(messagePackStream));
        Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper", iteration,
            () => MsgPackHelper.FromStream<TestModel>(msgPackStream));
        Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.FromStream<TestModel>(newtonsoftJsonStream));
        Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper", iteration,
            () => ProtobufHelper.FromStream<TestModel>(protobufStream));
        Zaabee.CodeTimer.CodeTimer.Time("SharpYamlHelper", iteration,
            () => SharpYamlHelper.FromStream<TestModel>(sharpYamlStream));
        Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.FromStream<TestModel>(systemTextJsonStream));
        Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.FromStream<TestModel>(utf8JsonStream));
        Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.FromStream<TestModel>(xmlStream));
        Zaabee.CodeTimer.CodeTimer.Time("YamlDotNetHelper", iteration,
            () => YamlDotNetHelper.FromStream<TestModel>(yamlDotNetStream));
        Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper", iteration,
            () => ZeroFormatterHelper.FromStream<TestModel>(zeroFormatterStream));

        Console.WriteLine("FromStream complete!");
    }
}