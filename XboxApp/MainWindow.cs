using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace XboxApp
{
    class MainWindow : Window
    {
        [UI] private Button settingsButton = null;
        [UI] private Button refreshButton = null;

        [UI] private Gtk.Paned menuPane = null;
        [UI] private Gtk.Fixed content = null;

        private LoginFrame loginFrame = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);

            loginFrame = new LoginFrame();

            ConfigureMainWindow();
            ConfigureEventHandlers();
        }

        private void ConfigureMainWindow()
        {
            this.SetDefaultSize(900, 640);
            content.Add(loginFrame);
        }

        private void ConfigureEventHandlers() {
            DeleteEvent += Window_DeleteEvent;
            this.refreshButton.Clicked += RefreshButton_Clicked;
        }

        private void RefreshButton_Clicked(object sender, EventArgs a)
        {
            Console.WriteLine("RefreshButton clicked");
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
