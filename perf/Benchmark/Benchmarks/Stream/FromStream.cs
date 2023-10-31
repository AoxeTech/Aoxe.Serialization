namespace Benchmark.Benchmarks.Stream;

[MemoryDiagnoser]
[SimpleJob]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class FromStream
{
    private readonly TestModel _testModel = TestModelFactory.Create();

    private readonly System.IO.Stream _dataContractStream;
    private readonly System.IO.Stream _jilStream;
    private readonly System.IO.Stream _memoryPackStream;
    private readonly System.IO.Stream _messagePackStream;
    private readonly System.IO.Stream _msgPackStream;
    private readonly System.IO.Stream _newtonsoftJsonStream;
    private readonly System.IO.Stream _netJsonStream;
    private readonly System.IO.Stream _protobufStream;
    private readonly System.IO.Stream _sharpYamlStream;
    private readonly System.IO.Stream _spanJsonStream;
    private readonly System.IO.Stream _systemTextJsonStream;
    private readonly System.IO.Stream _utf8JsonStream;
    private readonly System.IO.Stream _xmlStream;
    private readonly System.IO.Stream _yamlDotNetStream;
    private readonly System.IO.Stream _zeroFormatterStream;

    public FromStream()
    {
        _dataContractStream = DataContractHelper.ToStream(_testModel);
        _jilStream = JilHelper.ToStream(_testModel);
        _memoryPackStream = MemoryPackHelper.ToStream(_testModel);
        _messagePackStream = MessagePackHelper.ToStream(_testModel);
        _msgPackStream = MsgPackHelper.ToStream(_testModel);
        _netJsonStream = NetJsonHelper.ToStream(_testModel);
        _newtonsoftJsonStream = NewtonsoftJsonHelper.ToStream(_testModel);
        _protobufStream = ProtobufHelper.ToStream(_testModel);
        _sharpYamlStream = SharpYamlHelper.ToStream(_testModel);
        _spanJsonStream = SpanJsonHelper.ToStream(_testModel);
        _systemTextJsonStream = SystemTextJsonHelper.ToStream(_testModel);
        _utf8JsonStream = Utf8JsonHelper.ToStream(_testModel);
        _xmlStream = XmlHelper.ToStream(_testModel);
        _yamlDotNetStream = YamlDotNetHelper.ToStream(_testModel);
        _zeroFormatterStream = ZeroFormatterHelper.ToStream(_testModel);
    }

    [Benchmark]
    public void DataContractFromStream() => DataContractHelper.FromStream<TestModel>(_dataContractStream);

    [Benchmark]
    public void JilFromStream() => JilHelper.FromStream<TestModel>(_jilStream);

    [Benchmark]
    public void MemoryPackFromStream() => MemoryPackHelper.FromStream<TestModel>(_memoryPackStream);
    
    [Benchmark]
    public void MessagePackFromStream() => MessagePackHelper.FromStream<TestModel>(_messagePackStream);

    [Benchmark]
    public void MsgPackFromStream() => MsgPackHelper.FromStream<TestModel>(_msgPackStream);

    [Benchmark]
    public void NetJsonFromStream() => NetJsonHelper.FromStream<TestModel>(_netJsonStream);

    [Benchmark]
    public void NewtonsoftJsonFromStream() => NewtonsoftJsonHelper.FromStream<TestModel>(_newtonsoftJsonStream);

    [Benchmark]
    public void ProtobufFromStream() => ProtobufHelper.FromStream<TestModel>(_protobufStream);

    [Benchmark]
    public void SharpYamlFromStream() => SharpYamlHelper.FromStream<TestModel>(_sharpYamlStream);

    [Benchmark]
    public void SpanJsonFromStream() => SpanJsonHelper.FromStream<TestModel>(_spanJsonStream);

    [Benchmark]
    public void SystemTextJsonFromStream() => SystemTextJsonHelper.FromStream<TestModel>(_systemTextJsonStream);

    [Benchmark]
    public void Utf8JsonFromStream() => Utf8JsonHelper.FromStream<TestModel>(_utf8JsonStream);

    [Benchmark]
    public void XmlFromStream() => XmlHelper.FromStream<TestModel>(_xmlStream);

    [Benchmark]
    public void YamlDotNetFromStream() => YamlDotNetHelper.FromStream<TestModel>(_yamlDotNetStream);

    [Benchmark]
    public void ZeroFormatterFromStream() => ZeroFormatterHelper.FromStream<TestModel>(_zeroFormatterStream);
}