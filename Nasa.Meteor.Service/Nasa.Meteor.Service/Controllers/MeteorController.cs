using Meteor.Service.Share.Interfaces;
using Meteor.Service.Share.Models;
using Meteor.Service.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Meteor.Service.Controllers;

[Route("api/meteors")]
public class MeteorController : Controller
{
    private IMeteorService _meteorService;

    public MeteorController(IMeteorService meteorService)
    {
        _meteorService = meteorService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Meteorite>> Get()
    {
        return Ok(_meteorService.GetMeteors());
    }

    [HttpGet("filter")]
    public ActionResult<IEnumerable<Meteorite>> Get(Filter filter)
    {
        if (filter.YearFrom != 0 && filter.YearFrom > DateTime.Now.Year || filter.YearFrom < 1700)
        {
            ModelState.AddModelError("YearFrom", "YearFrom is not valid. It's greater than 1700 or more current year");
        }

        if (filter.YearTo != 0 && filter.YearTo > DateTime.Now.Year || filter.YearFrom < 1700)
        {
            ModelState.AddModelError("YearTo", "YearTo is not valid. It's greater than 1700 or more current year");
        }

        if (filter.YearFrom > filter.YearTo)
        {
            ModelState.AddModelError("YearFrom", "YearFrom more than YearTo");
        }

        if (filter.Class.Length > 100)
        {
            ModelState.AddModelError("Class", "Class shouldn't be more 100");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_meteorService.GetMeteors(filter));
    }

    [HttpGet("classes")]
    public async Task<ActionResult<IEnumerable<string>>> GetClasses()
    {
        return Ok(await _meteorService.GetMeteorClasses());
    }

    [HttpGet("refresh")]
    public async Task<ActionResult> RefreshData()
    {
        await _meteorService.RefreshData();
        return Ok();
    }
}