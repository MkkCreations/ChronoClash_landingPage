namespace ChronoClash_landingPage.Data;

using System.Net.Http;
using Newtonsoft.Json.Linq;

public class ReleaseService
{
    public static async Task<Release> GetRelease()
    {
        HttpClient client = new();
        client.DefaultRequestHeaders.Add("User-Agent", "MkkCreations");
        HttpResponseMessage response = await client.GetAsync("https://api.github.com/repos/MkkCreations/ChronoClash/releases/latest");
        response.EnsureSuccessStatusCode();
        HttpContent content = response.Content;
        string json = await content.ReadAsStringAsync();
        dynamic data = JObject.Parse(json);
        return await Task.FromResult(new Release((string)data.name, (string)data.html_url, (string)data.published_at, (string)data.tag_name, (string)data.body, await ArtifactService.GetArtifactsAsync(data.assets)));
    }
}