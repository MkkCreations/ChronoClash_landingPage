namespace ChronoClash_landingPage.Data.Models;

public class Release
{
    public string Name { get; set; }
    public string URL { get; set; }
    public string PublishedAt { get; set; }
    public string Version { get; set; }
    public string Body { get; set; }
    public List<Artifact> Artifacts { get; set; }

    public Release(string name, string url, string publishedAt, string version, string body, List<Artifact> artifacts)
    {
        Name = name;
        URL = url;
        PublishedAt = $"{(DateTime.Now - DateTime.Parse(publishedAt)).Days} days ago";
        Version = version;
        Body = body;
        Artifacts = artifacts;
    }
}