using System;
using System.IO;
using System.Xml;
using TestModels;
using Xunit;

namespace Zaabee.Xml.UnitTest
{
    public partial class XmlUnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes();
            var result = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
            
            Assert.Empty(XmlHelper.Serialize(typeof(TestModel),null));
            Assert.Null(XmlHelper.Deserialize<TestModel>((byte[])null));
            Assert.Null(XmlHelper.Deserialize<TestModel>((TextReader)null));
            Assert.Null(XmlHelper.Deserialize<TestModel>((XmlReader)null));
        }
    }
}