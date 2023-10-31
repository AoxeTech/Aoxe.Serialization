namespace Benchmark.Benchmarks.Text;

public class ToToml
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    [Benchmark]
    public void TomlynToText() => TomlynHelper.ToToml(_testModel);
}