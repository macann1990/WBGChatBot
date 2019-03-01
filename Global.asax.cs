using Autofac;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CustomerServiceChatBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //To store the value in memory Bot

            Conversation.UpdateContainer(
                builder =>
                {
                    var store = new InMemoryDataStore();
                    builder.Register(c => store)
                    .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                    .AsSelf()
                    .SingleInstance();
                });


            // To Store the value in Azure Table storage instead of Bot In Memory
            //Conversation.UpdateContainer(
            //    builder =>
            //    {
            //        builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));
            //        var store = new TableBotDataStore(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            //        builder.Register(c => store)
            //        .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
            //        .AsSelf()
            //        .SingleInstance();
            //    });
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
