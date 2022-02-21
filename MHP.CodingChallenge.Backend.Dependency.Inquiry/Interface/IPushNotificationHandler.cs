using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHP.CodingChallenge.Backend.Dependency.Inquiry.Interface
{
    public interface IPushNotificationHandler
    {
        void SendNotification(Inquiry inquiry);
    }
}
