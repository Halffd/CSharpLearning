using System;

interface IA
{
    void Foo(); // Declaration only
}

interface IB : IA
{
    // No implementation here
}

interface IC : IA
{
    // No implementation here
}

class D : IB, IC
{
    public void Foo() => Console.WriteLine("D"); // Implementing the method
}

class Program
{
    static void Main()
    {
        D d = new D();
        ((IA)d).Foo(); // Output: D
    }
}