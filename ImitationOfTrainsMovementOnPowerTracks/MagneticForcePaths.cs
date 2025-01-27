using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection;

public class MagneticForcePaths : IRouteSection
{
    private double MagneticForce { get; }

    private double _acceleration;

    private double _distanceTraveledBefore;

    public double Distance { get; }

    public double Weight { get; private set; }

    public MagneticForcePaths(double force, double distance)
    {
        Distance = distance;
        MagneticForce = force;
    }

    public Result RouteLaunch(ITrain train)
    {
        _distanceTraveledBefore = train.DistanceTravelled();
        Weight = train.Weight;
        _acceleration = MagneticForce / Weight;

        double copyDistance = Distance;

        bool resultGetForce = train.CanApplyForce(MagneticForce);

        double copySpeed = train.Speed;

        if (resultGetForce)
        {
            train.ChangeOfSpeed(_acceleration);

            while (copyDistance > 0)
            {
                train.DistanceTravelled();
                copyDistance -= train.DistanceTravelled() - _distanceTraveledBefore;
            }

            train.ChangeOfSpeed(-(train.Speed - copySpeed));
            return new Result.Success();
        }

        return new Result.Unsuccess();
        }
}