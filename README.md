This application will prevent windows from locking screen (powersave mode) 
I created this application to bypass my works (policy-enforced)

## Installation Instructions
You need to build it you self, and then install the setup.exe

## Current Features
* Program can run in System Tray or as standad windowsApp
* Theme UI
* Toast notification on start and stop events
* Configuration interval options.
* Configuration set program to run on windows start up.
* Configuration is save local under %appdata%/PreventLockScreenApp/
* Time scheduler: define time slots when program need to Prevent Lockscreen
* Shortcut (Control+Alt+S) toggle between start and stop 

## System Tray Menu
* Header text => open status runDialog
* Start => Start prevent logic
* End => End prevent logic
* Configuration => User configDialog
* Scheduler => TimeSchedulerDialog
