using Filmju_Modern.Views;
using System.Windows;
using System.Windows.Input;

namespace Filmju_Modern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Page _currentPage = Page.None;
        enum Page
        {
            None,
            Home,
            Favorites,
            Settings
        }

        public MainWindow()
        {
            InitializeComponent();

            Sidebar.HomeClicked += () => Navigate(Page.Home);
            Sidebar.FavoritesClicked += () => Navigate(Page.Favorites);
            Sidebar.SettingsClicked += () => Navigate(Page.Settings);

            Navigate(Page.Home);
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        void Navigate(Page page)
        {
            if (_currentPage == page) return;

            _currentPage = page;

            switch (page)
            {
                case Page.Home:
                    MainContent.Content = new HomeView();
                    break;

                case Page.Favorites:
                    MainContent.Content = new FavoritesView();
                    break;

                case Page.Settings:
                    //MainContent.Content = new SettingsView();
                    break;
            }
        }
    }
}