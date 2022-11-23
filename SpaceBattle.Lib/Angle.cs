namespace SpaceBattle.Lib;

public class Angle
{
    public int numerator { get; set; }
    public int denominator { get; set; }

    public Angle(int numerator, int denominator)
    {
        if (denominator == 0) throw new DivideByZeroException();

        int nod = NOD(numerator, denominator);
        this.numerator = numerator / nod;
        this.denominator = denominator / nod;
    }
    public static int NOD(int x, int y)
    {
        while (x != y)
        {
            if (x > y)
                x = x - y;
            else
                y = y - x;
        }
        return x;
    }

    public static Angle operator +(Angle a, Angle b)
    {
        int num = a.numerator * b.denominator + b.numerator * a.denominator;
        int den = a.denominator * b.denominator;
        int nod = NOD(num, den);
        return new Angle(num / nod, den / nod);
    }

    public static bool operator ==(Angle a, Angle b) => (a.numerator == b.numerator) && (a.denominator == b.denominator);

    public static bool operator !=(Angle a, Angle b) => !(a == b);

    public override bool Equals(object? obj) => obj is Angle a && this.numerator == a.numerator && this.denominator == a.denominator;

    public override int GetHashCode() => ((this.numerator + this.denominator).ToString()).GetHashCode();
}
