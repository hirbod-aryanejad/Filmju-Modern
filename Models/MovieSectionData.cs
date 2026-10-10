namespace Filmju_Modern.Models;

public class MovieSectionData
{
    public string Title { get; set; } = "";

    public IReadOnlyList<MovieItem> Movies { get; set; }= Array.Empty<MovieItem>();
}
