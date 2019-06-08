using System;
using System.Threading.Tasks;

using XboxApp.MVVM;

using XboxWebApi.Authentication;

namespace XboxApp.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public AuthenticationService AuthService => Services.ServiceInstances.AuthenticationService;
        public string AuthenticationUrl =>
            AuthenticationService.GetWindowsLiveAuthenticationUrl();
        
        bool _isAuthenticated = false;
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set { SetProperty(ref _isAuthenticated, value); }
        }

        public LoginViewModel()
        {
        }

        public async Task DoAuthentication(string redirectUrl)
        {
            if (String.IsNullOrEmpty(redirectUrl))
            {
                base.StatusText = "Invalid redirect URL passed";
                return;
            }

            base.StatusText = "Authenticating...";
            IsBusy = true;

            try
            {
                var response = AuthenticationService.ParseWindowsLiveResponse(redirectUrl);
                AuthService.AccessToken = new AccessToken(response);
                AuthService.RefreshToken = new RefreshToken(response);

                IsAuthenticated = await AuthService.AuthenticateAsync();
                
                StatusText = "Authentication succeeded";
            }
            catch (Exception e)
            {
                StatusText = $"Authentication failed: {e}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}