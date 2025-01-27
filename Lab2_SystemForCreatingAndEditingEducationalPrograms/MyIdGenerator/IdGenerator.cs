using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyIdGenerator;

public static class IdGenerator
{
    private static readonly Collection<int> _ids = new Collection<int>();

    private static int _count = -1;

    public static int GetId()
    {
        int id = ++_count;

        bool found = _ids.Contains(id);

        if (!found)
        {
            _ids.Add(id);
        }

        return !found ? id : GetId();
    }
}