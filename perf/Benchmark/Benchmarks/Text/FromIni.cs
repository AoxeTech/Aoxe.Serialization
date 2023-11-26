namespace Benchmark.Benchmarks.Text;

public class FromIni
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly string _ini;

    public FromIni()
    {
        _ini = IniParserHelper.ToIni(_testModel);
    }

    [Benchmark]
    public void IniParserFromText() => IniParserHelper.FromIni<TestModel>(_ini);
}
