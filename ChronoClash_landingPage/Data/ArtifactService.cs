namespace ChronoClash_landingPage.Data;
using ChronoClash_landingPage.Data.Models;

public class ArtifactService
{
    public static async Task<List<Artifact>> GetArtifactsAsync(dynamic assets)
    {
        List<Artifact> Artifacts = new();
        try
        {
            foreach (dynamic asset in assets)
            {
                if (((string)asset.name).Contains("macOS")) 
                    Artifacts.Add(new MacOS((int)asset.id, (string)asset.name, (string)asset.browser_download_url, (int)asset.size, (int)asset.download_count));
                if (((string)asset.name).Contains("windows")) 
                    Artifacts.Add(new Windows((int)asset.id, (string)asset.name, (string)asset.browser_download_url, (int)asset.size, (int)asset.download_count));
            }
            return await Task.FromResult(Artifacts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return await Task.FromResult(Artifacts);
    }

}
