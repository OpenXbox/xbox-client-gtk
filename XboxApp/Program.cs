using System;
using Gtk;

namespace XboxApp
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.OpenXbox.XboxApp", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new Views.MainWindow();
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }
    }
}
