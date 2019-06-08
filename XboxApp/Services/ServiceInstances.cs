using System;
using XboxWebApi.Authentication;
using XboxWebApi.Services;

namespace XboxApp.Services
{
    public static class ServiceInstances
    {
        private static Lazy<AuthenticationService> _authenticationService =
            new Lazy<AuthenticationService>(() => new AuthenticationService());
        public static AuthenticationService AuthenticationService => _authenticationService.Value;
    }
}