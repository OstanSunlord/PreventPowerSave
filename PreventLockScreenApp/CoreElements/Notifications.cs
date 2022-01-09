using Microsoft.Toolkit.Uwp.Notifications;
using System;

namespace PreventLockScreen.CoreElements
{
    // info: https://docs.microsoft.com/en-us/windows/apps/design/shell/tiles-and-notifications/adaptive-interactive-toasts?tabs=builder-syntax

    public static class Notifications
    {
        const int conversationId = 38314;

        public static void Show(string caption, string context)
        {
            Show(caption, context.Split( 
                new string[] { Environment.NewLine },
                StringSplitOptions.None));
        }

        public static void Show(string caption, string[] contexts)
        {
            var toast = new ToastContentBuilder();

            toast.AddArgument("action", "viewConversation");
            toast.AddArgument("conversationId", conversationId);
            toast.AddText(caption, hintMaxLines: 1);

            foreach (var context in contexts)
            {
                toast.AddText(context);
            }
            toast.Show();
        }


    }
}
