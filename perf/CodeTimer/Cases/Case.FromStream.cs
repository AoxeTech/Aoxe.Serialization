namespace CodeTimer.Cases;

public partial class Case
{
       public void FromStream(int iteration)
       {
#pragma warning disable CS0618
              var binaryStream = BinaryHelper.ToStream(_testModel);
#pragma warning restore CS0618
              var dataContractStream = DataContractHelper.ToStream(_testModel);
              var jilStream = JilHelper.ToStream(_testModel);
              var memoryPackStream = MemoryPackHelper.ToStream(_testModel);
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

              Runner.Initialize();

              Console.WriteLine(Runner.Time("BinaryHelper FromStream", iteration,
#pragma warning disable CS0618
                     () => BinaryHelper.FromStream<TestModel>(binaryStream)));
#pragma warning restore CS0618
              Console.WriteLine(Runner.Time("DataContractHelper FromStream", iteration,
                     () => DataContractHelper.FromStream<TestModel>(dataContractStream)));
              Console.WriteLine(Runner.Time("JilHelper FromStream", iteration,
                     () => JilHelper.FromStream<TestModel>(jilStream)));
              Console.WriteLine(Runner.Time("MemoryPackHelper FromStream", iteration,
                     () => MemoryPackHelper.FromStream<TestModel>(memoryPackStream)));
              Console.WriteLine(Runner.Time("MessagePackHelper FromStream", iteration,
                     () => MessagePackHelper.FromStream<TestModel>(messagePackStream)));
              Console.WriteLine(Runner.Time("MsgPackHelper FromStream", iteration,
                     () => MsgPackHelper.FromStream<TestModel>(msgPackStream)));
              Console.WriteLine(Runner.Time("NewtonsoftJsonHelper FromStream", iteration,
                     () => NewtonsoftJsonHelper.FromStream<TestModel>(newtonsoftJsonStream)));
              Console.WriteLine(Runner.Time("ProtobufHelper FromStream", iteration,
                     () => ProtobufHelper.FromStream<TestModel>(protobufStream)));
              Console.WriteLine(Runner.Time("SharpYamlHelper FromStream", iteration,
                     () => SharpYamlHelper.FromStream<TestModel>(sharpYamlStream)));
              Console.WriteLine(Runner.Time("SystemTextJsonHelper FromStream", iteration,
                     () => SystemTextJsonHelper.FromStream<TestModel>(systemTextJsonStream)));
              Console.WriteLine(Runner.Time("Utf8JsonHelper FromStream", iteration,
                     () => Utf8JsonHelper.FromStream<TestModel>(utf8JsonStream)));
              Console.WriteLine(Runner.Time("XmlHelper FromStream", iteration,
                     () => XmlHelper.FromStream<TestModel>(xmlStream)));
              Console.WriteLine(Runner.Time("YamlDotNetHelper FromStream", iteration,
                     () => YamlDotNetHelper.FromStream<TestModel>(yamlDotNetStream)));
              Console.WriteLine(Runner.Time("ZeroFormatterHelper FromStream", iteration,
                     () => ZeroFormatterHelper.FromStream<TestModel>(zeroFormatterStream)));

              Console.WriteLine("\r\nFromStream complete!\r\n");
       }
}