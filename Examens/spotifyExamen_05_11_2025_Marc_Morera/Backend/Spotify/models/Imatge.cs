namespace Spotify.Model;

public class Imatge
{
    public Guid Id { get; set; }
    
    public Guid Song_Id { get; set; }
    public string Url { get; set; } = "";
    public string Hash { get; set; } = "";
    
}