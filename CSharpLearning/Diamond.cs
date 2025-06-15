using System;

interface IA { void Foo() => Console.WriteLine("IA"); }
interface IB : IA { void IA.Foo() => Console.WriteLine("IB"); }
interface IC : IA { void IA.Foo() => Console.WriteLine("IC"); }

class D : IB, IC
{
    void IA.Foo() => Console.WriteLine("D"); // Resolves ambiguity
}

class Program
{
    static void Main()
    {
        D d = new D();
        ((IA)d).Foo(); // Output: D
    }
}