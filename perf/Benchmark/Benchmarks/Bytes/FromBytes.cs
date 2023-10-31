namespace Benchmark.Benchmarks.Bytes;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class FromBytes
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly byte[] _dataContractBytes;
    private readonly byte[] _jilBytes;
    private readonly byte[] _memoryPackBytes;
    private readonly byte[] _messagePackBytes;
    private readonly byte[] _msgPackBytes;
    private readonly byte[] _netJsonBytes;
    private readonly byte[] _newtonsoftJsonBytes;
    private readonly byte[] _protobufBytes;
    private readonly byte[] _sharpYamlBytes;
    private readonly byte[] _spanJsonBytes;
    private readonly byte[] _systemTextJsonBytes;
    private readonly byte[] _utf8JsonBytes;
    private readonly byte[] _xmlBytes;
    private readonly byte[] _yamlDotNet;
    private readonly byte[] _zeroFormatterBytes;

    public FromBytes()
    {
        _dataContractBytes = DataContractHelper.ToBytes(_testModel);
        _jilBytes = JilHelper.ToBytes(_testModel);
        _memoryPackBytes = MemoryPackHelper.ToBytes(_testModel);
        _messagePackBytes = MessagePackHelper.ToBytes(_testModel);
        _msgPackBytes = MsgPackHelper.ToBytes(_testModel);
        _netJsonBytes = NetJsonHelper.ToBytes(_testModel);
        _newtonsoftJsonBytes = NewtonsoftJsonHelper.ToBytes(_testModel);
        _protobufBytes = ProtobufHelper.ToBytes(_testModel);
        _sharpYamlBytes = SharpYamlHelper.ToBytes(_testModel);
        _spanJsonBytes = SpanJsonHelper.ToBytes(_testModel);
        _systemTextJsonBytes = SystemTextJsonHelper.ToBytes(_testModel);
        _utf8JsonBytes = Utf8JsonHelper.ToBytes(_testModel);
        _xmlBytes = XmlHelper.ToBytes(_testModel);
        _yamlDotNet = YamlDotNetHelper.ToBytes(_testModel);
        _zeroFormatterBytes = ZeroFormatterHelper.ToBytes(_testModel);
    }

    [Benchmark]
    public void DataContractFromBytes() => DataContractHelper.FromBytes<TestModel>(_dataContractBytes);

    [Benchmark]
    public void JilFromBytes() => JilHelper.FromBytes<TestModel>(_jilBytes);
    
    [Benchmark]
    public void MemoryPackFromBytes() => MemoryPackHelper.FromBytes<TestModel>(_memoryPackBytes);

    [Benchmark]
    public void MessagePackFromBytes() => MessagePackHelper.FromBytes<TestModel>(_messagePackBytes);

    [Benchmark]
    public void MsgPackFromBytes() => MsgPackHelper.FromBytes<TestModel>(_msgPackBytes);

    [Benchmark]
    public void NetJsonFromBytes() => NetJsonHelper.FromBytes<TestModel>(_netJsonBytes);

    [Benchmark]
    public void NewtonsoftJsonFromBytes() => NewtonsoftJsonHelper.FromBytes<TestModel>(_newtonsoftJsonBytes);

    [Benchmark]
    public void ProtobufFromBytes() => ProtobufHelper.FromBytes<TestModel>(_protobufBytes);

    [Benchmark]
    public void SharpYamlFromBytes() => SharpYamlHelper.FromBytes<TestModel>(_sharpYamlBytes);

    [Benchmark]
    public void SpanJsonFromBytes() => SpanJsonHelper.FromBytes<TestModel>(_spanJsonBytes);

    [Benchmark]
    public void SystemTextJsonFromBytes() => SystemTextJsonHelper.FromBytes<TestModel>(_systemTextJsonBytes);

    [Benchmark]
    public void Utf8JsonFromBytes() => Utf8JsonHelper.FromBytes<TestModel>(_utf8JsonBytes);

    [Benchmark]
    public void XmlFromBytes() => XmlHelper.FromBytes<TestModel>(_xmlBytes);

    [Benchmark]
    public void YamlDotNetFromBytes() => YamlDotNetHelper.FromBytes<TestModel>(_yamlDotNet);

    [Benchmark]
    public void ZeroFormatterFromBytes() => ZeroFormatterHelper.FromBytes<TestModel>(_zeroFormatterBytes);
}