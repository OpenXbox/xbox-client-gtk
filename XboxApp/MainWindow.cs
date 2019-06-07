using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace XboxApp
{
    class MainWindow : Window
    {
        [UI] private WebView webkitview = null;
        [UI] private Button refreshButton = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);

            ConfigureMainWindow(app);
            ConfigureWebView();
            ConfigureEventHandlers();
        }

        private void ConfigureWebView() {
            this.webkitview.load_uri("http://openxbox.org");
        }

        private void ConfigureMainWindow(Application app) {
            this.set_default_size (900, 640);
            this.set_application (app);
        }

        private void ConfigureEventHandlers() {
            DeleteEvent += Window_DeleteEvent;
            this.refreshButton.Clicked += RefreshButton_Clicked;
        }

        private void RefreshButton_Clicked(object sender, EventArgs a)
        {
            LoginWindow login = new LoginWindow();
            login.show_all();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
