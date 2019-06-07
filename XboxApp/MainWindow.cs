using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace XboxApp
{
    class MainWindow : Window
    {
        //[UI] private WebView webkitview = null;
        [UI] private Button refreshButton = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);

            ConfigureMainWindow();
            ConfigureWebView();
            ConfigureEventHandlers();
        }

        private void ConfigureWebView()
        {
            // this.webkitview.LoadUri("http://openxbox.org");
        }

        private void ConfigureMainWindow()
        {
            this.SetDefaultSize(900, 640);
            // this.SetApplication(app);
        }

        private void ConfigureEventHandlers() {
            DeleteEvent += Window_DeleteEvent;
            this.refreshButton.Clicked += RefreshButton_Clicked;
        }

        private void RefreshButton_Clicked(object sender, EventArgs a)
        {
            LoginWindow login = new LoginWindow();
            login.ShowAll();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
