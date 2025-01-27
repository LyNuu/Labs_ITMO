using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection;

public interface IRouteSection
{
    double Distance { get; }

    public Result RouteLaunch(ITrain train);
}