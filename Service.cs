using _2._5.Models;

namespace _2._5;

public class Service
{
    private static Context? _db;
    public static Context  GetDbContext()
    {
        if (_db == null)
        {
            _db = new Context();
        }
        return _db;
    }
}