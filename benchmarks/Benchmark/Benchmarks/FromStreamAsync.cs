using System;
using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Zaabee.Jil;
using Zaabee.MessagePack;
using Zaabee.MsgPack;
using Zaabee.NewtonsoftJson;
using Zaabee.SystemTextJson;
using Zaabee.Utf8Json;

namespace Benchmark.Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, targetCount: 1000)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class FromStreamAsync
    {
        private readonly TestModel _testModel = new TestModel
        {
            Id = Guid.NewGuid(),
            Age = new Random().Next(0, 100),
            CreateTime = new DateTime(2017, 1, 1),
            Name = "apple",
            Gender = Gender.Female
        };

        private readonly FileStream _jilStream = new FileStream(".\\JilStream", FileMode.Create);
        private readonly FileStream _messagePackStream = new FileStream(".\\MessagePackStream", FileMode.Create);
        private readonly FileStream _msgPackStream = new FileStream(".\\MsgPackStream", FileMode.Create);
        private readonly FileStream _newtonsoftJsonStream = new FileStream(".\\NewtonsoftJsonStream", FileMode.Create);
        private readonly FileStream _systemTextJsonStream = new FileStream(".\\SystemTextJsonStream", FileMode.Create);
        private readonly FileStream _utf8JsonStream = new FileStream(".\\Utf8JsonStream", FileMode.Create);

        public FromStreamAsync()
        {
            JilHelper.Pack(_testModel, _jilStream);
            MessagePackHelper.Pack(_testModel, _messagePackStream);
            MsgPackHelper.Pack(_testModel, _msgPackStream);
            NewtonsoftJsonHelper.Pack(_testModel, _newtonsoftJsonStream);
            SystemTextJsonHelper.Pack(_testModel, _systemTextJsonStream);
            Utf8JsonHelper.Pack(_testModel, _utf8JsonStream);
        }

        [Benchmark]
        public async Task JilFromStreamAsync() =>
            await JilHelper.FromStreamAsync<TestModel>(_jilStream);

        [Benchmark]
        public async Task MessagePackFromStreamAsync() =>
            await MessagePackHelper.FromStreamAsync<TestModel>(_messagePackStream);

        [Benchmark]
        public async Task MsgPackFromStreamAsync() =>
            await MsgPackHelper.FromStreamAsync<TestModel>(_msgPackStream);

        [Benchmark]
        public async Task NewtonsoftJsonFromStreamAsync() =>
            await NewtonsoftJsonHelper.FromStreamAsync<TestModel>(_newtonsoftJsonStream);

        [Benchmark]
        public async Task SystemTextJsonFromStreamAsync() =>
            await SystemTextJsonHelper.FromStreamAsync<TestModel>(_systemTextJsonStream);

        [Benchmark]
        public async Task Utf8JsonFromStreamAsync() =>
            await Utf8JsonHelper.FromStreamAsync<TestModel>(_utf8JsonStream);
    }
}