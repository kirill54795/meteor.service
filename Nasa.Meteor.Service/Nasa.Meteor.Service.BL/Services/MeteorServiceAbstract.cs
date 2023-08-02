using Meteor.Service.BL.Models;
using Meteor.Service.Share;

namespace Meteor.Service.BL.Services;

public abstract class MeteorServiceAbstract
{
    public abstract Task<Result<IEnumerable<NasaMeteorModel>>> GetMeteorData();
}