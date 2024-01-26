namespace ChronoClash_landingPage.Data;

public abstract class Artifact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string URL { get; set; }
    public int Size { get; set; }

    public Artifact(int id, string name, string url, int size)
    {
        Id = id;
        Name = name;
        URL = url;
        Size = size / 1000000;
    }
}

