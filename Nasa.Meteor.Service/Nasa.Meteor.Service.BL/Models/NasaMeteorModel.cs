using Meteor.Service.Share;

namespace Meteor.Service.BL.Models;

public class NasaMeteorModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public MeteorNameTypes Nametype { get; set; }
    public string Fall { get; set; }
    public string Recclass { get; set; }
    public float Mass { get; set; }
    public DateTime Year { get; set; }
    public double Reclat { get; set; }
    public double Reclong { get; set; }
    public string Geolocation { get; set; }
}