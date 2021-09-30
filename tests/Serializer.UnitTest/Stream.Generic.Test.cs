using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstractions;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void BinaryStreamGenericTest() =>
            StreamGenericTest(new Zaabee.Binary.ZaabeeSerializer());

        [Fact]
        public void JilStreamGenericTest() =>
            StreamGenericTest(new Zaabee.Jil.ZaabeeSerializer());

        [Fact]
        public void MessagePackStreamGenericTest() =>
            StreamGenericTest(new Zaabee.MessagePack.ZaabeeSerializer());

        [Fact]
        public void MsgPackStreamGenericTest() =>
            StreamGenericTest(new Zaabee.MsgPack.ZaabeeSerializer());

        [Fact]
        public void NewtonsoftJsonStreamGenericTest() =>
            StreamGenericTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

        [Fact]
        public void ProtobufStreamGenericTest() =>
            StreamGenericTest(new Zaabee.Protobuf.ZaabeeSerializer());

        [Fact]
        public void SystemTextJsonStreamGenericTest() =>
            StreamGenericTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

        [Fact]
        public void Utf8JsonStreamGenericTest() =>
            StreamGenericTest(new Zaabee.Utf8Json.ZaabeeSerializer());

        [Fact]
        public void XmlStreamGenericTest() =>
            StreamGenericTest(new Zaabee.Xml.ZaabeeSerializer());

        [Fact]
        public void ZeroFormatterStreamGenericTest() =>
            StreamGenericTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

        private static void StreamGenericTest(IStreamSerializer serializer)
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