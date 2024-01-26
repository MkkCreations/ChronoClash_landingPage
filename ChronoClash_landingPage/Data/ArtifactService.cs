namespace ChronoClash_landingPage.Data;

public class ArtifactService
{
    public static async Task<List<Artifact>> GetArtifactsAsync(dynamic assets)
    {
        List<Artifact> Artifacts = new();
        try
        {
            foreach (dynamic asset in assets)
            {
                if (asset.name == "ChronoClash_macOS.zip") 
                    Artifacts.Add(new MacOS((int)asset.id, (string)asset.name, (string)asset.browser_download_url, (int)asset.size));
                if (asset.name == "ChronoClash_windows.zip") 
                    Artifacts.Add(new Windows((int)asset.id, (string)asset.name, (string)asset.browser_download_url, (int)asset.size));
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
