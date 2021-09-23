using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstractions;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void BinaryBytesTest() =>
            BytesTest(new Zaabee.Binary.ZaabeeSerializer());

        [Fact]
        public void JilBytesTest() =>
            BytesTest(new Zaabee.Jil.ZaabeeSerializer());

        [Fact]
        public void MessagePackBytesTest() =>
            BytesTest(new Zaabee.MessagePack.ZaabeeSerializer());

        [Fact]
        public void MsgPackBytesTest() =>
            BytesTest(new Zaabee.MsgPack.ZaabeeSerializer());

        [Fact]
        public void NewtonsoftJsonBytesTest() =>
            BytesTest(new Zaabee.NewtonsoftJson.ZaabeeSerializer());

        [Fact]
        public void ProtobufBytesTest() =>
            BytesTest(new Zaabee.Protobuf.ZaabeeSerializer());

        [Fact]
        public void SystemTextJsonBytesTest() =>
            BytesTest(new Zaabee.SystemTextJson.ZaabeeSerializer());

        [Fact]
        public void Utf8JsonBytesTest() =>
            BytesTest(new Zaabee.Utf8Json.ZaabeeSerializer());

        [Fact]
        public void XmlBytesTest() =>
            BytesTest(new Zaabee.Xml.ZaabeeSerializer());

        [Fact]
        public void ZeroFormatterBytesTest() =>
            BytesTest(new Zaabee.ZeroFormatter.ZaabeeSerializer());

        private static void BytesTest(IBytesSerializer serializer)
        {
            var model = TestModelFactory.Create();
            var bytes = serializer.SerializeToBytes(model);
            var deserializeModel = serializer.DeserializeFromBytes<TestModel>(bytes);

            Assert.Equal(
                Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
                Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                    deserializeModel.Name, deserializeModel.Gender));
        }
    }
}