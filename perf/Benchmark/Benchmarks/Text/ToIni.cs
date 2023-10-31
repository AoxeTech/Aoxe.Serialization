namespace Benchmark.Benchmarks.Text;

public class ToIni
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    [Benchmark]
    public void IniParserToText() => IniParserHelper.ToIni(_testModel);
}