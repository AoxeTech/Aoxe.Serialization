namespace Benchmark.Benchmarks.Text;

public class FromToml
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly string _tomlyn;

    public FromToml()
    {
        _tomlyn = TomlynHelper.ToToml(_testModel);
    }

    [Benchmark]
    public void TomlynFromText() => TomlynHelper.FromToml<TestModel>(_tomlyn);
}
