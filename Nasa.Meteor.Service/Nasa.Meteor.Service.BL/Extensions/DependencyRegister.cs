using Meteor.Service.Share.Interfaces;
using Meteor.Service.Shared.Context;
using Microsoft.Extensions.DependencyInjection;
    
namespace Meteor.Service.BL.Extensions;

public static class DependencyRegister
{
    public static IServiceCollection RegisterMeteorDataLayer(this IServiceCollection services)
    {
        services.AddScoped<ISqlServerContext, SqlServerContext>();
        return services;
    }
}