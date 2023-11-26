namespace Benchmark.Benchmarks.Text;

public class ToJson
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    [Benchmark]
    public void JilToText() => JilHelper.ToJson(_testModel);

    [Benchmark]
    public void NetJsonToText() => NetJsonHelper.ToJson(_testModel);

    [Benchmark]
    public void NewtonsoftJsonToText() => NewtonsoftJsonHelper.ToJson(_testModel);

    [Benchmark]
    public void SpanJsonToText() => SpanJsonHelper.ToJson(_testModel);

    [Benchmark]
    public void SystemTextJsonToText() => SystemTextJsonHelper.ToJson(_testModel);

    [Benchmark]
    public void Utf8JsonToText() => Utf8JsonHelper.ToJson(_testModel);
}
