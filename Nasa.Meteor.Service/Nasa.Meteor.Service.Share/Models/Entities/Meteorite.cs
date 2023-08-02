using Meteor.Service.Share;

namespace Meteor.Service.Shared.Models.Entities;

public class Meteorite : BaseEntity
{
    public int NasaId { get; set; }
    public string Name { get; set; }
    public MeteorNameTypes NameType { get; set; }
    public float Mass { get; set; }
    public FallStates FallState { get; set; }
    public DateTime Year { get; set; }
    public double RecLatitude { get; set; }
    public double RecLongitude { get; set; }
    public object Geolocation { get; set; }

    public ICollection<MeteorClass> MeteorClasses { get; set; }
}