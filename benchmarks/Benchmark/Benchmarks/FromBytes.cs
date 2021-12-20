namespace Benchmark.Benchmarks;

[MemoryDiagnoser]
[SimpleJob()]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class FromBytes
{
    private readonly TestModel _testModel = new()
    {
        Id = Guid.NewGuid(),
        Age = new Random().Next(0, 100),
        CreateTime = new DateTime(2017, 1, 1),
        Name = "apple",
        Gender = Gender.Female
    };

    private readonly byte[] _binaryBytes;
    private readonly byte[] _dataContractBytes;
    private readonly byte[] _jilBytes;
    private readonly byte[] _messagePackBytes;
    private readonly byte[] _msgPackBytes;
    private readonly byte[] _newtonsoftJsonBytes;
    private readonly byte[] _protobufBytes;
    private readonly byte[] _systemTextJsonBytes;
    private readonly byte[] _utf8JsonBytes;
    private readonly byte[] _xmlBytes;
    private readonly byte[] _zeroFormatterBytes;

    public FromBytes()
    {
#pragma warning disable CS0618
        _binaryBytes = BinaryHelper.ToBytes(_testModel);
#pragma warning restore CS0618
        _dataContractBytes = DataContractHelper.ToBytes(_testModel);
        _jilBytes = JilHelper.ToBytes(_testModel);
        _messagePackBytes = MessagePackHelper.ToBytes(_testModel);
        _msgPackBytes = MsgPackHelper.ToBytes(_testModel);
        _newtonsoftJsonBytes = NewtonsoftJsonHelper.ToBytes(_testModel);
        _protobufBytes = ProtobufHelper.ToBytes(_testModel);
        _systemTextJsonBytes = SystemTextJsonHelper.ToBytes(_testModel);
        _utf8JsonBytes = Utf8JsonHelper.ToBytes(_testModel);
        _xmlBytes = XmlHelper.ToBytes(_testModel);
        _zeroFormatterBytes = ZeroFormatterHelper.ToBytes(_testModel);
    }

    [Benchmark,Obsolete]
    public void BinaryFromBytes() => BinaryHelper.FromBytes<TestModel>(_binaryBytes);

    [Benchmark]
    public void DataContractFromBytes() => DataContractHelper.FromBytes<TestModel>(_dataContractBytes);

    [Benchmark]
    public void JilFromBytes() => JilHelper.FromBytes<TestModel>(_jilBytes);

    [Benchmark]
    public void MessagePackFromBytes() => MessagePackHelper.FromBytes<TestModel>(_messagePackBytes);

    [Benchmark]
    public void MsgPackFromBytes() => MsgPackHelper.FromBytes<TestModel>(_msgPackBytes);

    [Benchmark]
    public void NewtonsoftJsonFromBytes() => NewtonsoftJsonHelper.FromBytes<TestModel>(_newtonsoftJsonBytes);

    [Benchmark]
    public void ProtobufFromBytes() => ProtobufHelper.FromBytes<TestModel>(_protobufBytes);

    [Benchmark]
    public void SystemTextJsonFromBytes() => SystemTextJsonHelper.FromBytes<TestModel>(_systemTextJsonBytes);

    [Benchmark]
    public void Utf8JsonFromBytes() => Utf8JsonHelper.FromBytes<TestModel>(_utf8JsonBytes);

    [Benchmark]
    public void XmlFromBytes() => XmlHelper.FromBytes<TestModel>(_xmlBytes);

    [Benchmark]
    public void ZeroFormatterFromBytes() => ZeroFormatterHelper.FromBytes<TestModel>(_zeroFormatterBytes);
}