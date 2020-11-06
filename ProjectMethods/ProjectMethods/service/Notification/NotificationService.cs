using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service
{
    interface NotificationService
    {
        static List<Notification> notification = new List<Notification>();
        public void sendNotification(Notification notification);
    }
}
