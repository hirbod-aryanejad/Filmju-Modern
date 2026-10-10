using System;
using System.Collections.Generic;
using System.Text;

namespace Filmju_Modern.Services
{
    public class UserSession
    {
        // Credentials used for authentication
        public string Username { get; set; } = "";
        public string Token { get; set; } = "";

        // Authentication state returned by the server
        public string LoginState { get; set; } = "";
        public string Auth { get; set; } = "";

        // User information returned by the server
        public string AccountState { get; set; } = "";
        public string Name { get; set; } = "";
        public string SubscriptionExpiryDate { get; set; } = "";
        public string UserState { get; set; } = "";
        public string LanguageTitleMovies { get; set; } = "";

        // Convenient derived property
        public bool IsLoggedIn => LoginState == "T";
    }
}
