using System;
using System.IO;
using System.Text;
using System.Xml;
using Xunit;
using Zaabee.Xml;

namespace ZaabeeXmlTestProject
{
    public class UnitTest
    {
        [Fact]
        public void BytesTest()
        {
            var testModel = GetTestModel();
            var bytes = testModel.ToBytes();
            var result = bytes.FromBytes<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
            
            Assert.Empty(XmlSerializer.Serialize(typeof(TestModel),null));
            Assert.Null(XmlSerializer.Deserialize<TestModel>((byte[])null));
            Assert.Null(XmlSerializer.Deserialize<TestModel>((TextReader)null));
            Assert.Null(XmlSerializer.Deserialize<TestModel>((XmlReader)null));
        }

        [Fact]
        public void StreamTest()
        {
            var testModel = GetTestModel();

            var stream1 = testModel.ToStream();
            var stream2 = new MemoryStream();
            testModel.PackTo(stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(testModel);

            var unPackResult1 = stream1.Unpack<TestModel>();
            var unPackResult2 = stream2.Unpack<TestModel>();
            var unPackResult3 = stream3.Unpack<TestModel>();

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));
            
            Assert.Equal(0,XmlSerializer.Pack<TestModel>(null).Length);
            Assert.Null(XmlSerializer.Unpack<TestModel>(null));
            var ms = new MemoryStream();
            XmlSerializer.Pack<TestModel>(null, ms);
            Assert.Equal(0,ms.Length);
            Assert.Equal(0,ms.Position);
        }

        [Fact]
        public void StringTest()
        {
            var testModel = GetTestModel();
            var xml = testModel.ToXml();
            var result = xml.FromXml<TestModel>();
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void BytesNonGenericTest()
        {
            var testModel = GetTestModel();
            var bytes = testModel.ToBytes(typeof(TestModel));
            var result = (TestModel) bytes.FromBytes(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
            
            Assert.Empty(XmlSerializer.Serialize(typeof(TestModel),null));
            Assert.Null(XmlSerializer.Deserialize(typeof(TestModel),(byte[])null));
            Assert.Null(XmlSerializer.Deserialize(typeof(TestModel),(TextReader)null));
            Assert.Null(XmlSerializer.Deserialize(typeof(TestModel),(XmlReader)null));
        }

        [Fact]
        public void StreamNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = GetTestModel();

            var stream1 = testModel.Pack(type);
            var stream2 = new MemoryStream();
            testModel.PackTo(type, stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(type, testModel);

            var unPackResult1 = (TestModel) stream1.Unpack(type);
            var unPackResult2 = (TestModel) stream2.Unpack(type);
            var unPackResult3 = (TestModel) stream3.Unpack(type);

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));

            TestModel nullModel = null;
            var streamNull = nullModel.Pack(typeof(TestModel));
            Assert.Equal(0,streamNull.Length);
            Assert.Equal(0,streamNull.Position);
            
            Assert.Null(XmlSerializer.Unpack(typeof(TestModel),null));
            var ms = new MemoryStream();
            XmlSerializer.Pack(typeof(TestModel),null, ms);
            Assert.Equal(0,ms.Length);
            Assert.Equal(0,ms.Position);
        }

        [Fact]
        public void StringNonGenericTest()
        {
            var testModel = GetTestModel();
            var xml = testModel.ToXml(typeof(TestModel));
            var result = (TestModel) xml.FromXml(typeof(TestModel));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));

            TestModel nullTestModel = null;
            Assert.Equal(string.Empty,nullTestModel.ToXml());
            string str = null;
            Assert.Null(str.FromXml(typeof(TestModel)));
        }

        [Fact]
        public void TextWriterReaderTest()
        {
            var testModel = GetTestModel();
            TestModel result;
            using (var fs = new FileStream("TextWriterReaderTest.xml", FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.UTF8);
                testModel.ToXml(writer);
                writer.Close();
            }

            using (var fs = new FileStream("TextWriterReaderTest.xml", FileMode.Open))
            {
                var reader = new StreamReader(fs, Encoding.UTF8);
                result = reader.FromXml<TestModel>();
                reader.Close();
            }

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void TextWriterReaderNonGenericTest()
        {
            var testModel = GetTestModel();
            TestModel result;
            using (var fs = new FileStream("TextWriterReaderNonGenericTest.xml", FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.UTF8);
                testModel.ToXml(typeof(TestModel), writer);
                writer.Close();
            }

            using (var fs = new FileStream("TextWriterReaderNonGenericTest.xml", FileMode.Open))
            {
                var reader = new StreamReader(fs, Encoding.UTF8);
                result = (TestModel) reader.FromXml(typeof(TestModel));
                reader.Close();
            }

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void XmlWriterReaderTest()
        {
            var testModel = GetTestModel();
            TestModel result;
            using (var fs = new FileStream("XmlWriterReaderTest.xml", FileMode.Create))
            {
                var writer = new XmlTextWriter(fs, Encoding.UTF8);
                testModel.ToXml(writer);
                writer.Close();
            }

            using (var fs = new FileStream("XmlWriterReaderTest.xml", FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                result = reader.FromXml<TestModel>();
                reader.Close();
            }

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        [Fact]
        public void XmlWriterReaderNonGenericTest()
        {
            var testModel = GetTestModel();
            TestModel result;
            using (var fs = new FileStream("XmlWriterReaderNonGenericTest.xml", FileMode.Create))
            {
                var writer = new XmlTextWriter(fs, Encoding.UTF8);
                testModel.ToXml(typeof(TestModel), writer);
                writer.Close();
            }

            using (var fs = new FileStream("XmlWriterReaderNonGenericTest.xml", FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                result = (TestModel) reader.FromXml(typeof(TestModel));
                reader.Close();
            }

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result.Id, result.Age, result.CreateTime, result.Name, result.Gender));
        }

        private static TestModel GetTestModel()
        {
            return new TestModel
            {
                Id = Guid.NewGuid(),
                Age = new Random().Next(0, 100),
                CreateTime = new DateTime(2017, 1, 1).ToUniversalTime(),
                Name = "apple",
                Gender = Gender.Female
            };
        }
    }
}