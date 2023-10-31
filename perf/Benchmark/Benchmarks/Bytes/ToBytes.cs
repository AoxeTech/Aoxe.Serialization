namespace Benchmark.Benchmarks.Bytes;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class ToBytes
{
    private readonly TestModel _testModel = TestModelFactory.Create();

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
    public void NetJsonToBytes() => NetJsonHelper.ToBytes(_testModel);

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