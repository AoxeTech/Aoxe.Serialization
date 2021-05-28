using System;
using TestModels;
using Xunit;
using Zaabee.Serializer.Abstractions;

namespace Serializer.UnitTest
{
    public partial class SerializerTest
    {
        [Fact]
        public void BinaryStringTest() =>
            StringTest(new Zaabee.Binary.Serializer());

        [Fact]
        public void JilStringTest() =>
            StringTest(new Zaabee.Jil.Serializer());

        [Fact]
        public void MsgPackStringTest() =>
            StringTest(new Zaabee.MsgPack.Serializer());

        [Fact]
        public void NewtonsoftJsonStringTest() =>
            StringTest(new Zaabee.NewtonsoftJson.Serializer());

        [Fact]
        public void ProtobufStringTest() =>
            StringTest(new Zaabee.Protobuf.Serializer());

        [Fact]
        public void SystemTextJsonStringTest() =>
            StringTest(new Zaabee.SystemTextJson.Serializer());

        [Fact]
        public void Utf8JsonStringTest() =>
            StringTest(new Zaabee.Utf8Json.Serializer());

        [Fact]
        public void XmlStringTest() =>
            StringTest(new Zaabee.Xml.Serializer());

        [Fact]
        public void ZeroFormatterStringTest() =>
            StringTest(new Zaabee.ZeroFormatter.Serializer());

        private static void StringTest(IStringSerializer serializer)
        {
            var model = TestModelFactory.Create();
            var bytes = serializer.SerializeToString(model);
            var deserializeModel = serializer.DeserializeFromString<TestModel>(bytes);

            Assert.Equal(
                Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
                Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                    deserializeModel.Name, deserializeModel.Gender));
        }
    }
}