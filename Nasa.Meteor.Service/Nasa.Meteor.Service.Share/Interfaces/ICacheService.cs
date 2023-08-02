namespace Meteor.Service.Share.Interfaces;

public interface ICacheService
{
    IEnumerable<string> GetMeteorClasses();
    void UpdateMeteorClassesCache(string[] classes);
}