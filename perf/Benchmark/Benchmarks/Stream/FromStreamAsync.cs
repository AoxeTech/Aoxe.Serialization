namespace Benchmark.Benchmarks.Stream;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class FromStreamAsync
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly FileStream _jilStream = new(".\\JilStream", FileMode.Create);
    private readonly FileStream _memoryPackStream = new(".\\MemoryPackStream", FileMode.Create);
    private readonly FileStream _messagePackStream = new(".\\MessagePackStream", FileMode.Create);
    private readonly FileStream _msgPackStream = new(".\\MsgPackStream", FileMode.Create);
    private readonly FileStream _newtonsoftJsonStream = new(".\\NewtonsoftJsonStream", FileMode.Create);
    private readonly FileStream _netJsonStream = new(".\\NetJsonStream", FileMode.Create);
    private readonly FileStream _spanJsonStream = new (".\\SpanJsonStream", FileMode.Create);
    private readonly FileStream _systemTextJsonStream = new(".\\SystemTextJsonStream", FileMode.Create);
    private readonly FileStream _utf8JsonStream = new(".\\Utf8JsonStream", FileMode.Create);

    public FromStreamAsync()
    {
        JilHelper.Pack(_testModel, _jilStream);
        MemoryPackHelper.Pack(_testModel, _memoryPackStream);
        MessagePackHelper.Pack(_testModel, _messagePackStream);
        MsgPackHelper.Pack(_testModel, _msgPackStream);
        NetJsonHelper.Pack(_testModel, _netJsonStream);
        NewtonsoftJsonHelper.Pack(_testModel, _newtonsoftJsonStream);
        SpanJsonHelper.Pack(_testModel, _spanJsonStream);
        SystemTextJsonHelper.Pack(_testModel, _systemTextJsonStream);
        Utf8JsonHelper.Pack(_testModel, _utf8JsonStream);
    }

    [Benchmark]
    public async Task JilFromStreamAsync() =>
        await JilHelper.FromStreamAsync<TestModel>(_jilStream);

    [Benchmark]
    public async Task MemoryPackFromStreamAsync() =>
        await MemoryPackHelper.FromStreamAsync<TestModel>(_memoryPackStream);
    
    [Benchmark]
    public async Task MessagePackFromStreamAsync() =>
        await MessagePackHelper.FromStreamAsync<TestModel>(_messagePackStream);

    [Benchmark]
    public async Task MsgPackFromStreamAsync() =>
        await MsgPackHelper.FromStreamAsync<TestModel>(_msgPackStream);

    [Benchmark]
    public async Task NetJsonFromStreamAsync() =>
        await NetJsonHelper.FromStreamAsync<TestModel>(_netJsonStream);

    [Benchmark]
    public async Task NewtonsoftJsonFromStreamAsync() =>
        await NewtonsoftJsonHelper.FromStreamAsync<TestModel>(_newtonsoftJsonStream);

    [Benchmark]
    public async Task SpanJsonFromStreamAsync() =>
        await SpanJsonHelper.FromStreamAsync<TestModel>(_spanJsonStream);

    [Benchmark]
    public async Task SystemTextJsonFromStreamAsync() =>
        await SystemTextJsonHelper.FromStreamAsync<TestModel>(_systemTextJsonStream);

    [Benchmark]
    public async Task Utf8JsonFromStreamAsync() =>
        await Utf8JsonHelper.FromStreamAsync<TestModel>(_utf8JsonStream);
}