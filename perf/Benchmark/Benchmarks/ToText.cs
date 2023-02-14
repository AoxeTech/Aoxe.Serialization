namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class ToText
{
    private readonly TestModel _testModel = new()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = new DateTime(2017, 1, 1),
        Name = "apple",
        Gender = Gender.Female
    };

    [Benchmark]
    public void DataContractToText() => DataContractHelper.ToXml(_testModel);

    [Benchmark]
    public void JilToText() => JilHelper.ToJson(_testModel);

    [Benchmark]
    public void NewtonsoftJsonToText() => NewtonsoftJsonHelper.ToJson(_testModel);

    [Benchmark]
    public void SharpYamlToText() => SharpYamlHelper.ToYaml(_testModel);

    [Benchmark]
    public void SystemTextJsonToText() => SystemTextJsonHelper.ToJson(_testModel);

    [Benchmark]
    public void Utf8JsonToText() => Utf8JsonHelper.ToJson(_testModel);

    [Benchmark]
    public void XmlToText() => XmlHelper.ToXml(_testModel);

    [Benchmark]
    public void YamlDotNetToText() => YamlDotNetHelper.ToYaml(_testModel);
}