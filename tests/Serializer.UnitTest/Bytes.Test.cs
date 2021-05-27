using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstraction;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void BinaryBytesTest() =>
            BytesTest(new Zaabee.Binary.Serializer());

        [Fact]
        public void JilBytesTest() =>
            BytesTest(new Zaabee.Jil.Serializer());

        [Fact]
        public void MsgPackBytesTest() =>
            BytesTest(new Zaabee.MsgPack.Serializer());

        [Fact]
        public void NewtonsoftJsonBytesTest() =>
            BytesTest(new Zaabee.NewtonsoftJson.Serializer());

        [Fact]
        public void ProtobufBytesTest() =>
            BytesTest(new Zaabee.Protobuf.Serializer());

        [Fact]
        public void SystemTextJsonBytesTest() =>
            BytesTest(new Zaabee.SystemTextJson.Serializer());

        [Fact]
        public void Utf8JsonBytesTest() =>
            BytesTest(new Zaabee.Utf8Json.Serializer());

        [Fact]
        public void XmlBytesTest() =>
            BytesTest(new Zaabee.Xml.Serializer());

        [Fact]
        public void ZeroFormatterBytesTest() =>
            BytesTest(new Zaabee.ZeroFormatter.Serializer());

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