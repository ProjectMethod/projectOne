using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjectMethods.service
{
    class InventoryServiceImpl : InventoryService
    {
        NotificationService notificationService = new NotificationServiceImpl();

        public void addTicket(Ticket ticket)
        {
            InventoryService.tickets.Add(ticket);
            Console.WriteLine("Added Ticket");
        }

        public void deleteTicket(Ticket ticket)
        {
            InventoryService.tickets.Remove(ticket);
            ticket.status = Ticket.Status.Confirmed;
            notificationService.sendNotification(new Notification(ticket, "Cancelled Ticket.", new UserData()));
        }

        public static List<Location> getAllAvailableLocations()
        {
            Console.WriteLine("Show All Locations");
            return new List<Location>();
        }

        public static void getTicketByNum(int ticketNum)
        {
            Console.WriteLine("Return ticket");
        }

        public static List<Location> getAllAvaliableLocations()
        {
            List<Location> locations = InventoryService.locations;
            return locations;
        }

        public static void printAllAvaliableLocations()
        {
            int i = 0;
            foreach (Location location in InventoryService.locations)
            {
                Console.WriteLine(" - " + location.City + ", " + location.State + " [" + i++ + "]");
            }
        }

        public void printAvaliableSeats(Route route)
        {
            Console.WriteLine("Choose from avaliable seat: \n");
            int i = 0;
            foreach (string seat in route.seats)
            {
                Console.WriteLine(" - " + seat + " [" + i++ + "]");
            }
        }

        public double calculatePrice(Ticket ticket)
        {
            double price = 0;
            price += (double)ticket.Seat[0];
            price *= ticket.TicketNumber * 20;
            return price;
        }

        public void updateTicket(Ticket ticket)
        {
            Console.WriteLine("Update Ticket");
        }
        public void createRequest(Request request)
        {
            InventoryService.requests.Add(request);
            Console.WriteLine("Created Ticket");
        }
        public void updateRequest(Request request)
        {
            string choice;
            if (request.Ticket.status == Ticket.Status.Submitted)
            {
                Console.WriteLine("Would you like to Confirm this Ticket?");
                Console.WriteLine("- Yes [0]");
                Console.WriteLine("- No [1]");

                choice = Console.ReadLine();

                if (Int16.Parse(choice) == 0)
                {
                    // Update Ticket
                    foreach (Ticket ticket in InventoryService.tickets)
                    {
                        // The Employee only confirms the seat change. If the request is denied then the
                        // ticket is stuck to pending.
                        if (ticket.Equals(request.Ticket))
                        {
                            ticket.status = Ticket.Status.Confirmed;
                            notificationService.sendNotification(new Notification(ticket, "Confirmed Ticket.", new UserData()));
                        }
                        else
                        {
                            notificationService.sendNotification(new Notification(ticket, "Cannot change seats. Ticket still on Pending.", new UserData()));
                        }
                    }

                    removeRequests(request);
                }
            }

            if (request.Ticket.status == Ticket.Status.Pending)
            {
                Console.WriteLine("Would you like to change seating of this Ticket?");
                Console.WriteLine("- Yes [0]");
                Console.WriteLine("- No [1]");
                choice = Console.ReadLine();
                if (Int16.Parse(choice) == 0)
                {
                    foreach (Ticket ticket in InventoryService.tickets)
                    {
                        if (ticket.Equals(request.Ticket))
                        {
                            ticket.status = Ticket.Status.Confirmed;
                            notificationService.sendNotification(new Notification(ticket, "Confirmed Ticket.", new UserData()));
                            break;
                        }
                    }
                }
            }

            if (request.Ticket.status == Ticket.Status.Canceled)
            {
                Console.WriteLine("Would you like to Cancel this Ticket?");
                Console.WriteLine("- Yes [0]");
                Console.WriteLine("- No [1]");
                choice = Console.ReadLine();
                if (Int16.Parse(choice) == 0)
                {
                    foreach (Ticket ticket in InventoryService.tickets)
                    {
                        if (ticket.Equals(request.Ticket))
                        {
                            deleteTicket(ticket);
                            break;
                        }
                    }

                    Console.WriteLine("Deleted Ticket.");
                    removeRequests(request);
                }
            }
        }

        public void removeRequests(Request request)
        {
            // Update Request
            foreach (Request req in InventoryService.requests)
            {
                if (req.RequestId == request.RequestId)
                {
                    InventoryService.requests.Remove(req);
                    break;
                }
            }
            Console.WriteLine("Updated Ticket.");
        }

        public void printRequests()
        {
            int i = 0;
            if (InventoryService.requests.Count != 0)
            {
                foreach (Request request in InventoryService.requests)
                {
                    Console.WriteLine("Request #: " + request.RequestId + " | Ticket: " + request.Ticket.TicketNumber + ", Status: " + request.Ticket.status + " [" + i++ + "]");
                }
            }
            else
            {
                Console.WriteLine("No Requests to process!");
            }
        }

        public List<Request> allRequest(UserData user)
        {
            Console.WriteLine("List Request given user");
            return new List<Request>();
        }

        public static void printAllTickets()
        {
            int i = 0;
            foreach (Ticket ticket in InventoryService.tickets)
            {
                Console.WriteLine("Ticket Number: " + ticket.TicketNumber + " | " +
                   "Route: (Source) " + ticket.Route.Source.State + ", " + ticket.Route.Source.City + " (Destination) " + ticket.Route.Destination.State + ", " + ticket.Route.Destination.City + " | " +
                   "Seat: " + ticket.Seat + " | " +
                   "PRICE: $" + ticket.Price + " | Status: " + ticket.status + " [" + i++ + "]");
            }
        }
    }
}
