using Filmju_Modern.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filmju_Modern
{
    /// <summary>
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : UserControl
    {
        public event Action HomeClicked;
        public event Action FavoritesClicked;
        public event Action SettingsClicked;
        public event Action UserClicked;


        public Sidebar()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            HomeClicked?.Invoke();
        }

        private void FavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            FavoritesClicked?.Invoke();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsClicked?.Invoke();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserClicked?.Invoke();
        }

        public void UpdateUserDisplay(UserSession? session)
        {
            if (session?.IsLoggedIn == true)
            {
                UserNameText.Text = string.IsNullOrWhiteSpace(session.Name)
                    ? session.Username
                    : session.Name;

                UserExpiryText.Text =
                    session.AccountState == "T"
                        ? $"Expires: {MainWindow.ToEnglishDigits(session.SubscriptionExpiryDate)}"
                        : "Subscription expired";

                UserExpiryText.Visibility = Visibility.Visible;
            }
            else
            {
                UserNameText.Text = "Not logged in";
                UserExpiryText.Text = "";
                UserExpiryText.Visibility = Visibility.Collapsed;
            }
        }
    }
}
