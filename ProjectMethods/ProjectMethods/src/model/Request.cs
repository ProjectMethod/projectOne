using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.model
{
    class Request
    {
        private Ticket ticket;
        private int requestId;
        static int counter = 1;

        public Request()
        {
            requestId = counter++;
        }

        public Request(Ticket ticket)
        {
            this.ticket = ticket;
            requestId = counter++;
        }

        public Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }
    }
}
