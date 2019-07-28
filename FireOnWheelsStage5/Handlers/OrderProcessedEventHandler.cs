using System.Threading.Tasks;
using FireOnWheels.Messages;
using Microsoft.AspNet.SignalR;
using NServiceBus;

namespace FireOnWheels.Web.Handlers
{
    public class OrderProcessedEventHandler : IHandleMessages<IOrderProcessedEvent>
    {
        public async Task Handle(IOrderProcessedEvent message, IMessageHandlerContext context)
        {
            // Here we could write a code with SignalR to notify the page about successful process
            await Task.Delay(1000);

            //orderHub.OrderMessage("Order processed successfully");
            OrderHub.SendOrderMessage("Order processed successfully");
        }
    }
}