namespace CodeTimer.Runner;

public partial class Runner
{
    public Task FromStreamAsync(int iteration)
    {
        var jilStreamAsync = JilHelper.ToStream(_testModel);
        var messagePackStreamAsync = MessagePackHelper.ToStream(_testModel);
        var msgPackStreamAsync = MsgPackHelper.ToStream(_testModel);
        var newtonsoftJsonStreamAsync = NewtonsoftJsonHelper.ToStream(_testModel);
        var systemTextJsonStreamAsync = SystemTextJsonHelper.ToStream(_testModel);
        var utf8JsonStreamAsync = Utf8JsonHelper.ToStream(_testModel);

        Console.WriteLine("FromStreamAsync go!");

        Zaabee.CodeTimer.CodeTimer.Initialize();

        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("JilHelper FromStreamAsync", iteration,
            async () => await JilHelper.FromStreamAsync<TestModel>(jilStreamAsync)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MessagePackHelper FromStreamAsync", iteration,
            async () => await MessagePackHelper.FromStreamAsync<TestModel>(messagePackStreamAsync)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("MsgPackHelper FromStreamAsync", iteration,
            async () => await MsgPackHelper.FromStreamAsync<TestModel>(msgPackStreamAsync)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("NewtonsoftJsonHelper FromStreamAsync", iteration,
            async () => await NewtonsoftJsonHelper.FromStreamAsync<TestModel>(newtonsoftJsonStreamAsync)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("SystemTextJsonHelper FromStreamAsync", iteration,
            async () => await SystemTextJsonHelper.FromStreamAsync<TestModel>(systemTextJsonStreamAsync)));
        Console.WriteLine(Zaabee.CodeTimer.CodeTimer.Time("Utf8JsonHelper FromStreamAsync", iteration,
            async () => await Utf8JsonHelper.FromStreamAsync<TestModel>(utf8JsonStreamAsync)));

        Console.WriteLine("\r\nFromStreamAsync complete!\r\n");

        return Task.CompletedTask;
    }
}