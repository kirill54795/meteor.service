using Meteor.Service.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meteor.Service.Share.Interfaces;

public interface ISqlServerContext
{
    DbSet<Meteorite> Meteors { get; set; }
    DbSet<MeteorClass> MeteorClasses { get; set; }

    void SaveContextChanges();
}