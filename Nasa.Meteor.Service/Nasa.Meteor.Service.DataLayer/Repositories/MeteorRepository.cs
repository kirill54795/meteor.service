using Meteor.Service.Share.Interfaces;
using Meteor.Service.Share.Models;
using Meteor.Service.Shared.Models.DTO;
using Meteor.Service.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meteor.Service.DataLayer.Repositories;

public class MeteorRepository : IMeteorRepository
{
    private readonly ISqlServerContext _context;

    public MeteorRepository(ISqlServerContext context)
    {
        _context = context;
    }

    public async Task AddMeteors(IEnumerable<Meteorite> meteors)
    {
        var counter = 0;
        var amountElements = 5;
        IEnumerable<Meteorite> tempMets;

        var meteorsDb = await _context.Meteors.Select(m => m.NasaId).ToListAsync();

        for (int i = 1; meteors.Count() > i * amountElements; i++)
        {
            counter = i;
            tempMets = meteors.Skip((i - 1) * amountElements).Take(amountElements);
            var newMeteors = meteors.Where(m => !meteorsDb.Any(id => id != m.NasaId));
            _context.Meteors.AddRange(newMeteors);
        }
        tempMets = meteors.Skip((counter == 0 ? 1 : counter - 1) * amountElements).Take(amountElements * counter - meteors.Count());

        var newLastMeteors = meteors.Where(m => !meteorsDb.Any(id => id != m.NasaId));
        _context.Meteors.AddRange(newLastMeteors);

        _context.SaveContextChanges();
    }

    public async Task<IEnumerable<MeteorDto>> GetMeteors()
    {
        var meteors = await _context.Meteors.GroupBy(m => m.Year.Year).Select(m => new
        {
            Year = m.Key,
            Amount = m.Count(),
            Mass = m.Sum(i => i.Mass),
        }).ToListAsync();

        return meteors.Select(m => new MeteorDto
        {
            Year = m.Year,
            MeteorAmount = m.Amount,
            ResultMass = m.Mass
        });
    }

    public async Task<IEnumerable<MeteorDto>> GetMeteors(Filter filter)
    {
        var query = _context.Meteors.AsQueryable();

        if (filter.YearFrom != 0)
        {
            query.Where(m => m.Year.Year >= filter.YearFrom);
        }

        if (filter.YearTo != 0)
        {
            query.Where(m => m.Year.Year <= filter.YearTo);
        }

        if (string.IsNullOrEmpty(filter.Name))
        {
            query.Where(m => m.Name.Contains(filter.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        if(string.IsNullOrEmpty(filter.Class))
        {
            query.Where(m => m.MeteorClasses.Any(c => c.Name.Equals(filter.Name, StringComparison.InvariantCultureIgnoreCase)));
        }

        var meteors = await query.GroupBy(m => m.Year.Year).Select(m => new
        {
            Year = m.Key,
            Amount = m.Count(),
            Mass = m.Sum(i => i.Mass),
        }).ToListAsync();

        return meteors.Select(m => new MeteorDto
        {
            Year = m.Year,
            MeteorAmount = m.Amount,
            ResultMass = m.Mass
        });
    }

    public async Task<IEnumerable<string>> GetMeteorClasses()
    {
        return await _context.MeteorClasses.Select(m => m.Name).ToListAsync();
    }
}