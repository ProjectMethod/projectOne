using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service
{
    class NotificationServiceImpl : NotificationService
    {
        public void sendNotification(Notification notification)
        {
            Console.WriteLine("Notification Sent to " + notification.Ticket.User.Email + ". \n");
            Console.WriteLine("Message: " + notification.Message);
            Console.WriteLine("Notification Sent to Reviewer " + notification.EmployeeReviewer.Email + ". \n");
            Console.WriteLine("Message: " + notification.Message);
        }
    }
}
