using System;
using System.Collections.Generic;
using Xunit;
using Zaabee.Json;

namespace UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void ToJson()
        {
            var id = Guid.NewGuid();
            var age = new Random().Next(0, 100);
            var time = DateTime.Now;
            var offset = DateTimeOffset.Now;
            var name = "banana";

            var testModel = new TestModel
            {
                Id = id,
                Age = age,
                CreateTime = time,
                CreateTimeOffset = offset,
                Name = name
            };

            var jsonStr1 = testModel.ToJson();

            var jsonStr2 = testModel.ToJson(new List<string> {"Id", "Name"});

            var jsonStr3 = testModel.ToJson(null, true, "yyyy-MM-dd HH:mm:ss");

            Assert.Equal(jsonStr1,
                $"{{\"Id\":\"{id}\",\"Age\":{age},\"Name\":\"{name}\",\"CreateTime\":\"{time:yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK}\",\"CreateTimeOffset\":\"{offset:yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK}\"}}");
            Assert.Equal(jsonStr2,
                $"{{\"Id\":\"{id}\",\"Name\":\"{name}\"}}");
            Assert.Equal(jsonStr3,
                $"{{\"id\":\"{id}\",\"age\":{age},\"name\":\"{name}\",\"createTime\":\"{time:yyyy-MM-dd HH:mm:ss}\",\"createTimeOffset\":\"{offset:yyyy-MM-dd HH:mm:ss}\"}}");
        }

        [Fact]
        public void FromJson()
        {
            var id = Guid.NewGuid();
            var age = new Random().Next(0, 100);
            var time = DateTime.Now;
            var name = "banana";

            var testModel = new TestModel
            {
                Id = id,
                Age = age,
                CreateTime = time,
                Name = name
            };

            var jsonStr =
                $"{{\"Id\":\"{id}\",\"Age\":{age},\"Name\":\"{name}\",\"CreateTime\":\"{time:yyyy-MM-dd HH:mm:ss}\"}}";
            
            var deserializeModel1 = jsonStr.FromJson<TestModel>();
            var deserializeModel2 = jsonStr.FromJson(typeof(TestModel)) as TestModel;

            Assert.Equal(deserializeModel1.Id, deserializeModel2.Id);
            Assert.Equal(deserializeModel1.Age, deserializeModel2.Age);
            Assert.Equal(deserializeModel1.CreateTime, deserializeModel2.CreateTime);
            Assert.Equal(deserializeModel1.Name, deserializeModel2.Name);
        }
    }
}