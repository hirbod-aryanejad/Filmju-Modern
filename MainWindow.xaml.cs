using Filmju_Modern.Services;
using Filmju_Modern.Views;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;


namespace Filmju_Modern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SessionManager _sessionManager;
        private readonly FilmjuApi _filmjuApi = new();
        private HomeView? _homeView;

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 0x0002;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

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

            Sidebar.HomeClicked += async () => await Navigate(Page.Home);
            Sidebar.FavoritesClicked += async () => await Navigate(Page.Favorites);
            Sidebar.SettingsClicked += async () => await Navigate(Page.Settings);

            _sessionManager = new SessionManager();

            Loaded += MainWindow_Loaded;


        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool restored = await _sessionManager.RestoreSessionAsync();

            Sidebar.UpdateUserDisplay(_sessionManager.CurrentSession);

            await Navigate(Page.Home);

            if (restored)
            {
                // Show the home view.
            }
            else
            {
                // Show the login view.
            }
        }



        #region UI Logic
        async Task Navigate(Page page)
        {
            if (_currentPage == page) return;

            _currentPage = page;

            switch (page)
            {
                case Page.Home:

                    if (_homeView != null)
                    {
                        MainContent.Content = _homeView;
                        break;
                    }

                    _homeView = new HomeView();
                    MainContent.Content = _homeView;

                    try
                    {
                        string json = await _filmjuApi.GetHomeDataAsync();
                        _homeView.DisplayJson(json);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    break;


                case Page.Favorites:
                    MainContent.Content = new FavoritesView();
                    break;

                case Page.Settings:
                    MainContent.Content = new SettingsView();
                    break;
            }
        }

        //Draging
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;

            var window = Window.GetWindow(this);

            if (window == null)
                return;

            var handle = new WindowInteropHelper(window).Handle;

            SendMessage(handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);
        }
        #endregion

        public static string ToEnglishDigits(string text)
        {
            return text
                .Replace('۰', '0')
                .Replace('۱', '1')
                .Replace('۲', '2')
                .Replace('۳', '3')
                .Replace('۴', '4')
                .Replace('۵', '5')
                .Replace('۶', '6')
                .Replace('۷', '7')
                .Replace('۸', '8')
                .Replace('۹', '9');
        }
    }
}