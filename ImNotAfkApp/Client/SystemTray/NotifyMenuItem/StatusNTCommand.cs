﻿using ImNotAfkApp.CoreElements;
using System.Windows.Forms;

namespace ImNotAfkApp.Client.SystemTray.NotifyMenuItem
{
    internal class StatusNTCommand : MenuItem
    {
        internal StatusNTCommand() :base()
        {
            Text = "I'm not AFK";
            Name = "Status";

            Controller.CurrentLogic.StateChanged += CurrentKeepAlive_StateChanged;
        }

        private void CurrentKeepAlive_StateChanged(object sender, StateChangedEventArgs e)
        {
            if(sender is CurrentLogic logic)
            {
                Text = $"I'm not AFK <{logic.State}>";                
            }            
        }
    }
}