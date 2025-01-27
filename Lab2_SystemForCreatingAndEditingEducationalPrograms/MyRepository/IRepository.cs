using Itmo.ObjectOrientedProgramming.Lab2.MySubject;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyRepository;

public interface IRepository
{
    void Add(ISubject subject);

    Result Find(int id);
}