namespace Zaabee.Serializer.Types.UnitTest;

public class TupleTest
{

    [Fact]
    public void DataContractTupleSerializeTest() =>
        TupleSerializeTest(new DataContractSerializer.Serializer());

    [Fact]
    public void IniTupleSerializeTest() =>
        TupleSerializeTest(new Ini.Serializer());

    [Fact]
    public void JilTupleSerializeTest() =>
        TupleSerializeTest(new Jil.Serializer());

#if !NET48
    [Fact]
    public void MemoryPackTupleSerializeTest() =>
        TupleSerializeTest(new MemoryPack.Serializer());
#endif

    [Fact]
    public void MessagePackTupleSerializeTest() =>
        TupleSerializeTest(new MessagePack.Serializer());

    [Fact]
    public void MsgPackTupleSerializeTest() =>
        TupleSerializeTest(new MsgPack.Serializer());

    [Fact]
    public void NetJsonTupleSerializeTest() =>
        TupleSerializeTest(new NetJson.Serializer());

    [Fact]
    public void NewtonsoftJsonTupleSerializeTest() =>
        TupleSerializeTest(new NewtonsoftJson.Serializer());

    [Fact]
    public void ProtobufTupleSerializeTest() =>
        TupleSerializeTest(new Protobuf.Serializer());

    [Fact]
    public void SharpYamlTupleSerializeTest() =>
        TupleSerializeTest(new SharpYaml.Serializer());

#if !NET48
    [Fact]
    public void SpanJsonTupleSerializeTest() =>
        TupleSerializeTest(new SpanJson.Serializer());
#endif

    [Fact]
    public void SystemTextJsonTupleSerializeTest() =>
        TupleSerializeTest(new SystemTextJson.Serializer());

    [Fact]
    public void TomletTupleSerializeTest() =>
        TupleSerializeTest(new Tomlet.Serializer());

    [Fact]
    public void Utf8JsonTupleSerializeTest() =>
        TupleSerializeTest(new Utf8Json.Serializer());

    [Fact]
    public void XmlTupleSerializeTest() =>
        TupleSerializeTest(new Xml.Serializer());

    [Fact]
    public void YamlDotNetTupleSerializeTest() =>
        TupleSerializeTest(new YamlDotNet.Serializer());

    [Fact]
    public void ZeroFormatterTupleSerializeTest() =>
        TupleSerializeTest(new ZeroFormatter.Serializer());

    private static void TupleSerializeTest(IBytesSerializer bytesSerializer)
    {
        var tupleModel = TupleModel.Instance();

        tupleModel.Tuple = new Tuple<string, string>(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        tupleModel.Tuples = new List<Tuple<string, string>>
        {
            new(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()),
            new(Guid.NewGuid().ToString(), Guid.NewGuid().ToString())
        };
        var result = bytesSerializer.FromBytes<TupleModel>(bytesSerializer.ToBytes(tupleModel))!;
        Assert.Equal(tupleModel.Tuple.Item1, result.Tuple.Item1);
        Assert.Equal(tupleModel.Tuple.Item2, result.Tuple.Item2);
        Assert.Equal(tupleModel.Tuples.Count, result.Tuples.Count);
        Assert.Equal(tupleModel.Tuples[0].Item1, result.Tuples[0].Item1);
        Assert.Equal(tupleModel.Tuples[0].Item2, result.Tuples[0].Item2);
        Assert.Equal(tupleModel.Tuples[1].Item1, result.Tuples[1].Item1);
        Assert.Equal(tupleModel.Tuples[1].Item2, result.Tuples[1].Item2);
    }
}