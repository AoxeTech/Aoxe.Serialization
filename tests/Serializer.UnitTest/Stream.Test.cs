using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstractions;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void BinaryStreamTest() =>
            StreamTest(new Zaabee.Binary.ZaabeeSerializer());

        [Fact]
        public void JilStreamTest() =>
            StreamTest(new Zaabee.Jil.ZaabeeSerializer());

        [Fact]
        public void MessagePackStreamTest() =>
            StreamTest(new Zaabee.MessagePack.ZaabeeSerializer());

        [Fact]
        public void MsgPackStreamTest() =>
            StreamTest(new Zaabee.MsgPack.ZaabeeSerializer());

        [Fact]
        public void NewtonsoftJsonStreamTest() =>
            StreamTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

        [Fact]
        public void ProtobufStreamTest() =>
            StreamTest(new Zaabee.Protobuf.ZaabeeSerializer());

        [Fact]
        public void SystemTextJsonStreamTest() =>
            StreamTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

        [Fact]
        public void Utf8JsonStreamTest() =>
            StreamTest(new Zaabee.Utf8Json.ZaabeeSerializer());

        [Fact]
        public void XmlStreamTest() =>
            StreamTest(new Zaabee.Xml.ZaabeeSerializer());

        [Fact]
        public void ZeroFormatterStreamTest() =>
            StreamTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

        private static void StreamTest(IStreamSerializer serializer)
        {
            var model = TestModelFactory.Create();
            var bytes = serializer.SerializeToStream(model);
            var deserializeModel = serializer.DeserializeFromStream<TestModel>(bytes);

            Assert.Equal(
                Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
                Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                    deserializeModel.Name, deserializeModel.Gender));
        }
    }
}