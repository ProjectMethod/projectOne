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
        
        public static Ticket getTicketByNum(int ticketNum)
        {
            foreach (Ticket ticket in InventoryService.tickets)
            {
                if (ticket.TicketNumber == ticketNum)
                {
                    return ticket;
                }
            }
            return new Ticket();
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

        public bool addTicket(Ticket ticket)
        {
            if (ticket != null) {
                InventoryService.tickets.Add(ticket);
                Console.WriteLine("Added Ticket");
                return true;
            } else
            {
                return false;
            }
        }

        public bool deleteTicket(Ticket ticket)
        {
            try
            {
                InventoryService.tickets.Remove(ticket);
                ticket.status = Ticket.Status.Confirmed;
                notificationService.sendNotification(new Notification(ticket, "Cancelled Ticket.", new UserData()));
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        public bool printAvaliableSeats(Route route)
        {
            try
            {
                Console.WriteLine("Choose from avaliable seat: \n");
                int i = 0;
                foreach (string seat in route.seats)
                {
                    Console.WriteLine(" - " + seat + " [" + i++ + "]");
                }
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public double calculatePrice(Ticket ticket)
        {
            try
            {
                double price = 0;
                price += (double)ticket.Seat[0];
                price *= ticket.TicketNumber * 20;
                return price;
            } catch(Exception)
            {
                return 0;
            }
        }

        public bool createRequest(Request request)
        {
            if (request != null) {
                InventoryService.requests.Add(request);
                Console.WriteLine("Created Request");
                return true;
            } else
            {
                return false;
            }
        }
        public bool updateRequest(Request request)
        {
            try
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
                        // The Employee only confirms the seat change. If the request is denied then the
                        // ticket is stuck to pending.
                        Ticket ticket = getTicketByNum(request.Ticket.TicketNumber);
                        ticket.status = Ticket.Status.Confirmed;
                        UserData userData = new UserData();
                        userData.Email = "employee@email.com";
                        notificationService.sendNotification(new Notification(ticket, "Confirmed Ticket.", userData));

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
                        Ticket ticket = getTicketByNum(request.Ticket.TicketNumber);
                        ticket.status = Ticket.Status.Confirmed;
                        notificationService.sendNotification(new Notification(ticket, "Confirmed Ticket.", new UserData()));
                        Console.WriteLine("Changed seats.");
                        removeRequests(request);
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
                        Ticket ticket = getTicketByNum(request.Ticket.TicketNumber);
                        deleteTicket(ticket);
                        Console.WriteLine("Deleted Ticket.");
                        removeRequests(request);
                    }
                }
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        public bool removeRequests(Request request)
        {
            try
            {

                // Update Request
                foreach (Request req in InventoryService.requests)
                {
                    if (req.RequestId == request.RequestId)
                    {
                        InventoryService.requests.Remove(req);
                        return true;
                    }
                }
                Console.WriteLine("Updated Ticket.");
                return false;
            } catch(Exception)
            {
                return false;
            }
        }

        public static bool printRequests()
        {
            try
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
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
