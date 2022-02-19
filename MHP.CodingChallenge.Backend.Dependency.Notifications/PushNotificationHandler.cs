using System;
using MHP.CodingChallenge.Backend.Dependency.Inquiry;
using Microsoft.Extensions.Logging;
using MHP.CodingChallenge.Backend.Dependency.Inquiry.Interface;

namespace MHP.CodingChallenge.Backend.Dependency.Notifications
{
    public class PushNotificationHandler : IPushNotificationHandler
    {
        public virtual void SendNotification(Inquiry.Inquiry inquiry)
        {
            Console.WriteLine(string.Format("sending notification inquiry: {0}", inquiry.ToString()));
        }
    }
}
