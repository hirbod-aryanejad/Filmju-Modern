using System.Text.Json.Serialization;

namespace Filmju_Modern.Models;

public class HomeResponse
{
    [JsonPropertyName("updated_serie")]
    public List<MovieItem> UpdatedSeries { get; set; } = new();

    [JsonPropertyName("NewMovie")]
    public List<MovieItem> NewMovies { get; set; } = new();

    [JsonPropertyName("NewSerie")]
    public List<MovieItem> NewSeries { get; set; } = new();
}

