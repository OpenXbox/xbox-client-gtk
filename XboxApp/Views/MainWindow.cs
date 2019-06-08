using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

using XboxApp.ViewModels;

namespace XboxApp.Views
{
    class MainWindow : Window
    {
        private readonly MainViewModel viewModel = new MainViewModel();
        [UI] private Button settingsButton = null;
        [UI] private Button refreshButton = null;

        [UI] private Gtk.Paned menuPane = null;
        [UI] private Gtk.ListBox menuList = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);

            ConfigureMainWindow();
            ConfigureEventHandlers();
        }

        private void ConfigureMainWindow()
        {
            this.SetDefaultSize(900, 640);
        }

        private void ConfigureEventHandlers() {
            DeleteEvent += (sender, args) =>
            {
                Application.Quit();
            };

            this.refreshButton.Clicked += (sender, args) =>
            {
                // Refresh stuff
            };

            this.settingsButton.Clicked += (sender, args) =>
            {
                var window = new LoginWindow();
                window.Show();
            };

            this.menuList.ListRowActivated += MenuItemSelected;
        }

        private void MenuItemSelected(object sender, ListRowActivatedArgs args)
        {
            var uglyId = ((Gtk.Label)((Gtk.Grid)args.Row.Child).Children[0]).LabelProp;
            switch (uglyId)
            {
                case "Home":
                    break;
                case "Friends":
                    break;
                case "Messages":
                    break;
                case "Achievements":
                    break;
                case "Feed":
                    break;
                case "Stream":
                    break;
                default:
                    throw new NotImplementedException($"Invalid menu item, name: {uglyId}");
            }
        }
    }
}
