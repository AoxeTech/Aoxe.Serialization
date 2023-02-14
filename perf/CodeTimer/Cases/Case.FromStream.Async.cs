namespace CodeTimer.Cases;

public partial class Case
{
    public Task FromStreamAsync(int iteration)
    {
        var jilStreamAsync = JilHelper.ToStream(_testModel);
        var memoryPackStreamAsync = MemoryPackHelper.ToStream(_testModel);
        var messagePackStreamAsync = MessagePackHelper.ToStream(_testModel);
        var msgPackStreamAsync = MsgPackHelper.ToStream(_testModel);
        var newtonsoftJsonStreamAsync = NewtonsoftJsonHelper.ToStream(_testModel);
        var systemTextJsonStreamAsync = SystemTextJsonHelper.ToStream(_testModel);
        var utf8JsonStreamAsync = Utf8JsonHelper.ToStream(_testModel);

        Console.WriteLine("FromStreamAsync go!");

        Runner.Initialize();

        Console.WriteLine(Runner.Time("JilHelper FromStreamAsync", iteration,
            async () => await JilHelper.FromStreamAsync<TestModel>(jilStreamAsync)));
        Console.WriteLine(Runner.Time("MemoryPackHelper FromStreamAsync", iteration,
            async () => await MemoryPackHelper.FromStreamAsync<TestModel>(memoryPackStreamAsync)));
        Console.WriteLine(Runner.Time("MessagePackHelper FromStreamAsync", iteration,
            async () => await MessagePackHelper.FromStreamAsync<TestModel>(messagePackStreamAsync)));
        Console.WriteLine(Runner.Time("MsgPackHelper FromStreamAsync", iteration,
            async () => await MsgPackHelper.FromStreamAsync<TestModel>(msgPackStreamAsync)));
        Console.WriteLine(Runner.Time("NewtonsoftJsonHelper FromStreamAsync", iteration,
            async () => await NewtonsoftJsonHelper.FromStreamAsync<TestModel>(newtonsoftJsonStreamAsync)));
        Console.WriteLine(Runner.Time("SystemTextJsonHelper FromStreamAsync", iteration,
            async () => await SystemTextJsonHelper.FromStreamAsync<TestModel>(systemTextJsonStreamAsync)));
        Console.WriteLine(Runner.Time("Utf8JsonHelper FromStreamAsync", iteration,
            async () => await Utf8JsonHelper.FromStreamAsync<TestModel>(utf8JsonStreamAsync)));

        Console.WriteLine("\r\nFromStreamAsync complete!\r\n");

        return Task.CompletedTask;
    }
}