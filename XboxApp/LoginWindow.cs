using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace XboxApp
{
    class LoginWindow : Window
    {
        // [UI] private WebView webkitview = null;

        public LoginWindow() : this(new Builder("LoginWindow.glade")) { }

        private LoginWindow(Builder builder) : base(builder.GetObject("LoginWindow").Handle)
        {
            builder.Autoconnect(this);

            ConfigureLoginWindow();
            ConfigureEventHandlers();
        }

        private void ConfigureLoginWindow()
        {
            this.SetDefaultSize(900, 640);
        }

        private void ConfigureEventHandlers()
        {
            DeleteEvent += Window_DeleteEvent;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        public void OnLoginShow(object sender, EventArgs a)
        {
            Console.WriteLine("OnLoginShow was called!");
        }
    }
}
