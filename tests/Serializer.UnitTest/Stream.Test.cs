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
            StreamTest(new Zaabee.Binary.Serializer());

        [Fact]
        public void JilStreamTest() =>
            StreamTest(new Zaabee.Jil.Serializer());

        [Fact]
        public void MessagePackStreamTest() =>
            StreamTest(new Zaabee.MessagePack.Serializer());

        [Fact]
        public void MsgPackStreamTest() =>
            StreamTest(new Zaabee.MsgPack.Serializer());

        [Fact]
        public void NewtonsoftJsonStreamTest() =>
            StreamTest(new Zaabee.NewtonsoftJson.Serializer());

        [Fact]
        public void ProtobufStreamTest() =>
            StreamTest(new Zaabee.Protobuf.Serializer());

        [Fact]
        public void SystemTextJsonStreamTest() =>
            StreamTest(new Zaabee.SystemTextJson.Serializer());

        [Fact]
        public void Utf8JsonStreamTest() =>
            StreamTest(new Zaabee.Utf8Json.Serializer());

        [Fact]
        public void XmlStreamTest() =>
            StreamTest(new Zaabee.Xml.Serializer());

        [Fact]
        public void ZeroFormatterStreamTest() =>
            StreamTest(new Zaabee.ZeroFormatter.Serializer());

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