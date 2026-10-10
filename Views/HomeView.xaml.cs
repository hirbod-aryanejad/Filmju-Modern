
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using Filmju_Modern.Models;

namespace Filmju_Modern.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        SetLoading(true);
    }

    public void SetLoading(bool isLoading)
    {
        LoadingPanel.Visibility = isLoading
            ? Visibility.Visible
            : Visibility.Collapsed;

        SectionsList.Visibility = isLoading
            ? Visibility.Collapsed
            : Visibility.Visible;
    }

    public void DisplayData(HomeResponse response)
    {
        var sections = new List<MovieSectionData>
        {
            new()
            {
                Title = "Recently Updated Series",
                Movies = response.UpdatedSeries
            },
            new()
            {
                Title = "New Movies",
                Movies = response.NewMovies
            },
            new()
            {
                Title = "New Series",
                Movies = response.NewSeries
            }
        };

        SectionsList.ItemsSource = sections;
        SetLoading(false);
    }

    public void DisplayJson(string json)
    {
        HomeResponse? response =
            JsonSerializer.Deserialize<HomeResponse>(json);

        if (response == null)
            throw new JsonException("The home response was empty.");

        DisplayData(response);
    }
}
