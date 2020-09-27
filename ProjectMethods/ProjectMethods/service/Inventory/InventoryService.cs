using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service
{
    interface InventoryService
    {
        void addTicket(Ticket ticket);
        void deleteTicket(Ticket ticket);
        void upateTicket(Ticket ticket);
        void createRequest(Request request);
        void updateRequest(Request request);
        List<Request> allRequest(UserData user);
    }
}
