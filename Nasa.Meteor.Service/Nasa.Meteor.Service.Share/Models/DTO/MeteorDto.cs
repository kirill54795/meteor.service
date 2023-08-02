namespace Meteor.Service.Shared.Models.DTO;

public class MeteorDto
{
    public string Name { get; set; }
    public int NasaId { get; set; }
    public IEnumerable<string> Classes { get; set; }
    public int Year { get; set; }
    public int MeteorAmount { get; set; }
    public double ResultMass { get; set; }
}