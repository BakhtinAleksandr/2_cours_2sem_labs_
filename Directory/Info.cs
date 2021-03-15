using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory
{
    class Info
    {
        public long Number { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public static long Hash(long id)
        {
            return id;
        }
    }
}
