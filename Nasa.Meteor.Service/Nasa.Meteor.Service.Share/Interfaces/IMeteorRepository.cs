using Meteor.Service.Share.Models;
using Meteor.Service.Shared.Models.DTO;
using Meteor.Service.Shared.Models.Entities;

namespace Meteor.Service.Share.Interfaces;

public interface IMeteorRepository
{
    Task AddMeteors(IEnumerable<Meteorite> meteors);
    Task<IEnumerable<string>> GetMeteorClasses();
    Task<IEnumerable<MeteorDto>> GetMeteors();
    Task<IEnumerable<MeteorDto>> GetMeteors(Filter filter);
}