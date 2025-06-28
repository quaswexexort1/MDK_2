public class Rational
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public Rational(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Знаменатель не может быть равен нулю.");
            
        Numerator = numerator;
        Denominator = denominator;
        Reduce();
    }

    private void Reduce()
    {
        int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator /= gcd;
        Denominator /= gcd;

        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Перегрузка операторов
    public static Rational operator +(Rational r1, Rational r2)
        => new Rational(
            r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator,
            r1.Denominator * r2.Denominator);

    public static Rational operator -(Rational r1, Rational r2)
        => new Rational(
            r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator,
            r1.Denominator * r2.Denominator);

    public static Rational operator *(Rational r1, Rational r2)
        => new Rational(
            r1.Numerator * r2.Numerator,
            r1.Denominator * r2.Denominator);

    public static Rational operator /(Rational r1, Rational r2)
    {
        if (r2.Numerator == 0)
            throw new DivideByZeroException("Деление на ноль невозможно.");
        return new Rational(
            r1.Numerator * r2.Denominator,
            r1.Denominator * r2.Numerator);
    }

    // Операторы сравнения
    public static bool operator ==(Rational r1, Rational r2)
        => r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator;

    public static bool operator !=(Rational r1, Rational r2)
        => !(r1 == r2);

    public static bool operator >(Rational r1, Rational r2)
        => r1.Numerator * r2.Denominator > r2.Numerator * r1.Denominator;

    public static bool operator <(Rational r1, Rational r2)
        => r1.Numerator * r2.Denominator < r2.Numerator * r1.Denominator;

    public override bool Equals(object obj)
        => obj is Rational other && this == other;

    public override int GetHashCode()
        => HashCode.Combine(Numerator, Denominator);

    public override string ToString()
        => $"{Numerator}/{Denominator}";
}
