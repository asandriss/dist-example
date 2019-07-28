using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireOnWheels.Web
{
    public interface INotifyAllClients
    {
        void Notify(string message);
    }
}
