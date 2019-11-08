//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Jsonzai.Test.Model
//{

//    public interface ISetter
//    {
//        Type Klass { get; }
//        void SetValue(object target, object value);
//    }

//    class DummySetterStudentNr : ISetter
//    {
//        public Type Klass { get => typeof(int); }

//        public void SetValue(object target, object value)
//        {
//            ((Student)target).Nr = (int)value;
//        }
//    }
//    class DummySetterStudentName : ISetter
//    {
//        public Type Klass { get => typeof(string); }

//        public void SetValue(object target, object value)
//        {
//            ((Student)target).Name = (string)value;
//        }
//    }
//    //class DummySetterStudentName : ISetter
//    //{
//    //    public Type Klass { get => typeof(string); }

//    //    public void SetValue(object target, object value)
//    //    {
//    //        ((Student)target).Name = (string)value;
//    //    }
//    //}
//    class DummySetterClassroomId : ISetter
//    {
//        public Type Klass { get => typeof(JsonToGuid); }

//        public void SetValue(object target, object value)
//        {
//            ((Classroom)target).Id = JsonToGuid.Parse((string)value);
//        }
//    }
//    public class Student : Person
//    {
//        public Student() : base() { }
//        public Student(int nr, string name, int group, string githubId) : base(name)
//        {
//            this.Nr = nr;
//            this.Group = group;
//            this.GithubId = githubId;
//        }

//        public int Nr { get; set; }

//        public int Group { get; set; }

//        public string GithubId { get; set; }
//    }
//    public class Person
//    {
//        public string Name { get; set; }

//        public Person()
//        {
//        }

//        public Person(string name)
//        {
//            this.Name = name;
//        }
//    }
//    class Classroom
//    {
//        public Classroom()
//        {
//        }
//        public string Class { get; set; }
//        public Student[] Student { get; set; }
//        [JsonConvert(typeof(JsonToGuid))] public Guid Id { get; set; }

//    }
//    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
//    public class JsonConvertAttribute : Attribute
//    {
//        public JsonConvertAttribute()
//        {

//        }
//        public readonly Type klass;
//        public JsonConvertAttribute(Type klass)
//        {
//            this.klass = klass;
//        }

//    }
//    public class JsonToGuid
//    {
//        JsonToGuid()
//        {
//        }
//        public static Guid Parse(string json)
//        {
//            return new Guid(json);
//        }
//    }
//}
