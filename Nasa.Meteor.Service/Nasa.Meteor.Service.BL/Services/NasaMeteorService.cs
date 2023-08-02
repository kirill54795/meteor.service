using Meteor.Service.BL.Models;
using Meteor.Service.Share;
using System.Net;
using System.Net.Http.Json;

namespace Meteor.Service.BL.Services;

public class NasaMeteorService : MeteorServiceAbstract
{
    private readonly IHttpClientFactory _clientFactory;
    private string _nasaUrl = "https://data.nasa.gov/resource/y77d-th95.json";

    public NasaMeteorService(IHttpClientFactory clientFactory)
    {
        this._clientFactory = clientFactory;
    }

    public override async Task<Result<IEnumerable<NasaMeteorModel>>> GetMeteorData()
    {
        IEnumerable<NasaMeteorModel> nasaMeteors = new NasaMeteorModel[0];
        var client = _clientFactory.CreateClient();

        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _nasaUrl);

        using var response = await client.GetAsync(_nasaUrl);

        if (response.StatusCode == HttpStatusCode.NotModified || response.StatusCode == HttpStatusCode.OK)
        {
            nasaMeteors = await response.Content.ReadFromJsonAsync<IEnumerable<NasaMeteorModel>>();
            return new Result<IEnumerable<NasaMeteorModel>>(true) { Value = nasaMeteors };
        }
        else
        {
            string? error = await response.Content.ReadFromJsonAsync<string>();
            return new Result<IEnumerable<NasaMeteorModel>>(false, $"Nasa server responded unsuccessfully. Message: {error}");
            // Logger.Log("Nasa server responded unsuccessfully. Please, try again later")
        }
    }
}