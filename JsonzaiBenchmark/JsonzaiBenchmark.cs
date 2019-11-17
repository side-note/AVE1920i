using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using Jsonzai;
using Jsonzai.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonzaiBenchmark
{
    public class JsonzaiBenchmarkConfig : ManualConfig
    {
        public JsonzaiBenchmarkConfig()
        {
            Add(Job.MediumRun
                   .WithLaunchCount(1)
                   .With(InProcessEmitToolchain.Instance)
                   .WithId("InProcess"));
        }
    }

    [RankColumn]
    [Config(typeof(JsonzaiBenchmarkConfig))]

    public class JsonzaiBenchmark
    {
        string src = "{Name: \"Ze Manel\", Nr: 6512, Group: 11, github_id: \"omaior\"}";

        [Benchmark]
        public void BenchStudentReflect()
        {
            JsonParser.Parse(src, typeof(Student));
        }

        [Benchmark]
        public void BenchStudentEmit()
        {
            JsonParsemit.Parse(src, typeof(Student));
        }

    }
}
