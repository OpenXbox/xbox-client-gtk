using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

using XboxWebApi.Authentication;


namespace XboxApp
{
    class LoginFrame : Frame
    {
        [UI] private Gtk.LinkButton authenticationUrl = null;
        [UI] private Gtk.Entry redirectUrlEntry = null;
        [UI] private Gtk.Button loginButton = null;
        [UI] private Gtk.Label statusLabel = null;
        [UI] private Gtk.Spinner activitySpinner = null;

        public LoginFrame() : this(new Builder("LoginFrame.glade")) { }

        private LoginFrame(Builder builder) : base(builder.GetObject("LoginFrame").Handle)
        {
            builder.Autoconnect(this);

            ConfigureLoginWindow();
            ConfigureEventHandlers();
        }

        private void ConfigureLoginWindow()
        {
        }

        private void ConfigureEventHandlers()
        {
            DeleteEvent += Window_DeleteEvent;
            loginButton.Clicked += OnLoginButtonClicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
        }

        private void OnLoginButtonClicked(object sender, EventArgs a)
        {
            var redirectUrl = redirectUrlEntry.Text;
            if (String.IsNullOrEmpty(redirectUrl))
            {
                statusLabel.Text = "Invalid redirect URL passed";
                return;
            }
        }

        public void OnLoginShow(object sender, EventArgs a)
        {
            authenticationUrl.Uri = AuthenticationService.GetWindowsLiveAuthenticationUrl();
            Console.WriteLine("OnLoginShow was called!");
        }
    }
}
