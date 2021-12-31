namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class FromStreamAsync
{
    private readonly TestModel _testModel = new()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = new DateTime(2017, 1, 1),
        Name = "apple",
        Gender = Gender.Female
    };

    private readonly FileStream _jilStream = new(".\\JilStream", FileMode.Create);
    private readonly FileStream _messagePackStream = new(".\\MessagePackStream", FileMode.Create);
    private readonly FileStream _msgPackStream = new(".\\MsgPackStream", FileMode.Create);
    private readonly FileStream _newtonsoftJsonStream = new(".\\NewtonsoftJsonStream", FileMode.Create);
    private readonly FileStream _systemTextJsonStream = new(".\\SystemTextJsonStream", FileMode.Create);
    private readonly FileStream _utf8JsonStream = new(".\\Utf8JsonStream", FileMode.Create);

    public FromStreamAsync()
    {
        JilHelper.Pack(_testModel, _jilStream);
        MessagePackHelper.Pack(_testModel, _messagePackStream);
        MsgPackHelper.Pack(_testModel, _msgPackStream);
        NewtonsoftJsonHelper.Pack(_testModel, _newtonsoftJsonStream);
        SystemTextJsonHelper.Pack(_testModel, _systemTextJsonStream);
        Utf8JsonHelper.Pack(_testModel, _utf8JsonStream);
    }

    [Benchmark]
    public async Task JilFromStreamAsync() =>
        await JilHelper.FromStreamAsync<TestModel>(_jilStream);

    [Benchmark]
    public async Task MessagePackFromStreamAsync() =>
        await MessagePackHelper.FromStreamAsync<TestModel>(_messagePackStream);

    [Benchmark]
    public async Task MsgPackFromStreamAsync() =>
        await MsgPackHelper.FromStreamAsync<TestModel>(_msgPackStream);

    [Benchmark]
    public async Task NewtonsoftJsonFromStreamAsync() =>
        await NewtonsoftJsonHelper.FromStreamAsync<TestModel>(_newtonsoftJsonStream);

    [Benchmark]
    public async Task SystemTextJsonFromStreamAsync() =>
        await SystemTextJsonHelper.FromStreamAsync<TestModel>(_systemTextJsonStream);

    [Benchmark]
    public async Task Utf8JsonFromStreamAsync() =>
        await Utf8JsonHelper.FromStreamAsync<TestModel>(_utf8JsonStream);
}