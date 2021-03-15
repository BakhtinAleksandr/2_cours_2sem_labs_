using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory
{
    interface IHashtable
    {
        bool Add(Info info);
        Info Find(long id);
        void Delete(long id);
        void Clear();
        string Tostring(Info info);
    }
}
