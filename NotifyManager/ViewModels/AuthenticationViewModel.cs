using Caliburn.Micro;

namespace NotifyManager.ViewModels
{
    public class AuthenticationViewModel:PropertyChangedBase
    {
        private string username;
        private string password;
        private bool rememberMe;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }           

        public string Password
        {
            get { return password; }
            set { password = value; }
        }        

        public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; }
        }


    }
}
