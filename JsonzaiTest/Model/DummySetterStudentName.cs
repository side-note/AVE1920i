using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jsonzai;

namespace Jsonzai.Test.Model
{
    class DummySetterStudentName : ISetter
    {
        public Type Klass { get => typeof(Student); set { } }

        public void SetValue(object target, object value)
        {
            ((Student)target).Name = (string)value;
        }
    }
}
