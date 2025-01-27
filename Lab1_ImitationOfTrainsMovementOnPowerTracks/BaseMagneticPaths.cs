using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection;

public class BaseMagneticPaths : IRouteSection
{
    private double _distanceTraveledBefore;

    public double Distance { get; }

    private double Force { get; }

    public BaseMagneticPaths(double force, double baseMagneticDistance)
    {
        Distance = baseMagneticDistance;
        Force = force;
    }

    public Result RouteLaunch(ITrain train)
    {
        _distanceTraveledBefore = train.DistanceTravelled();
        double copyDistance = Distance;
        bool resultGetForce = train.CanApplyForce(Force);
        if (resultGetForce)
        {
            while (copyDistance > 0)
            {
                train.DistanceTravelled();
                copyDistance -= train.DistanceTravelled() - _distanceTraveledBefore;
            }

            return new Result.Success();
        }

        return new Result.Unsuccess();
    }
}