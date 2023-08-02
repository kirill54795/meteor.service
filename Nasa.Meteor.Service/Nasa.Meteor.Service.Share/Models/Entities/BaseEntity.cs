namespace Meteor.Service.Shared.Models.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
}