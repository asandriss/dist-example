using System.Threading.Tasks;
using FireOnWheels.Messages;
using FireOnWheels.Order.Helper;
using NServiceBus;
using NServiceBus.Logging;

namespace FireOnWheels.Order
{
    public class ProcessOrderHandler:IHandleMessages<ProcessOrderCommand>
    {
        private static readonly ILog Logger = 
            LogManager.GetLogger(typeof(ProcessOrderHandler));

        public async Task Handle(ProcessOrderCommand message, IMessageHandlerContext context)
        {
            Logger.InfoFormat("Order received! From address: {0}, To address: {1}",
                message.AddressFrom, message.AddressTo);
            

            // do internal processing of the order
            await EmailSender.SendEmailToDispatch(message);

            Logger.InfoFormat("Order from address: {0}, to address: {1} processed successfully.",
                message.AddressFrom, message.AddressTo);
            
            // notify anyone interested that order is complete.
            await context.Publish<IOrderProcessedEvent>(e =>
            {
                e.AddressFrom = message.AddressFrom;
                e.AddressTo = message.AddressTo;
                e.Price = message.Price;
                e.Weight = message.Weight;
            });
        }
    }
}
