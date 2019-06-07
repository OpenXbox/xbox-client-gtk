# Xbox App (Desktop / Multi platform)
Uses [GtkSharp bindings](https://github.com/GtkSharp/GtkSharp), [SmartGlass](https://github.com/OpenXbox/xbox-smartglass-csharp) and [Xbox WebApi](https://github.com/OpenXbox/xbox-webapi-csharp).
Based on the initial work of @gffranco in the [Vala client](https://github.com/OpenXbox/xbox-client-vala).

## Dependency installation
Project requires
* Gtk+ 3
* [.NET Core SDK 2.2+](https://dotnet.microsoft.com/download)

### macOS
Use the [homebrew package manager](https://brew.sh) to install dependencies.
```
brew install gtk+3
```

### Linux
TBD

### Windows
Refer to [GtkSharp instructions](https://github.com/GtkSharp/GtkSharp/wiki/Installing-Gtk-on-Windows).

## Building from source
Use VS Code, Visual Studio 2017+ or Visual Studio for Mac to develop in a graphical IDE.


To build headless, via cmdline:
```
dotnet build
```

## Releases
When done, they should appear here: [GitHub releases](https://github.com/OpenXbox/xbox-client-gtk/releases)

## Troubleshooting
Common problems

### DllNotFoundException when starting the application
Ensure you got the GTK dependencies installed properly.