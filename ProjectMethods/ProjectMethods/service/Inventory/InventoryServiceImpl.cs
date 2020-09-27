using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service
{
    class InventoryServiceImpl : InventoryService
    {
        public void addTicket(Ticket ticket)
        {
            Console.WriteLine("Added Ticket");
        }

        public void deleteTicket(Ticket ticket)
        {
            Console.WriteLine("Deleted Ticket");
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

        public static List<Route> getAllAvaliableRoutes()
        {
            Console.WriteLine(" - City 1, State 1 [1]");
            Console.WriteLine(" - City 2, State 2 [2]");
            Console.WriteLine(" - City 3, State 3 [3]");
            Console.WriteLine(" - City 4, State 4 [4]");

            return new List<Route>();
        }

        public void upateTicket(Ticket ticket)
        {
            Console.WriteLine("Update Ticket");
        }
        public void createRequest(Request request)
        {
            Console.WriteLine("Create Ticket");
        }
        public void updateRequest(Request request)
        {
            Console.WriteLine("Update Ticket");
        }

        public List<Request> allRequest(UserData user)
        {
            Console.WriteLine("List Reuqest given user");
            return new List<Request>();
        }
    }
}
