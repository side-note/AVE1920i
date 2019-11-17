using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using Jsonzai;
using Jsonzai.Test.Model;
using Newtonsoft.Json;
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
      
        
        public string BenchStudentArray()
        {
            Student s1 = new Student();
            s1.Name = "Maria Castro";
            s1.Nr = 44531;
            s1.Group = 12;
            s1.GithubId = "mcastro";           
            Student s2 = new Student();
             s2.Name = "Manel Castro";
            s2.Nr = 44532;
            s2.Group = 12;
            s2.GithubId = "mncastro";            
            Student s3 = new Student();
             s3.Name = "Manel Pedro";
            s3.Nr = 44533;
            s3.Group = 12;
            s3.GithubId = "mpedro";
           
            Student[] Classroom = { s1, s2, s3 };
           
            string json = JsonConvert.SerializeObject(Classroom);
            json = json.Replace("GithubId", "github_id");
            return json;
        }
        
        public string BenchClassroom()
        {
            Classroom cls = new Classroom();
            cls.Class = "LI41N";
            Student s1 = new Student();
            s1.Name = "Maria Castro";
            s1.Nr = 44531;
            s1.Group = 12;
            s1.GithubId = "mcastro";
            Student s2 = new Student();
            s2.Name = "Manel Castro";
            s2.Nr = 44532;
            s2.Group = 12;
            s2.GithubId = "mncastro";
            Student s3 = new Student();
            s3.Name = "Manel Pedro";
            s3.Nr = 44533;
            s3.Group = 12;
            s3.GithubId = "mpedro";
            cls.Student = new Student[] { s1, s2, s3 };
            string json = JsonConvert.SerializeObject(cls);
            json = json.Replace("GithubId", "github_id");
            return json;
        }

        public string BenchAccount()
        {
            Account acc = new Account();
            acc.Balance = 234.32;
            acc.Transactions = new Double[] { -100.00, 32.00, -5.00 };
            string json = JsonConvert.SerializeObject(acc);
            return json;
        }
            

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

        [Benchmark]
        public void BenchStudentArrayReflect()
        {
            JsonParser.Parse(BenchStudentArray(), typeof(Student));
        }

        [Benchmark]
        public void BenchStudentArrayEmit()
        {
            JsonParsemit.Parse(BenchStudentArray(), typeof(Student));
        }
        [Benchmark]
        public void BenchClassroomReflect()
        {
            JsonParser.Parse(BenchClassroom(), typeof(Classroom));
        }

        [Benchmark]
        public void BenchClassroomEmit()
        {
            JsonParsemit.Parse(BenchClassroom(), typeof(Classroom));
        }
        [Benchmark]
        public void BenchAccountReflect()
        {
            JsonParser.Parse(BenchAccount(), typeof(Account));
        }

        [Benchmark]
        public void BenchAccountEmit()
        {
            JsonParsemit.Parse(BenchAccount(), typeof(Account));
        }
        [Benchmark]
        public void BenchJsonPropertyReflect()
        {
            JsonParser.Parse(src, typeof(Student));
        }

        [Benchmark]
        public void BenchJsonPropertyEmit()
        {
            JsonParsemit.Parse(src, typeof(Student));
        }
    }
}
