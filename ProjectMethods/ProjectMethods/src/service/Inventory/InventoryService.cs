using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service
{
    interface InventoryService
    {
        static List<Location> locations = new List<Location>(){new Location("City 1", "State 1"),
                                                               new Location("City 2", "State 2"),
                                                               new Location("City 3", "State 3"),
                                                               new Location("City 4", "State 4"),
                                                               new Location("City 5", "State 5")};

        static List<Ticket> tickets = new List<Ticket>();
        static List<Request> requests = new List<Request>();

        bool addTicket(Ticket ticket);
        bool deleteTicket(Ticket ticket);
        public bool printAvaliableSeats(Route route);
        public double calculatePrice(Ticket ticket);
        bool createRequest(Request request);
        public bool updateRequest(Request request);
        public bool printRequests();
        public bool removeRequests(Request request);
    }
}
