using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection;

public class PowerModule : IRouteSection
{
    private double _fixSpeedBefore;

    public PowerModule(double maxSpeed, double distance, double force = 100)
    {
        Force = force;
        Distance = distance;
        MaxSpeed = maxSpeed;
    }

    public double Force { get; }

    public double MaxSpeed { get; }

    public double DistanceTraveledBefore { get; private set; }

    public double Acceleration { get; private set; }

    public double Weight { get; private set; }

    public double Distance { get; }

    public Result RouteLaunch(ITrain train)
    {
        _fixSpeedBefore = train.Speed;
        Weight = train.Weight;
        Acceleration = Force / Weight;
        double copyDistance = Distance;
        DistanceTraveledBefore = train.DistanceTravelled();

        if (train.Speed > MaxSpeed)
        {
            train.ResultingSpeed();
            train.DistanceTravelled();

            return new Result.Unsuccess();
        }

        while (copyDistance > 0.0)
        {
            train.ChangeOfSpeed(-Acceleration);
            train.ResultingSpeed();
            copyDistance -= train.DistanceTravelled() - DistanceTraveledBefore;
        }

        double speed = train.Speed;
        train.ChangeOfSpeed(-speed);

        bool isStopeed = train.IsStopped(train.Speed);
        if (isStopeed)
        {
            double copySpeed = train.Speed;
            while (copySpeed < _fixSpeedBefore)
            {
                train.ChangeOfSpeed(Acceleration);
                train.ResultingSpeed();
                copySpeed = train.Speed;
                train.DistanceTravelled();
            }

            train.ChangeOfSpeed(-(copySpeed - _fixSpeedBefore));

            train.DistanceTravelled();
        }

        return new Result.Success();
    }
}