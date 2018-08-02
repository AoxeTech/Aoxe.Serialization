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
            Assert.Equal(jsonStr1,
                $"{{\"Id\":\"{id}\",\"Age\":{age},\"Name\":\"{name}\",\"CreateTime\":\"{time:yyyy-MM-dd HH:mm:ss}\"}}");

            var jsonStr2 = testModel.ToJson(new List<string> {"Id", "Name"});
            Assert.Equal(jsonStr2,
                $"{{\"Id\":\"{id}\",\"Name\":\"{name}\"}}");

            var jsonStr3 = testModel.ToJson(null, true);
            Assert.Equal(jsonStr3,
                $"{{\"id\":\"{id}\",\"age\":{age},\"name\":\"{name}\",\"createTime\":\"{time:yyyy-MM-dd HH:mm:ss}\"}}");
        }

        [Fact]
        public void FromJson()
        {
            var id = Guid.NewGuid();
            var age = new Random().Next(0, 100);
            var time = new DateTime(2017, 1, 1);
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

            var jsonStr2 =
                "{\"Id\":\"3c15783f-baeb-4b64-b571-596eae8878e5\",\"Age\":26,\"Name\":\"banana\",\"CreateTime\":\"2018-08-02T19:09:47.0099778+08:00\",\"CreateTimeOffset\":\"2018-08-02T19:09:47.0100628+08:00\"}";

            var deserializeModel1 = jsonStr2.FromJson<TestModel>();
            var deserializeModel2 = jsonStr2.FromJson(typeof(TestModel)) as TestModel;

            Assert.Equal(deserializeModel1.Id, deserializeModel2.Id);
            Assert.Equal(deserializeModel1.Age, deserializeModel2.Age);
            Assert.Equal(deserializeModel1.CreateTime, deserializeModel2.CreateTime);
            Assert.Equal(deserializeModel1.Name, deserializeModel2.Name);
        }
    }
}