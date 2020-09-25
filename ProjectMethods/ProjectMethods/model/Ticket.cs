using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.models
{
    class Ticket
    {
        enum Status
        {
            Submitted,
            Pending,
            Confirmed,
            Revised,
            Canceled,
        }

        private double price;
        private string seatRow;
        private string seatLetter;
        private Route route;
        private UserData user;
        private int ticketNumber;
        private Status status;
        
        public Ticket()
        {
            status = Status.Submitted;
        }

        public string toString()
        {
            return "";
        }

    }
}
