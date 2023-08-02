using Meteor.Service.Share;
using Meteor.Service.Share.Interfaces;
using Meteor.Service.Share.Models;
using Meteor.Service.Share.Models.ViewModels;
using Meteor.Service.Shared.Models.Entities;

namespace Meteor.Service.BL.Services;

public class MeteorService : IMeteorService
{
    private readonly IMeteorRepository _repository;
    private readonly MeteorServiceAbstract _service;
    private readonly ICacheService _cacheService;

    public MeteorService(IMeteorRepository repository, MeteorServiceAbstract service, ICacheService cacheService)
    {
        _repository = repository;
        _service = service;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<MeteorViewModel>> GetMeteors()
    {
        var meteors = await _repository.GetMeteors();
        return meteors.Select(m => new MeteorViewModel
        {
            Year = m.Year,
            Mass = m.ResultMass,
            MeteorAmount = m.MeteorAmount
        }).ToArray();
    }

    public async Task<IEnumerable<MeteorViewModel>> GetMeteors(Filter filter)
    {
        var meteors = await _repository.GetMeteors(filter);
        return meteors.Select(m => new MeteorViewModel
        {
            Year = m.Year,
            Mass = m.ResultMass,
            MeteorAmount = m.MeteorAmount
        }).ToArray();
    }

    public async Task<IEnumerable<string>> GetMeteorClasses()
    {
        return await _repository.GetMeteorClasses();
    }

    public async Task RefreshData()
    {
        var meteors = await _service.GetMeteorData();
        if (!meteors.IsSuccessfull)
        {
            //Put the logic of refreshing data with time interval
        }

        var fallStates = Enum.GetValues<FallStates>();
        var nameTypes = Enum.GetValues<MeteorNameTypes>();

        await _repository.AddMeteors(meteors.Value.Select(m => new Meteorite
        {
            NasaId = m.Id,
            FallState = fallStates.FirstOrDefault(f => f.ToString().Equals(m.Fall, StringComparison.InvariantCultureIgnoreCase)),
            Mass = m.Mass,
            Name = m.Name,
            NameType = m.Nametype,
            Year = m.Year,
            RecLatitude = m.Reclat,
            RecLongitude = m.Reclong,
            MeteorClasses = m.Recclass.Split(',').Select(i => new MeteorClass { Name = i }).ToList()
        }).ToList());

        var classes = await _repository.GetMeteorClasses();

        _cacheService.UpdateMeteorClassesCache(classes.ToArray());
    }
}