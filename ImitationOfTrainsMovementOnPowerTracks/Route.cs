using Itmo.ObjectOrientedProgramming.Lab1.RouteSection;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    public Route(IReadOnlyCollection<IRouteSection> routeSections)
    {
        RouteSections = routeSections;
    }

    public IReadOnlyCollection<IRouteSection> RouteSections { get; }

    public Result RouteResult(ITrain train)
    {
        var results = new List<Result.Success>();

        int count = 0;

        foreach (IRouteSection routeSection in RouteSections)
        {
            Result result = routeSection.RouteLaunch(train);

            if (result is Result.Success)
            {
                results.Add(new Result.Success());
            }

            count++;
        }

        return results.Count == count ? new Result.Success() : new Result.Unsuccess();
    }
}