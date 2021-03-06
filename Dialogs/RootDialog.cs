﻿using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace CustomerServiceChatBot.Dialogs
{
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            int length = (activity.Text ?? string.Empty).Length;

            await context.PostAsync($"you sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);

        }
    }
}