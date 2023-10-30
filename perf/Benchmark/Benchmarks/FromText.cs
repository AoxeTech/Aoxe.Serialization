namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class FromText
{
    private readonly TestModel _testModel = new()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = new DateTime(2017, 1, 1),
        Name = "apple",
        Gender = Gender.Female
    };

    private readonly string _dataContract;
    private readonly string _jil;
    private readonly string _netJson;
    private readonly string _newtonsoftJson;
    private readonly string _sharpYaml;
    private readonly string _spanJson;
    private readonly string _systemTextJson;
    private readonly string _utf8Json;
    private readonly string _xml;
    private readonly string _yamlDotNet;

    public FromText()
    {
        _dataContract = DataContractHelper.ToXml(_testModel);
        _jil = JilHelper.ToJson(_testModel);
        _netJson = NetJsonHelper.ToJson(_testModel);
        _newtonsoftJson = NewtonsoftJsonHelper.ToJson(_testModel);
        _sharpYaml = SharpYamlHelper.ToYaml(_testModel);
        _spanJson = SpanJsonHelper.ToJson(_testModel);
        _systemTextJson = SystemTextJsonHelper.ToJson(_testModel);
        _utf8Json = Utf8JsonHelper.ToJson(_testModel);
        _xml = XmlHelper.ToXml(_testModel);
        _yamlDotNet = YamlDotNetHelper.ToYaml(_testModel);
    }

    [Benchmark]
    public void DataContractFromText() => DataContractHelper.FromXml<TestModel>(_dataContract);

    [Benchmark]
    public void JilFromText() => JilHelper.FromJson<TestModel>(_jil);

    [Benchmark]
    public void NetJsonFromText() => NetJsonHelper.FromJson<TestModel>(_netJson);

    [Benchmark]
    public void NewtonsoftJsonFromText() => NewtonsoftJsonHelper.FromJson<TestModel>(_newtonsoftJson);

    [Benchmark]
    public void SharpYamlFromText() => SharpYamlHelper.FromYaml<TestModel>(_sharpYaml);

    [Benchmark]
    public void SpanJsonFromText() => SpanJsonHelper.FromJson<TestModel>(_spanJson);

    [Benchmark]
    public void SystemTextJsonFromText() => SystemTextJsonHelper.FromJson<TestModel>(_systemTextJson);

    [Benchmark]
    public void Utf8JsonFromText() => Utf8JsonHelper.FromJson<TestModel>(_utf8Json);

    [Benchmark]
    public void XmlFromText() => XmlHelper.FromXml<TestModel>(_xml);

    [Benchmark]
    public void YamlDotNetFromText() => YamlDotNetHelper.FromYaml<TestModel>(_yamlDotNet);
}