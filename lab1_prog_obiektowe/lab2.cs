class zad2{
    static void Main()
    {
        Console.WriteLine("Podaj 1 liczbę: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Podaj 2 liczbę: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"+:{a+b}");
        Console.WriteLine($"-:{a-b}");
        Console.WriteLine($"*:{a*b}");
        if (b != 0)
        {
            Console.WriteLine($"/: {a / b}");
        }
        else
        {
            Console.WriteLine("Nie można dzielić przez 0!");
        }

        Console.WriteLine($"{Math.Pow(a,b)}");

        if (a >= 0)
        {
            Console.WriteLine($"pierwiastek z pierwszej liczby: {Math.Sqrt(a)}");
        }
        else{
            Console.WriteLine("pierwiastka z liczby ujemnej nie moze być");
        }

        Console.WriteLine("Podaj kąt w radianach: ");
        double c= Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"Sin: {Math.Sin(c)}");
        Console.WriteLine($"Cos: {Math.Cos(c)}");
        Console.WriteLine($"Tan: {Math.Tan(c)}");
    }
}
