using System.ComponentModel.DataAnnotations;

namespace Meteor.Service.Share.Models;

public class Filter
{
    public int YearFrom { get; set; }
    public int YearTo { get; set; }
    
    [MaxLength(100, ErrorMessage = "The max lenght of Name shouldn't be greater than 100")]
    public string Name { get; set; }
    
    [MaxLength(100, ErrorMessage = "The max lenght of Class shouldn't be greater than 100")]
    public string Class { get; set; }
}