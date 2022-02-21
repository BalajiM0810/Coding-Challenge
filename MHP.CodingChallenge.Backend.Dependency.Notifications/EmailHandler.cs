using System;
using MHP.CodingChallenge.Backend.Dependency.Inquiry;
using Microsoft.Extensions.Logging;
using MHP.CodingChallenge.Backend.Dependency.Inquiry.Interface;

namespace MHP.CodingChallenge.Backend.Dependency.Notifications
{
    public class EmailHandler : IEmailHandler
    {
        public virtual void SendEmail(Inquiry.Inquiry inquiry)
        {
            Console.WriteLine(string.Format("sending email for: {0}", inquiry.ToString()));
        }
    }
}
