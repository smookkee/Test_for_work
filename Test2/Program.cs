using System;

namespace Test2
{
    public class C { }
    public class D { }

static class Program
{
    static void Main(string[] args)
    {
        C c = null;
        var d = (D)null;
        Console.Write(c == d);

        Console.ReadKey();
    }
}

}
