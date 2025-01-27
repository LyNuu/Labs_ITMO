namespace Itmo.ObjectOrientedProgramming.Lab1.Train;

public interface ITrain
{
     double DistanceTravelled();

     double Speed { get; }

     double Weight { get; }

     void ChangeOfSpeed(double acceleration);

     void ResultingSpeed();

     bool CanApplyForce(double force);

     bool IsStopped(double speed);
}