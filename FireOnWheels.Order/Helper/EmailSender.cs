using FireOnWheels.Messages;
using System.Threading.Tasks;

namespace FireOnWheels.Order.Helper
{
    public static class EmailSender
    {
        public static async Task SendEmailToDispatch(ProcessOrderCommand order)
        {
            await Task.Delay(3000);
        }
    }
}
