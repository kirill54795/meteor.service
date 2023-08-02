namespace Meteor.Service.Share.Models.ViewModels;

public record MeteorViewModel
{
    public int Year { get; set; }
    public int MeteorAmount { get; set; }
    public double Mass { get; set; }
}