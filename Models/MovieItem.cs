using System.Text.Json.Serialization;

namespace Filmju_Modern.Models;

public class MovieItem
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("title")]
    public string Title { get; set; } = "";

    [JsonPropertyName("thumbnail_url")]
    public string PosterUrl { get; set; } = "";

    [JsonPropertyName("year")]
    public string Year { get; set; } = "";

    [JsonPropertyName("imdb")]
    public string ImdbRating { get; set; } = "";

    [JsonPropertyName("videos_id")]
    public string VideosId { get; set; } = "";
}

