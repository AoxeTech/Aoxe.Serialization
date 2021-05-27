using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstraction;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void BinaryBytesStringTest() =>
            BytesStringTest(new Zaabee.Binary.Serializer());

        [Fact]
        public void JilBytesStringTest() =>
            BytesStringTest(new Zaabee.Jil.Serializer());

        [Fact]
        public void MsgPackBytesStringTest() =>
            BytesStringTest(new Zaabee.MsgPack.Serializer());

        [Fact]
        public void NewtonsoftJsonBytesStringTest() =>
            BytesStringTest(new Zaabee.NewtonsoftJson.Serializer());

        [Fact]
        public void ProtobufBytesStringTest() =>
            BytesStringTest(new Zaabee.Protobuf.Serializer());

        [Fact]
        public void SystemTextJsonBytesStringTest() =>
            BytesStringTest(new Zaabee.SystemTextJson.Serializer());

        [Fact]
        public void Utf8JsonBytesStringTest() =>
            BytesStringTest(new Zaabee.Utf8Json.Serializer());

        [Fact]
        public void XmlBytesStringTest() =>
            BytesStringTest(new Zaabee.Xml.Serializer());

        [Fact]
        public void ZeroFormatterBytesStringTest() =>
            BytesStringTest(new Zaabee.ZeroFormatter.Serializer());

        private static void BytesStringTest(ISerializer serializer)
        {
            var model = TestModelFactory.Create();

            var bytes0 = serializer.SerializeToBytes(model);
            var str0 = serializer.SerializeToString(model);

            var bytes1 = serializer.StringToBytes(str0);
            var str1 = serializer.BytesToString(bytes0);

            Assert.True(BytesCompare(bytes0, bytes1));
            Assert.Equal(str0, str1);

            var deserializeModel0 = serializer.DeserializeFromBytes<TestModel>(bytes1);
            var deserializeModel1 = serializer.DeserializeFromString<TestModel>(str1);
            
            Assert.Equal(
                Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
                Tuple.Create(deserializeModel0.Id, deserializeModel0.Age, deserializeModel0.CreateTime,
                    deserializeModel0.Name, deserializeModel0.Gender));
            
            Assert.Equal(
                Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
                Tuple.Create(deserializeModel1.Id, deserializeModel1.Age, deserializeModel1.CreateTime,
                    deserializeModel1.Name, deserializeModel1.Gender));
        }

        private static bool BytesCompare(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
        {
            return a1.SequenceEqual(a2);
        }
    }
}