using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace XboxApp
{
    class LoginWindow : Window
    {
        [UI] private WebView webkitview = null;

        public LoginWindow() : this(new Builder("LoginWindow.glade")) { }

        private LoginWindow(Builder builder) : base(builder.GetObject("LoginWindow").Handle)
        {
            builder.Autoconnect(this);

            ConfigureLoginWindow(app);
            ConfigureEventHandlers();
        }

        private void ConfigureLoginWindow(Application app) {
            this.set_default_size (900, 640);
        }

        private void ConfigureEventHandlers() {
            DeleteEvent += Window_DeleteEvent;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
