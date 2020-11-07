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
        //Mock<InventoryService> inventoryService = new Mock<InventoryService>();
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
        public void deleteTicket()
        {
            Assert.IsTrue(inventoryService.deleteTicket(new Ticket()));
        }

        [Test]
        public void printAvaliableSeats()
        {

        }

        [Test]
        public void calculatePrice()
        {

        }

        [Test]
        public void createRequest()
        {

        }

        [Test]
        public void updateRequest()
        {

        }

        [Test]
        public void removeRequests()
        {

        }

        [Test]
        public void printRequests()
        {

        }

        [Test]
        public void printAllTickets()
        {

        }

    }
}
