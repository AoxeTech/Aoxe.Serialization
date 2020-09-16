using System;
using System.IO;
using System.Text;
using System.Xml;
using Xunit;

namespace Zaabee.Xml.UnitTest
{
    public class UnitTest
    {
        public UnitTest()
        {
            XmlHelper.DefaultEncoding = Encoding.UTF8;
        }

        [Fact]
        public void BytesTest()
        {
            var testModel = GetTestModel();
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
            
            Assert.Equal(0,XmlHelper.Pack<TestModel>(null).Length);
            Assert.Null(XmlHelper.Unpack<TestModel>(null));
            var ms = new MemoryStream();
            XmlHelper.Pack<TestModel>(null, ms);
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
            
            Assert.Empty(XmlHelper.Serialize(typeof(TestModel),null));
            Assert.Null(XmlHelper.Deserialize(typeof(TestModel),(byte[])null));
            Assert.Null(XmlHelper.Deserialize(typeof(TestModel),(TextReader)null));
            Assert.Null(XmlHelper.Deserialize(typeof(TestModel),(XmlReader)null));
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
            
            Assert.Null(XmlHelper.Unpack(typeof(TestModel),null));
            var ms = new MemoryStream();
            XmlHelper.Pack(typeof(TestModel),null, ms);
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

            string str = null;
            Assert.Null(str.FromXml(typeof(TestModel)));
        }

        [Fact]
        public void TextWriterReaderTest()
        {
            var testModel = GetTestModel();
            TestModel result0;
            using (var fs = new FileStream("TextWriterReaderTest0.xml", FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.UTF8);
                writer.WriteXml(testModel);
                writer.Close();
            }
            using (var fs = new FileStream("TextWriterReaderTest0.xml", FileMode.Open))
            {
                var reader = new StreamReader(fs, Encoding.UTF8);
                result0 = reader.ReadXml<TestModel>();
                reader.Close();
            }

            TestModel result1;
            using (var fs = new FileStream("TextWriterReaderTest1.xml", FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.UTF8);
                testModel.ToXml(writer);
                writer.Close();
            }
            using (var fs = new FileStream("TextWriterReaderTest1.xml", FileMode.Open))
            {
                var reader = new StreamReader(fs, Encoding.UTF8);
                result1 = reader.ReadXml<TestModel>();
                reader.Close();
            }
            
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));
            
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));
        }

        [Fact]
        public void TextWriterReaderNonGenericTest()
        {
            var testModel = GetTestModel();
            TestModel result0;
            using (var fs = new FileStream("TextWriterReaderNonGenericTest0.xml", FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.UTF8);
                writer.WriteXml(typeof(TestModel), testModel);
                writer.Close();
            }
            using (var fs = new FileStream("TextWriterReaderNonGenericTest0.xml", FileMode.Open))
            {
                var reader = new StreamReader(fs, Encoding.UTF8);
                result0 = (TestModel) reader.ReadXml(typeof(TestModel));
                reader.Close();
            }
            TestModel result1;
            using (var fs = new FileStream("TextWriterReaderNonGenericTest1.xml", FileMode.Create))
            {
                var writer = new StreamWriter(fs, Encoding.UTF8);
                testModel.ToXml(typeof(TestModel),writer);
                writer.Close();
            }
            using (var fs = new FileStream("TextWriterReaderNonGenericTest1.xml", FileMode.Open))
            {
                var reader = new StreamReader(fs, Encoding.UTF8);
                result1 = (TestModel) reader.ReadXml(typeof(TestModel));
                reader.Close();
            }

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));
        }

        [Fact]
        public void XmlWriterReaderTest()
        {
            var testModel = GetTestModel();
            TestModel result0;
            using (var fs = new FileStream("XmlWriterReaderTest0.xml", FileMode.Create))
            {
                var writer = new XmlTextWriter(fs, Encoding.UTF8);
                writer.WriteXml(testModel);
                writer.Close();
            }
            using (var fs = new FileStream("XmlWriterReaderTest0.xml", FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                result0 = reader.ReadXml<TestModel>();
                reader.Close();
            }
            TestModel result1;
            using (var fs = new FileStream("XmlWriterReaderTest1.xml", FileMode.Create))
            {
                var writer = new XmlTextWriter(fs, Encoding.UTF8);
                testModel.ToXml(writer);
                writer.Close();
            }
            using (var fs = new FileStream("XmlWriterReaderTest1.xml", FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                result1 = reader.ReadXml<TestModel>();
                reader.Close();
            }

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));
        }

        [Fact]
        public void XmlWriterReaderNonGenericTest()
        {
            var testModel = GetTestModel();
            TestModel result0;
            using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Create))
            {
                var writer = new XmlTextWriter(fs, Encoding.UTF8);
                writer.WriteXml(typeof(TestModel), testModel);
                writer.Close();
            }
            using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                result0 = (TestModel) reader.ReadXml(typeof(TestModel));
                reader.Close();
            }
            TestModel result1;
            using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Create))
            {
                var writer = new XmlTextWriter(fs, Encoding.UTF8);
                testModel.ToXml(typeof(TestModel), writer);
                writer.Close();
            }
            using (var fs = new FileStream("XmlWriterReaderNonGenericTest0.xml", FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                result1 = (TestModel) reader.ReadXml(typeof(TestModel));
                reader.Close();
            }

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result0.Id, result0.Age, result0.CreateTime, result0.Name, result0.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(result1.Id, result1.Age, result1.CreateTime, result1.Name, result1.Gender));
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