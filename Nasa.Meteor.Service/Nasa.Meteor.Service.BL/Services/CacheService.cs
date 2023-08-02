using Meteor.Service.Share.Interfaces;

namespace Meteor.Service.BL.Services;

public class CacheService : ICacheService
{
    private string[] _meteorClasses;
    private object _syncObj;
    private DateTime _updatedOn;

    public CacheService() => _syncObj = new object();

    public DateTime UpdatedOn => _updatedOn;

    public IEnumerable<string> GetMeteorClasses()
    {
        return _meteorClasses;
    }

    public void UpdateMeteorClassesCache(string[] classes)
    {
        lock (_syncObj)
        {
            if (classes == null || classes.Length == 0)
            {
                throw new ArgumentException("Meteor classes should be defined");
            }

            _meteorClasses = classes;

            _updatedOn = DateTime.Now;
        }
    }
}