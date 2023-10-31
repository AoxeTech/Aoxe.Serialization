namespace Benchmark.Benchmarks.Stream;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class ToStream
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    [Benchmark]
    public void DataContractToStream() => DataContractHelper.ToStream(_testModel);

    [Benchmark]
    public void JilToStream() => JilHelper.ToStream(_testModel);

    [Benchmark]
    public void MemoryPackToStream() => MemoryPackHelper.ToStream(_testModel);

    [Benchmark]
    public void MessagePackToStream() => MessagePackHelper.ToStream(_testModel);

    [Benchmark]
    public void MsgPackToStream() => MsgPackHelper.ToStream(_testModel);

    [Benchmark]
    public void NetJsonToStream() => NetJsonHelper.ToStream(_testModel);

    [Benchmark]
    public void NewtonsoftJsonToStream() => NewtonsoftJsonHelper.ToStream(_testModel);

    [Benchmark]
    public void ProtobufToStream() => ProtobufHelper.ToStream(_testModel);

    [Benchmark]
    public void SharpYamlToStream() => SharpYamlHelper.ToStream(_testModel);

    [Benchmark]
    public void SpanJsonToStream() => SpanJsonHelper.ToStream(_testModel);

    [Benchmark]
    public void SystemTextJsonToStream() => SystemTextJsonHelper.ToStream(_testModel);

    [Benchmark]
    public void Utf8JsonToStream() => Utf8JsonHelper.ToStream(_testModel);

    [Benchmark]
    public void XmlToStream() => XmlHelper.ToStream(_testModel);

    [Benchmark]
    public void YamlDotNetToStream() => YamlDotNetHelper.ToStream(_testModel);

    [Benchmark]
    public void ZeroFormatterToStream() => ZeroFormatterHelper.ToStream(_testModel);
}