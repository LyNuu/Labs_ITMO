namespace Itmo.ObjectOrientedProgramming.Lab1.Train;

public class MyTrain : ITrain
{
    private const double TimeAccuracy = 0.1;

    private double _acceleration;

    private double _duration;

    public MyTrain(double maxForce, double weight, double speed, double acceleration)
    {
        Weight = weight;
        _acceleration = acceleration;
        Speed = speed;
        MaxForce = maxForce;
        _duration = 0.0;
    }

    public double MaxForce { get; private set; }

    public double Speed { get; private set; }

    public double Weight { get; }

    public void Acceleration()
    {
        _acceleration = Speed / Weight;
    }

    public void ResultingSpeed()
    {
        Speed += _acceleration * TimeAccuracy;
    }

    public double DistanceTravelled()
    {
        _duration += Speed * TimeAccuracy;
        return _duration;
    }

    public bool CanApplyForce(double force)
    {
        if (force < 0.0)
        {
            force *= -1;
        }

        if (!(force <= MaxForce)) return false;
        DistanceTravelled();
        return true;
    }

    public void ChangeOfSpeed(double acceleration)
    {
        Speed += acceleration;
        DistanceTravelled();
    }

    public bool IsStopped(double speed)
    {
        return speed == 0.0;
    }
}
