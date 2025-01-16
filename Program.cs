using System.Diagnostics.Metrics;
using System.Reflection;

Rational rational1 = new Rational { Value = 1 };
Rational rational2 = new Rational { Value = 2 };

Rational sum1 = rational1.Add(rational2);
Console.WriteLine(sum1.Value);
Console.WriteLine();

Rational sub1 = rational1.Sub(rational2);
Console.WriteLine(sub1.Value);
Console.WriteLine();

Rational mul1 = rational1.Mul(rational2);
Console.WriteLine(mul1.Value);
Console.WriteLine();

Rational div1 = rational1.Div(rational2);
Console.WriteLine(mul1.Value);
Console.WriteLine();





bool greate = rational1 > rational2;
Console.WriteLine(greate);
Console.WriteLine();

bool less  = rational1 < rational2;
Console.WriteLine(less);
Console.WriteLine();

bool equal = rational1 == rational2;
Console.WriteLine(equal);


class Rational
{
    public int Value { get; set; }

    public Rational Add(Rational c)
    {
        return new Rational { Value = this.Value + c.Value };
    }

    public Rational Sub(Rational c)
    {
        return new Rational { Value = this.Value = c.Value };
    }

    public Rational Mul(Rational c)
    {
        return new Rational { Value = this.Value * c.Value };
    }

    public Rational Div(Rational c)
    {
        return new Rational { Value = this.Value / c.Value };
    }


    public static bool operator >(Rational c1, Rational c2)
    {
        return c1.Value > c2.Value;
    }

    public static bool operator <(Rational c1, Rational c2)
    {
        return c1.Value > c2.Value;
    }


    public static bool operator !=(Rational c1, Rational c2)
    {
        return c1.Value == c2.Value;
    }

    public static bool operator ==(Rational c1, Rational c2)
    {
        return c1.Value == c2.Value;
    }




    public static bool operator true(Rational c1)
    {
        return c1.Value != 0;
    }
    public static bool operator false(Rational c1)
    {
        return c1.Value == 0;
    }
    public static bool operator !(Rational c1)
    {
        return c1.Value == 0;
    }
}
