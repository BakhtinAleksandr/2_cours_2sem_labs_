using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory
{
    class LineHashtable: IHashtable
    {
        private Elem[] Table { get; }
        public int Size { get; }
        public LineHashtable(int size = 100) 
        {
            Size = size;
            Table = new Elem[size];
        }
        public bool Add(Info info)
        {
            if (Find(info.Number) != null)
            {
                return false;
            }
            long hash = Info.Hash(info.Number);
            long index = hash % Size;
            if (Table[index] == null || Table[index].Deleted) // Добавление в таблицу
            {
                Table[index] = new Elem()
                {
                    Info = info
                };
                return true;
            }
            for (long i = index + 1; i < Size; i++) // Метод решения коллизии
            {
                if (Table[i] == null || Table[i].Deleted)
                {
                    Table[i] = new Elem()
                    {
                        Info = info
                    };
                    return true;
                }
            }
            for (int i = 0; i < index; i++)
            {
                if (Table[i] == null || Table[i].Deleted)
                {
                    Table[i] = new Elem()
                    {
                        Info = info
                    };
                    return true;
                }
            }
            return false;
        }
        public Info Find(long id)
        {
            long hash = Info.Hash(id);
            long index = hash % Size;
            if (Table[index] == null)
            {
                return null;
            }
            if (!Table[index].Deleted && Table[index].Info.Number == id)
            {
                return Table[index].Info;
            }
            for (long i = index + 1; i < Size; i++)
            {
                if (Table[i] == null)
                {
                    return null;
                }
                if (!Table[i].Deleted && Table[i].Info.Number == id)
                {
                    return Table[i].Info;
                }
            }
            for (int i = 0; i < index; i++)
            {
                if (Table[i] == null)
                {
                    return null;
                }
                if (!Table[i].Deleted && Table[i].Info.Number == id)
                {
                    return Table[i].Info;
                }
            }
            return null;
        }
        public void Delete(long id)
        {
            long hash = Info.Hash(id);
            long index = hash % Size;
            if (Table[index] == null)
            {
                return;
            }
            if (!Table[index].Deleted && Table[index].Info.Number == id)
            {
                Table[index].Deleted = true;
                return;
            }
            for (long i = index + 1; i < Size; i++)
            {
                if (Table[i] == null)
                {
                    return;
                }
                if (!Table[i].Deleted && Table[i].Info.Number == id)
                {
                    Table[i].Deleted = true;
                    return;
                }
            }
            for (int i = 0; i < index; i++)
            {
                if (Table[i] == null)
                {
                    return;
                }
                if (!Table[i].Deleted && Table[i].Info.Number == id)
                {
                    Table[i].Deleted = true;
                    return;
                }
            }
        }
        public void Clear()
        {
            for (int i = 0; i < Size; i++)
            {
                Table[i] = null;
            }
        }
        public string Tostring(Info info)
        {
            string res = "";           
            res = $"{info.Number}\n{info.FIO}\n{info.Age} ";         
            return res;
        }
    }
    class Elem
    {
        public Info Info { get; set; }
        public bool Deleted { get; set; } = false;
    }
}

