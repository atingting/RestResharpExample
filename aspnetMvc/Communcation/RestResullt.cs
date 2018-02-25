using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communcation
{
    public class RestResult<T>
    {
        public string ReturnCode { get; set; }
        public string Message { get; set; }
        public IList<T> Data { get; set; }
    }
}
