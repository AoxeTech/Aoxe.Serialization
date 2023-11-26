namespace Benchmark.Benchmarks.Text;

public class ToYaml
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    [Benchmark]
    public void SharpYamlToText() => SharpYamlHelper.ToYaml(_testModel);

    [Benchmark]
    public void YamlDotNetToText() => YamlDotNetHelper.ToYaml(_testModel);
}
