using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace FireOnWheels.Web
{
    public class OrderHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.Caller.orderMessage("New connection");
            return base.OnConnected();
        }
        
        public static void SendOrderMessage(string msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<OrderHub>();
            hubContext.Clients.All.orderMessage(msg);
        }
    }
}