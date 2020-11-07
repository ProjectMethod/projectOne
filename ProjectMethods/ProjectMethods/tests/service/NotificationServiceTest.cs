using System.Text;
using NUnit.Framework;
using ProjectMethods.service;
using Moq;
using ProjectMethods.model;

namespace ProjectMethods.tests.service
{
    class NotificationServiceTest
    {
        NotificationService notificationService = new NotificationServiceImpl();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void sendNotification_validNotification()
        {
            Ticket ticket = new Ticket();
            UserData user = new UserData();
            user.Email = "ga@email.com";
            ticket.User = user;
            Notification notification = new Notification(ticket, "notification", new UserData());
            Assert.IsTrue(notificationService.sendNotification(notification));
        }

        [Test]
        public void sendNotification_nullNotification()
        {
            Assert.IsFalse(notificationService.sendNotification(null));
        }
    }
}
