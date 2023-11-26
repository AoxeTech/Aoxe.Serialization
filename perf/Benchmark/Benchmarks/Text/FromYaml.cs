namespace Benchmark.Benchmarks.Text;

public class FromYaml
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly string _sharpYaml;
    private readonly string _yamlDotNet;

    public FromYaml()
    {
        _sharpYaml = SharpYamlHelper.ToYaml(_testModel);
        _yamlDotNet = YamlDotNetHelper.ToYaml(_testModel);
    }

    [Benchmark]
    public void SharpYamlFromText() => SharpYamlHelper.FromYaml<TestModel>(_sharpYaml);

    [Benchmark]
    public void YamlDotNetFromText() => YamlDotNetHelper.FromYaml<TestModel>(_yamlDotNet);
}
