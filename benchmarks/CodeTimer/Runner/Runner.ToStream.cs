namespace CodeTimer.Runner;

public partial class Runner
{
    public void ToStream(int iteration)
    {
        Console.WriteLine("ToStream go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Zaabee.CodeTimer.CodeTimer.Time("BinaryHelper", iteration,
            () => BinaryHelper.ToStream(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("DataContractHelper", iteration,
            () => DataContractHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("JilHelper", iteration,
            () => JilHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper", iteration,
            () => MessagePackHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper", iteration,
            () => MsgPackHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper", iteration,
            () => NewtonsoftJsonHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("ProtobufHelper", iteration,
            () => ProtobufHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper", iteration,
            () => SystemTextJsonHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper", iteration,
            () => Utf8JsonHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("XmlHelper", iteration,
            () => XmlHelper.ToStream<TestModel>(_testModel));
        Zaabee.CodeTimer.CodeTimer.Time("ZeroFormatterHelper", iteration,
            () => ZeroFormatterHelper.ToStream<TestModel>(_testModel));
        
        Console.WriteLine("ToStream complete!");
    }
}