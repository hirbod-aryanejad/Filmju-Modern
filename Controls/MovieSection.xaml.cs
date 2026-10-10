using Filmju_Modern.Models;
using System.Windows;
using System.Windows.Controls;

namespace Filmju_Modern.Controls;

public partial class MovieSection : UserControl
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(MovieSection),
            new PropertyMetadata(""));

    public static readonly DependencyProperty MoviesProperty =
        DependencyProperty.Register(
            nameof(Movies),
            typeof(IEnumerable<MovieItem>),
            typeof(MovieSection),
            new PropertyMetadata(null));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public IEnumerable<MovieItem>? Movies
    {
        get => (IEnumerable<MovieItem>?)GetValue(MoviesProperty);
        set => SetValue(MoviesProperty, value);
    }

    public MovieSection()
    {
        InitializeComponent();
    }
}

