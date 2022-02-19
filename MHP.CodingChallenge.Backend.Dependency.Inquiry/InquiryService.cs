using MHP.CodingChallenge.Backend.Dependency.Inquiry.Interface;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using MHP.CodingChallenge.Backend.Dependency.Inquiry.Interface;


namespace MHP.CodingChallenge.Backend.Dependency.Inquiry
{
    public class InquiryService: IInquiryService
    {
        private readonly IEmailHandler _emailHandler;
        private readonly IPushNotificationHandler _pushNotificationHandler;

        public InquiryService(IEmailHandler emailHandler, IPushNotificationHandler pushNotificationHandler)
        {
            if (emailHandler == null)
                throw new ArgumentNullException(nameof(emailHandler));
            if (pushNotificationHandler == null)
                throw new ArgumentNullException(nameof(pushNotificationHandler));
            _emailHandler = emailHandler;
            _pushNotificationHandler = pushNotificationHandler;
        }

        public void Create(Inquiry inquiry)
        {
            _emailHandler.SendEmail(inquiry);
            _pushNotificationHandler.SendNotification(inquiry);
            Console.WriteLine(string.Format("User sent inquiry: {0}", inquiry.ToString()));
        }
    }
}
