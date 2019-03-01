using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace CustomerServiceChatBot.Dialogs
{
    [Serializable]
    public class GreetingDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync(" Hi I'm Ishu Bot");
            await Respond(context);
            context.Wait(MessageReceivedAsync);
        }
        private static async Task Respond(IDialogContext context)
        {
            var userName = String.Empty;
            context.UserData.TryGetValue<string>("Name", out userName);
            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("Your Good Name Please");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                await context.PostAsync(String.Format("Hi {0}. How are you today?", userName));
            }
        }

    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var userName = String.Empty;
            var getName = false;

            context.UserData.TryGetValue<string>("Name", out userName);
            context.UserData.TryGetValue<bool>("GetName", out getName);

            if(getName)
            {
                userName = message.Text;
                context.UserData.SetValue<string>("Name", userName);
                context.UserData.SetValue<bool>("GetName", false);
                await Respond(context);
                context.Wait(MessageReceivedAsync);
            }
            //if(string.IsNullOrEmpty(userName))
            //{
            //    await context.PostAsync("Your Good Name Please");
            //    context.UserData.SetValue<bool>("GetName", true);
            //}
            else
            {
                context.Done(message);
                //await context.PostAsync(String.Format("Hi {0}. How Can I Help You?", userName));
            }
            //context.Wait(MessageReceivedAsync);
        }
    }
}