using ProjectMethods.models;
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

        public static void getAllAvailableLocations()
        {
            Console.WriteLine("");
        }

        public static void getTicketByNum(int ticketNum)
        {

        }

        public static void getAllAvaliableRoutes()
        {
            Console.WriteLine(" - City 1, State 1 [1]");
            Console.WriteLine(" - City 2, State 2 [2]");
            Console.WriteLine(" - City 3, State 3 [3]");
            Console.WriteLine(" - City 4, State 4 [4]");
        }
    }
}
