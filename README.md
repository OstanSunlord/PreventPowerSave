# PreventPowerSave

A Windows desktop application that prevents your screen from locking and the system from entering power-save mode. Built on .NET Framework 4.7.2 (WinForms) and uses the Windows API `SetThreadExecutionState` under the hood.

Originally created to work around policy-enforced screen lock timeouts.

## Requirements

- Windows 10 or later
- [.NET Framework 4.7.2 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) (already included in Windows 10 1803+)

## Installation

A prebuilt installer is included in the repository under `Setup/Release/`:

1. Run `Setup/Release/setup.exe`
2. Follow the installer wizard
3. Launch **Prevent PowerSave** from the Start menu

If you prefer to build from source, see the [Build](#build) section below.

## Features

- **Timed or Endless mode** — run for a configured interval (minutes) or indefinitely
- **AFK prevention** — sends a 1-pixel mouse jiggle every 30 seconds when idle for ~4.5 minutes, keeping Teams and similar apps from marking you as away
- **Time scheduler** — define hour-based time slots when power-save prevention should activate automatically
- **System tray or window mode** — run as a compact system tray icon or a standard window
- **Light / Dark theme** — switchable UI theme applied across all dialogs
- **Toast notifications** — Windows toast notification on start and stop events
- **Run on startup** — optional registry entry to launch with Windows
- **Global hotkey** — `Ctrl+Alt+S` toggles start/stop from anywhere
- **Persistent configuration** — settings saved to `%APPDATA%\PreventPowerSaveApp\Config.xml`

## Build

**Prerequisites for building:**

- Visual Studio 2022 with the **.NET desktop development** workload
- NuGet CLI on your PATH (only needed for command-line builds)
- To rebuild the installer (`.vdproj`): install the [Microsoft Visual Studio Installer Projects 2022](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects) extension

Open `PreventPowerSave.sln` in Visual Studio 2022 and build, or use MSBuild from the command line:

```bash
# Restore NuGet packages
nuget restore PreventPowerSave.sln

# Build Release
msbuild PreventPowerSaveApp/PreventPowerSaveApp.csproj /p:Configuration=Release
```

Output lands in `PreventPowerSaveApp/bin/Release/`. To rebuild the installer, open the solution in Visual Studio, right-click the `Setup` project, and choose **Build**.

## Troubleshooting

**Toast notifications do not appear**
The app uses Windows toast notifications. Make sure notifications are not disabled for the app in Windows Settings → System → Notifications.

**The app does not start with Windows**
The run-on-startup option writes to the registry (`HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run`). If your machine has group policy restrictions on this key the setting will have no effect.

**Global hotkey (Ctrl+Alt+S) does not work**
Another application may already have registered the same hotkey. Try closing other apps or check your keyboard shortcut manager software.

**"Could not load file or assembly" error on launch**
The .NET Framework 4.7.2 runtime is missing. Download and install it from [Microsoft's website](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) and try again.

## Configuration Options

| Setting | Description |
|---|---|
| Interval | Duration in minutes (used when Endless mode is off) |
| Endless mode | Runs until manually stopped; progress bar switches to marquee style |
| AFK prevention | Jiggle mouse when idle > 4.5 min to prevent Teams away status |
| Theme | Light or Dark |
| Run on startup | Adds/removes registry entry under `HKCU\...\Run` |
| Run in system tray | Start minimized to tray instead of showing a window |
| Scheduler | Hour-based time slots for automatic activation |

## System Tray Menu

| Item | Action |
|---|---|
| Header (app name) | Opens the status window |
| Start | Starts power-save prevention |
| Stop | Stops power-save prevention |
| Configuration | Opens settings dialog |
| Scheduler | Opens the scheduler dialog |
