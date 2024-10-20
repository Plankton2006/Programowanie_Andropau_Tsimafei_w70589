class zad1
{
    static void Main()
    {
        Console.WriteLine("Podaj a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Podaj b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Podaj c: ");
        double c = Convert.ToDouble(Console.ReadLine());
        double d = (b * b) - (4 * a * c);
        Console.WriteLine($"Delta: {d}");
        if (d > 0)
        {
            double x1 = (-b - Math.Sqrt(d)) / (2 * a);
            double x2 = (-b + Math.Sqrt(d)) / (2 * a);
            Console.WriteLine($"Pierwiastki: {x1}, {x2}");
        }
        else if (d == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Pierwiastek: {x}");
        }
        else
        {
            Console.WriteLine("Trójmian kwadratowy nie ma pierwiastków rzeczywistych");
        }
    }
}