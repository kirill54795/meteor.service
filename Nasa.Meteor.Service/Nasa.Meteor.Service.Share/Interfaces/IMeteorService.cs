using Meteor.Service.Share.Models;
using Meteor.Service.Share.Models.ViewModels;

namespace Meteor.Service.Share.Interfaces;

public interface IMeteorService
{
    Task<IEnumerable<MeteorViewModel>> GetMeteors();
    Task<IEnumerable<MeteorViewModel>> GetMeteors(Filter filter);
    Task<IEnumerable<string>> GetMeteorClasses();
    Task RefreshData();
}