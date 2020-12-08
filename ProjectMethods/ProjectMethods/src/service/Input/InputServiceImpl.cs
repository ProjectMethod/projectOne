using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service
{
   public class InputServiceImpl : InputService
    {
        public string stringConsoleRead()
        {
            return Console.ReadLine();
        }

        
        public string integerConsoleRead()
        {
            return Console.ReadLine();
        }

        // ---------- User Controller --------------
        // Asking if User is new User or Employee
        public string pickUserConsoleRead()
        {
            return Console.ReadLine();
            //return "1";
        }

        // Asking User for Name
        public string pickNameConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking User for Age
        public string pickAgeConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking User for Email
        public string pickEmailConsoleRead()
        {
            return Console.ReadLine();
        }

        // -------------- Transaction Controller -------------
        // Asking User for which Destination
        public string pickDestinationConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking User for State they live in
        public string pickUserStateConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking User for City they live in
        public string pickUserCityConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking User to Confirm Ticket
        public string pickConfirmDenyConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking User to Book another flight
        public string pickBookAnotherConsoleRead()
        {
            return Console.ReadLine();
        }

        // ------------------- UserController -----------------
        public string pickNewBooking()
        {
            return Console.ReadLine();
        }

        // Asking user to make changes to tickets
        public string pickTicketListConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking user which seat to change
        public string pickNewSeatingConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking user what to do with ticket
        public string pickRequestOptionConsoleRead()
        {
            return Console.ReadLine();
        }

        // ------------------- EmployeeController ------------
        // Asking Employee which Requests to process
        public string pickRequestsToProcessConsoleRead()
        {
            return Console.ReadLine();
        }

        // -------------------- InventoryService -------------
        // Asking Employee to Confirm ticket
        public string pickCOnfirmConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking  User to confirm seating change
        public string pickConfirmSeatingConsoleRead()
        {
            return Console.ReadLine();
        }

        // Asking User to confirm cancel ticket
        public string pickConfirmCancelConsoleRead()
        {
            return Console.ReadLine();
        }

    }
}
