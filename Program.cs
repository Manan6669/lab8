using System;
using System.Collections.Generic;
using System.IO;

namespace lab8
{
    class Program
        {
        static void Main(string[] args)
          {
          
            try
            {
                test<Transport> tst = new test<Transport>();
                Transport transport = new Transport();
                transport.name = 1000;
                Console.WriteLine(tst.xe);

                CollectionType<char> coll = new CollectionType<char>(CollectionType<char>.GetFile());


                coll.Show();
                coll.Save();
                coll.Add('g');

            }
            catch(Exception ex)
            {
                Console.WriteLine("wtftrans");
            }
            finally
            {
                Console.WriteLine("NOwtftrans");
            }
          }
        }
    interface IStand<T>
     {
            public void Add(T element)
            { }
            public void Show()
            { }
            public void Delete(T element)
            { }
     }
    class CollectionType<T>:IStand<T> where T:new()
    {
        private List<T> _list;
        CollectionType ()
        {
            _list = new List<T>();
        }
        public CollectionType(params T[] args):this()
        {
            _list.AddRange(args);

        }
        public CollectionType(IEnumerable<T> mas):this()
        {
            _list.AddRange(mas);
        }

        public void Save()
        {
            string filee = @"C:D:\ЛЕНННННА\C#\lab8\labbbbbb.txt";
            string bf = null;
            using (StreamWriter ex = new StreamWriter(filee))
            {
                foreach (T el in this._list)
                {
                    bf += Convert.ToString(el);
                }

                ex.WriteLine(bf);
            }
        }

        public static string GetFile()
        {
            string[] lines = File.ReadAllLines(@"C:D:\ЛЕНННННА\C#\lab8\labbbbbb.txt");
            string bf = null;

            for(int i=0;i<lines.Length; i++)
            {
                bf += lines[i];
            }

            return bf;
        }

        public void Add(T element)
        {
            if (Convert.ToInt16(element) !=0)
            {
                _list.Add(element);
            }
        }
        public void Show()
        {
            foreach (T element in this._list)
            {
                Console.Write(element);

            }
            
        }

        public void Delete(T delElement)
        {
            _list.Remove(delElement);
        }
    }

    class Transport
    {
        public int name { get; set; }
    }

    class test<Transport>
    {
        public Transport xe;
        public test()
        {

        }
        public void Show()
        {
            Console.WriteLine(xe);
        }
    }
    class Trans<T> where T : Transport
    {
        public T transport;
    }
        
}
