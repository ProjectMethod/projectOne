using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.model
{
    class Notification
    {
        private Ticket ticket;
        private string message;
        private UserData employeeReviewer;

        public Notification(Ticket ticket, string message, UserData reviewer)
        {
            this.ticket = ticket;
            this.message = message;
            this.employeeReviewer = reviewer;
        }

        public Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public UserData EmployeeReviewer
        {
            get { return employeeReviewer; }
            set { employeeReviewer = value; }
        }
    }
}
