namespace Benchmark.Benchmarks.Text;

public class FromJson
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly string _jil;
    private readonly string _netJson;
    private readonly string _newtonsoftJson;
    private readonly string _spanJson;
    private readonly string _systemTextJson;
    private readonly string _utf8Json;

    public FromJson()
    {
        _jil = JilHelper.ToJson(_testModel);
        _netJson = NetJsonHelper.ToJson(_testModel);
        _newtonsoftJson = NewtonsoftJsonHelper.ToJson(_testModel);
        _spanJson = SpanJsonHelper.ToJson(_testModel);
        _systemTextJson = SystemTextJsonHelper.ToJson(_testModel);
        _utf8Json = Utf8JsonHelper.ToJson(_testModel);
    }

    [Benchmark]
    public void JilFromText() => JilHelper.FromJson<TestModel>(_jil);

    [Benchmark]
    public void NetJsonFromText() => NetJsonHelper.FromJson<TestModel>(_netJson);

    [Benchmark]
    public void NewtonsoftJsonFromText() => NewtonsoftJsonHelper.FromJson<TestModel>(_newtonsoftJson);

    [Benchmark]
    public void SpanJsonFromText() => SpanJsonHelper.FromJson<TestModel>(_spanJson);

    [Benchmark]
    public void SystemTextJsonFromText() => SystemTextJsonHelper.FromJson<TestModel>(_systemTextJson);

    [Benchmark]
    public void Utf8JsonFromText() => Utf8JsonHelper.FromJson<TestModel>(_utf8Json);
}