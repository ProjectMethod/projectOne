using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ProjectMethods.service;
using Moq;

namespace ProjectMethods.tests.service
{
    public class InventoryServiceTest
    {

        InventoryService inventoryService = new InventoryServiceImpl();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void addTicket_validTicket()
        {
            Assert.IsTrue(inventoryService.addTicket(new Ticket()));
        }

        [Test]
        public void addTicket_nullTicket()
        {
            Assert.IsFalse(inventoryService.addTicket(null));
        }

        [Test]
        public void deleteTicket_validTicket()
        {
            Ticket validTicket = new Ticket();
            validTicket.status = Ticket.Status.Confirmed;
            Assert.IsFalse(inventoryService.deleteTicket(new Ticket()));
        }

        [Test]
        public void deleteTicket_invalidTicket()
        {
            Assert.IsFalse(inventoryService.deleteTicket(new Ticket()));
        }

        [Test]
        public void printAvaliableSeats_validRoute()
        {
            Route validRoute = new Route();
            validRoute.seats = new List<string>(){ "1A", "2B" };
            Assert.IsTrue(inventoryService.printAvaliableSeats(validRoute));
        }

        [Test]
        public void printAvaliableSeats_noSeats()
        {
            Route validRoute = new Route();
            Assert.IsTrue(inventoryService.printAvaliableSeats(validRoute));
        }

        [Test]
        public void printAvaliableSeats_nullRoute()
        {
            Assert.IsFalse(inventoryService.printAvaliableSeats(null));
        }

        [Test]
        public void calculatePrice_validTicket()
        {
            Ticket validTicket = new Ticket();
            validTicket.Seat = "1A";
            validTicket.TicketNumber = 5;
            double thing = inventoryService.calculatePrice(validTicket);
            Assert.IsTrue(inventoryService.calculatePrice(validTicket) == 4900);
        }

        [Test]
        public void calculatePrice_invalidTicket()
        {
            Ticket invalidTicket = new Ticket();
            Assert.IsTrue(inventoryService.calculatePrice(invalidTicket) == 0);
        }

        [Test]
        public void createRequest_validRequest()
        {
            Request validRequest = new Request();
            Assert.IsTrue(inventoryService.createRequest(validRequest));
        }

        [Test]
        public void createRequest_nullRequest()
        {
            Assert.IsFalse(inventoryService.createRequest(null));
        }
        
        private Request setUpRequest(Ticket.Status status)
        {
            var input = new System.IO.StringReader("0");
            Console.SetIn(input);
            Request request = new Request();
            Ticket submittedTicket = new Ticket();
            submittedTicket.Seat = "1A";
            UserData validUser = new UserData();
            validUser.Email = "email@email.com";
            submittedTicket.User = validUser;
            submittedTicket.status = status;
            submittedTicket.TicketNumber = 1;
            InventoryService.tickets.Add(submittedTicket);
            request.Ticket = submittedTicket;
            return request;
        }
        [Test]
        public void updateRequest_submittedTicket()
        {
            Request request = setUpRequest(Ticket.Status.Submitted);
            Assert.IsTrue(inventoryService.updateRequest(request));
        }

        [Test]
        public void updateRequest_updatedTicket()
        {
            Request request = setUpRequest(Ticket.Status.Pending);
            Assert.IsTrue(inventoryService.updateRequest(request));
        }

        [Test]
        public void updateRequest_canceledTicket()
        {
            Request request = setUpRequest(Ticket.Status.Canceled);
            Assert.IsTrue(inventoryService.updateRequest(request));
        }

        [Test]
        public void updateRequest_invalidRequest()
        {
            Assert.IsFalse(inventoryService.updateRequest(new Request()));
        }

        [Test]
        public void removeRequests_validRequest()
        {
            Request validRequest = new Request();
            validRequest.RequestId = 1;
            InventoryService.requests.Add(validRequest);
            Assert.IsTrue(inventoryService.removeRequests(validRequest));
        }

        [Test]
        public void removeRequests_invalidRequest()
        {
            Request validRequest = new Request();
            validRequest.RequestId = 1;
            InventoryService.requests.Add(validRequest);
            Assert.IsFalse(inventoryService.removeRequests(new Request()));
        }

        [Test]
        public void removeRequests_nullRequest()
        {
            Assert.IsFalse(inventoryService.removeRequests(null));
        }
    }
}
