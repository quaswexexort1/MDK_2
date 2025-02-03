public class Rational
{

    public int Numerator { get; set; } // Хранение числителя дроби
    public int Denominator { get; set; } // Хранение знаменателя дроби

    public Rational(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
        Reduce(); // Reduce для сокращения дроби при создании
    }

    private void Reduce()
    {
        int nod = NOD(Math.Abs(Numerator), Math.Abs(Denominator));  //NOD - Наибольшее общее делимое
        // Деление числителя и знаменателя на их НОД для сокращения.
        Numerator /= nod;
        Denominator /= nod;

        if (Denominator < 0) // Гарантия, что знаменатель всегда будет положительным.
        {
            Numerator *= -1;
            Denominator *= -1;
        }
    }

    private int NOD(int a, int b) //для вычисления наибольшего общего делителя(НОД) двух чисел.
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }


    public static Rational Add(Rational r1, Rational r2)
        => new Rational(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);

    public static Rational Sub(Rational r1, Rational r2)
        => new Rational(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);

    public static Rational Mul(Rational r1, Rational r2)
          => new Rational(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);

    public static Rational Div(Rational r1, Rational r2)
        => new Rational(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);



    public static bool Equal(Rational r1, Rational r2) // сравнение "Равно"
        => r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator;

    public static bool Greater(Rational r1, Rational r2) // сравнение "Больше"
      => (double)r1.Numerator / r1.Denominator > (double)r2.Numerator / r2.Denominator;

    public static bool Less(Rational r1, Rational r2) // сравнение "Меньше"
       => (double)r1.Numerator / r1.Denominator < (double)r2.Numerator / r2.Denominator;

    // Возвращает строку в формате "числитель/знаменатель".
    public override string ToString()
      => $"{Numerator}/{Denominator}";
}

    public class Program
    {
        public static void Main(string[] args)
        {
            Rational r1 = new Rational(1, 2);
            Rational r2 = new Rational(1, 4);

            // Вывод созданных дробей
            Console.WriteLine($"r1: {r1}, r2: {r2}");

            // Выполнение операций и вывод результатов.
            Console.WriteLine($"{r1} + {r2} = {Rational.Add(r1, r2)}");
            Console.WriteLine($"{r1} - {r2} = {Rational.Sub(r1, r2)}");
            Console.WriteLine($"{r1} * {r2} = {Rational.Mul(r1, r2)}");
            Console.WriteLine($"{r1} / {r2} = {Rational.Div(r1, r2)}");

            // Выполнение сравнений
            Console.WriteLine($"{r1} == {r2} : {Rational.Equal(r1, r2)}");
            Console.WriteLine($"{r1} > {r2} : {Rational.Greater(r1, r2)}");
            Console.WriteLine($"{r1} < {r2} : {Rational.Less(r1, r2)}");

            // Сокращение дроби
            Rational r3 = new Rational(2, 4);
            Console.WriteLine($"{r3} = {r3.ToString()}");

            // Отрицательная дробь
            Rational r4 = new Rational(-1, 3);
            Console.WriteLine($"{r4} = {r4.ToString()}");
        }
    }
