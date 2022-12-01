namespace SpaceBattle.Lib.Test;
using System;
using Moq;

public class RotatUnitTest1
{
    [Fact]
    public void PositiveRotateTest()
    {
        var r_obj = new Mock<IRotatable>();
        r_obj.SetupProperty(x => x.angle, new Angle(45, 1));
        r_obj.Setup(x => x.angleVelocity).Returns(new Angle(90, 1));
        ICommand rc = new RotateCommand(r_obj.Object);

        rc.Execute();

        Assert.Equal(r_obj.Object.angle, new Angle(135, 1));
    }
    [Fact]
    public void CantReadAngleTest()
    {
        var r_obj = new Mock<IRotatable>();
        r_obj.Setup(x => x.angle).Throws(new Exception());
        ICommand rc = new RotateCommand(r_obj.Object);

        Assert.Throws<Exception>(() => rc.Execute());
    }
    [Fact]
    public void CantReadAngleVelocityest()
    {
        var r_obj = new Mock<IRotatable>();
        r_obj.SetupProperty(x => x.angle, new Angle ( 90, 1 ));
        r_obj.SetupGet(x => x.angleVelocity).Throws<Exception>();
        ICommand rc = new RotateCommand(r_obj.Object);

        Assert.Throws<Exception>(() => rc.Execute());
    }
    [Fact]
    public void CantRotateObj()
    {
        var r_obj = new Mock<IRotatable>();
        r_obj.SetupProperty(x => x.angle, new Angle ( 100, 1 ));
        r_obj.Setup(x => x.angleVelocity).Returns(new Angle ( 80, 1));
        r_obj.SetupGet(x => x.angle).Throws<ArithmeticException>();
        ICommand rc = new RotateCommand(r_obj.Object);

        Assert.Throws<ArithmeticException>(() => rc.Execute());
    }
}
