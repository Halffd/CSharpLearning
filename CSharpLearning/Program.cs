using System.Numerics;

Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.Yellow;  
Console.WriteLine("DOES THIS WORK?");
Thread.Sleep(1000);
Console.ResetColor();
Console.BackgroundColor = ConsoleColor.Red;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("DOES THIS WORK?");
Thread.Sleep(1000);
Console.ResetColor();
void ThreadingMethods()
{
    int i = 0;
    List<Thread> threads = new List<Thread>();
    object lockObject = new object(); // For thread safety

    for (int index = 0; index < 1000; index++)
    {
        Thread t = new Thread(() =>
        {
            Console.WriteLine("Hello from a thread!");
        
            // Thread-safe way to modify shared state
            lock (lockObject)
            {
                i = i + 1 + i * 2;
            }
        });
    
        threads.Add(t);
        t.Start(); // Actually start the damn thread!
    }

// Wait for ALL threads to complete
    foreach (Thread t in threads)
    {
        t.Join();
    }

    Console.WriteLine($"Final value of i: {i}");
    Thread.Sleep(1000);
    Console.WriteLine("Thread.Sleep(1000);");
    Thread.Sleep(1000);
    Console.WriteLine("Thread.Sleep(1000);");
    Thread.Sleep(1000);
    Console.WriteLine("Thread.Sleep(1000);");
}
void RandomMethods()
{
    Random random = new Random();
    int randomInt = random.Next();
    Console.WriteLine(randomInt); // 0
    randomInt = random.Next(1, 10);
    Console.WriteLine(randomInt); // 3
    randomInt = random.Next(1, 10);
    Console.WriteLine(randomInt); // 5
    randomInt = random.Next(1, 10);
    Console.WriteLine(randomInt); // 8
    //0-1
    double randomDouble = random.NextDouble();
    Console.WriteLine(randomDouble); // 0.5
}
RandomMethods();
void MathMethods()
{
    BigInteger bigInt = 1;
    Console.WriteLine(bigInt);
    Console.WriteLine(bigInt.GetType()); // System.Numerics.BigInteger
    Console.WriteLine(bigInt.ToString()); // 1
    bigInt = BigInteger.Pow(2, 64);
    Console.WriteLine(bigInt); // 18446744073709551616
    Console.WriteLine(bigInt.GetType()); // System.Numerics.BigInteger
    Console.WriteLine(bigInt.ToString()); // 18446744073709551616
    //Pow ceiling floor sqrt round round(decimal)
    Console.WriteLine(Math.Pow(2, 64)); // 18446744073709551616
    Console.WriteLine(Math.Ceiling(2.5)); // 3
    Console.WriteLine(Math.Floor(2.5)); // 2
    Console.WriteLine(Math.Sqrt(2)); // 1.4142135623730951
    Console.WriteLine(Math.Round(2.5)); // 3
    Console.WriteLine(Math.Round(2.51)); // 3
    Console.WriteLine(Math.Round(2.49)); // 2
}
void ConvertTypes()
{
    double pi = Math.PI;
    int piInt = Convert.ToInt32(pi);
    double piIntDouble = Convert.ToDouble(piInt) + Math.PI;
    String piString = pi.ToString();
    char piChar = pi.ToString()[0];
    char c = 'a';
    uint u = Convert.ToUInt32(c);
    String booleanString = "true";
    bool boolean = Convert.ToBoolean(booleanString);
    Object obj = new Object();
    String objString = obj.ToString();
    Console.WriteLine(objString);
    Console.WriteLine(boolean);
    Console.WriteLine(booleanString);
    Console.WriteLine(c);
    Console.WriteLine(u);
    Console.WriteLine(piChar);
    Console.WriteLine(piString);
    Console.WriteLine(piString.GetType()); // System.String()
    Console.WriteLine(pi);
    Console.WriteLine(piInt);
    Console.WriteLine(piIntDouble);
    Console.WriteLine(pi.GetType()); // System.Double()
    Console.WriteLine(piInt.GetType()); // System.Int32
    Console.WriteLine(pi.ToString()); // 3.14159265358979
}
MathMethods();
// Quit program
if (args.Length < 1 || args[0] == "quit")
{
    Environment.Exit(0);
}
if (OperatingSystem.IsWindows()) {
    Console.Beep();
} else {
    // Linux beep via shell
    for (int freq = 1; freq <= 150; freq++) {
        System.Diagnostics.Process.Start("speaker-test", $"-t sine -f {freq*10} -l 1 -s 1");
        Thread.Sleep(1000);
    }
}


var name = Console.ReadLine();
Console.WriteLine($"Hello, {name}!");

// Functions still work
int Add(int a, int b) => a + b;
Console.WriteLine(Add(5, 3));