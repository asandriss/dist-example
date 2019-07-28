using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FireOnWheels.Web.Startup))]

namespace FireOnWheels.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HubConfiguration { EnableJavaScriptProxies = true };
            //config.EnableJavaScriptProxies = true;
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();
        }
    }
}
