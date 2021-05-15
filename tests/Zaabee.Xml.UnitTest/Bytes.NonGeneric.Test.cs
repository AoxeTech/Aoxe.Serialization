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
        public void BytesNonGenericTest()
        {
            var testModel = TestModelFactory.Create();
            var bytes = testModel.ToBytes(typeof(TestModel));
            var result = (TestModel) bytes.FromBytes(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
            
            Assert.Empty(XmlHelper.Serialize(typeof(TestModel),null));
            Assert.Null(XmlHelper.Deserialize(typeof(TestModel),(byte[])null));
            Assert.Null(XmlHelper.Deserialize(typeof(TestModel),(TextReader)null));
            Assert.Null(XmlHelper.Deserialize(typeof(TestModel),(XmlReader)null));
        }
    }
}