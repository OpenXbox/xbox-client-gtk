using System;
using System.Windows.Input;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

using XboxWebApi.Authentication;
using System.Threading.Tasks;
using XboxApp.ViewModels;
using System.ComponentModel;

namespace XboxApp.Views
{
    class LoginWindow : Window
    {
        private readonly LoginViewModel viewModel = new LoginViewModel();
        [UI] private Gtk.LinkButton authenticationUrl = null;
        [UI] private Gtk.Entry redirectUrlEntry = null;
        [UI] private Gtk.Button loginButton = null;
        [UI] private Gtk.Label statusLabel = null;
        [UI] private Gtk.Spinner activitySpinner = null;

        public LoginWindow() : this(new Builder("LoginWindow.glade")) { }

        private LoginWindow(Builder builder) : base(builder.GetObject("LoginWindow").Handle)
        {
            builder.Autoconnect(this);

            ConfigureLoginWindow();
            ConfigureEventHandlers();
        }

        private void ConfigureLoginWindow()
        {
            authenticationUrl.Uri = viewModel.AuthenticationUrl;
        }

        private void ConfigureEventHandlers()
        {
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
            DeleteEvent += Window_DeleteEvent;
            loginButton.Clicked += OnLoginButtonClicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs args)
        {
        }

        private async void OnLoginButtonClicked(object sender, EventArgs args)
        {
            await viewModel.DoAuthentication(redirectUrlEntry.Text);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.Equals("IsBusy"))
            {
                if (viewModel.IsBusy)
                {
                    loginButton.Sensitive = false;
                    activitySpinner.Start();
                }
                else
                {
                    activitySpinner.Stop();
                    loginButton.Sensitive = true;
                }
            }
            else if (args.PropertyName.Equals("StatusText"))
            {
                statusLabel.Text = viewModel.StatusText;
            }
            else if (args.PropertyName.Equals("IsAuthenticated"))
            {
                if (viewModel.IsAuthenticated)
                {
                    this.Hide();
                }
            }
        }
    }
}
