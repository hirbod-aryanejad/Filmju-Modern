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
        public event Action LogoutClicked;


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

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LogoutClicked?.Invoke();
        }
    }
}
