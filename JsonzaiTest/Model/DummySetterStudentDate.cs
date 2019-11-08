using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jsonzai;

namespace Jsonzai.Test.Model
{
	public struct Date
    {
        public int Year { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
    }
	
    public interface ISetter
    {
        Type Klass { get; }
        void SetValue(object target, object value);
    }

    class DummySetterStudentDate : ISetter
    {
        public Type Klass { get => typeof(Date); }

        public void SetValue(object target, object value)
        {
            ((Person)target).Birth = (Date)value;
        }
    }
     public class Person
    {
        public string Name { get; set; }
        public Date Birth { get; set; }
        public Person Sibling { get; set; }

        public Person()
        {
        }

        public Person(string name)
        {
            this.Name = name;
        }
    }


}
