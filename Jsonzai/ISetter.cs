using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsonzai
{
    public interface ISetter
    {
        Type Klass { get; set; }
        void SetValue(object target, object value);
    }
}
