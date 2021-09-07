using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_for_work
{
    class Program
    {
        public class A
        {
            
            public A()
            {
                Console.WriteLine("1 const A");
                Print();
            }
            public virtual void Print()
            {
                Console.WriteLine("2 print A");
            }
        }

        public class B : A
        {
            public B()
            {
                Console.WriteLine("3 constr B");
                Print();
            }

            public new void Print()
            {
                Console.WriteLine("4 print B");
            }
        }

        static void Main(string[] args)
        {

          
            B b = new B();
            b.Print();

            A c = (A)b;
            c.Print();

            Console.ReadKey();

        }
    }
}
