namespace SpaceBattle.Lib.Test;
using System;

public class AngleUnitTest
{
    [Fact]
    public void PositiveCreateTest()
    {
        Assert.IsType<Angle>(new Angle(72, 1));
    }
    [Fact]
    public void CreateDivideByZeroExceptionTest()
    {
        Assert.Throws<DivideByZeroException>(() => new Angle (100, 0));
    }
    [Fact]
    public void PositiveAngleSumTest()
    {
        Angle a1 = new Angle(90, 1);
        Angle a2 = new Angle(135, 1);

        Assert.Equal(new Angle(225, 1), a1 + a2);
    }
    [Fact]
    public void PositiveAngleEqualTest()
    {
        Angle a1 = new Angle(90, 1);
        Angle a2 = new Angle(90, 1);

        Assert.True(a1 == a2);
    }
    [Fact]
    public void PosAngleHashTest()
    {
        Angle a = new Angle(135, 1);
        Angle b = new Angle(135, 1);

        Assert.True(a.GetHashCode() == b.GetHashCode());
    }
    [Fact]
    public void NegAngleHashTest()
    {
        Angle a = new Angle(135, 1);
        Angle b = new Angle(132, 1);

        Assert.True(a.GetHashCode() != b.GetHashCode());
    }
    [Fact]
    public void NotEqualTest()
    {
        Angle a = new Angle(45, 1);
        Angle b = new Angle(135, 1);

        Assert.True(a != b);
    }
    [Fact]
    public void PosNOD_AngleTest()
    {
        int nod = Angle.NOD(4, 5);

        Assert.Equal(1, nod);
    }
    [Fact]
    public void PositiveEqualsMethodTest()
    {
        Angle a = new Angle(90, 1);

        Assert.False(a.Equals(1));
    }
}
