using Xunit;
using MHP.CodingChallenge.Backend.Dependency.Inquiry;
using Microsoft.Extensions.DependencyInjection;
using MHP.CodingChallenge.Backend.Dependency.Notifications;
using Moq;
using  MHP.CodingChallenge.Backend.Dependency.Inquiry.Interface;

namespace MHP.CodingChallenge.Backend.Dependency.Test
{
    public class InquiryTest
    {
        [Fact]
        public void TestInquiryHandlers()
        {
            // given
            Inquiry.Inquiry inquiry = new Inquiry.Inquiry();
            inquiry.Username = "TestUser";
            inquiry.Recipient = "service@example.com";
            inquiry.Text = "Can I haz cheezburger?";

            // room for potential additional test setup
            var mockEmailHander = new Mock<IEmailHandler>();
            var mockPushNotificationHandler = new Mock<IPushNotificationHandler>();

            var services = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IInquiryService, InquiryService>()
                .AddSingleton(mockEmailHander.Object)
                .AddSingleton(mockPushNotificationHandler.Object);

            var inquiryService = services
                .BuildServiceProvider()
                .GetRequiredService<IInquiryService>();

            // when
            inquiryService.Create(inquiry);

            // then
            mockEmailHander.Verify(e => e.SendEmail(inquiry));
            mockPushNotificationHandler.Verify(e => e.SendNotification(inquiry));
        }
    }
}
