namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class ToBytes
{
    private readonly TestModel _testModel = new()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = new DateTime(2017, 1, 1),
        Name = "apple",
        Gender = Gender.Female
    };

    [Benchmark, Obsolete]
    public void BinaryToBytes() => BinaryHelper.ToBytes(_testModel);

    [Benchmark]
    public void DataContractToBytes() => DataContractHelper.ToBytes(_testModel);

    [Benchmark]
    public void JilToBytes() => JilHelper.ToBytes(_testModel);

    [Benchmark]
    public void MemoryPackToBytes() => MemoryPackHelper.ToBytes(_testModel);

    [Benchmark]
    public void MessagePackToBytes() => MessagePackHelper.ToBytes(_testModel);

    [Benchmark]
    public void MsgPackToBytes() => MsgPackHelper.ToBytes(_testModel);

    [Benchmark]
    public void NewtonsoftJsonToBytes() => NewtonsoftJsonHelper.ToBytes(_testModel);

    [Benchmark]
    public void ProtobufToBytes() => ProtobufHelper.ToBytes(_testModel);

    [Benchmark]
    public void SharpYamlToBytes() => SharpYamlHelper.ToBytes(_testModel);

    [Benchmark]
    public void SpanJsonToBytes() => SpanJsonHelper.ToBytes(_testModel);

    [Benchmark]
    public void SystemTextJsonToBytes() => SystemTextJsonHelper.ToBytes(_testModel);

    [Benchmark]
    public void Utf8JsonToBytes() => Utf8JsonHelper.ToBytes(_testModel);

    [Benchmark]
    public void XmlToBytes() => XmlHelper.ToBytes(_testModel);

    [Benchmark]
    public void YamlDotNetToBytes() => YamlDotNetHelper.ToBytes(_testModel);

    [Benchmark]
    public void ZeroFormatterToBytes() => ZeroFormatterHelper.ToBytes(_testModel);
}