using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.model
{
    class Ticket
    {
        public enum Status
        {
            Submitted,
            Pending,
            Confirmed,
            Revised,
            Canceled,
        }

        private double price;
        private string seat;
        private Route route;
        private UserData user;
        private int ticketNumber;
        public Status status;
        
        public Ticket()
        {
            status = Status.Submitted;
        }

        public void toString()
        {
            Console.WriteLine("Ticket Number: " + this.TicketNumber + "\n" +
                   "Route: (Source) " + this.Route.Source.State + ", " + this.Route.Source.City + " (Destination) " + this.Route.Destination.State + ", " + this.Route.Destination.City + "\n" +
                   "Seat: " + this.Seat + "\n" + 
                   "PRICE: $" + this.Price);
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Seat
        {
            get { return seat; }
            set { seat = value; }
        }

        public Route Route
        {
            get { return route; }
            set { route = value; }
        }

        public UserData User
        {
            get { return user; }
            set { user = value; }
        }

        public int TicketNumber
        {
            get { return ticketNumber; }
            set { ticketNumber = value; }
        }
    }
}
