namespace Meteor.Service.Shared.Models.Entities;

public class MeteorClass : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Meteorite> Meteors { get; set; }
}