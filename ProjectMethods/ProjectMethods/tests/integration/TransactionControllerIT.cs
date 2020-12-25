using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using ProjectMethods.service;
using ProjectMethods.service.Transaction;
using Moq;
using ProjectMethods.model;

namespace ProjectMethods.tests.integration
{
    class TransactionControllerIT
    {
        Mock<InputService> inputService;
        ProjectMethods.controller.TransactionController transactionController;

        [SetUp]
        public void Setup()
        {
            inputService = new Mock<InputService>(MockBehavior.Strict);
            transactionController = new ProjectMethods.controller.TransactionController(inputService.Object);
        }

        [Test]
        public void transactionInterface_lowSeatHighTicket()
        {
            inputService.Setup(p => p.pickDestinationConsoleRead()).Returns("5");
            inputService.Setup(p => p.pickUserStateConsoleRead()).Returns("State");
            inputService.Setup(p => p.pickUserCityConsoleRead()).Returns("City");
            inputService.Setup(p => p.integerConsoleRead()).Returns("1A");
            inputService.Setup(p => p.pickConfirmDenyConsoleRead()).Returns("1");
            inputService.Setup(p => p.pickBookAnotherConsoleRead()).Returns("2");
            Assert.AreEqual(transactionController.transactionInterface(true, true, true, true, new UserData(),
                       new InventoryServiceImpl(), new TransactionServiceImpl(), new NotificationServiceImpl(),
                       new Ticket(), new Route(), new UserData()), 980);

        }

        [Test]
        public void transactionInterface_highSeatLowTicket()
        {
            inputService.Setup(p => p.pickDestinationConsoleRead()).Returns("1");
            inputService.Setup(p => p.pickUserStateConsoleRead()).Returns("State");
            inputService.Setup(p => p.pickUserCityConsoleRead()).Returns("City");
            inputService.Setup(p => p.integerConsoleRead()).Returns("5A");
            inputService.Setup(p => p.pickConfirmDenyConsoleRead()).Returns("1");
            inputService.Setup(p => p.pickBookAnotherConsoleRead()).Returns("2");
            Assert.AreEqual(transactionController.transactionInterface(true, true, true, true, new UserData(),
                       new InventoryServiceImpl(), new TransactionServiceImpl(), new NotificationServiceImpl(),
                       new Ticket(), new Route(), new UserData()), 1640);

        }

        [Test]
        public void transactionInterface_highSeatHighTicket()
        {
            inputService.Setup(p => p.pickDestinationConsoleRead()).Returns("5");
            inputService.Setup(p => p.pickUserStateConsoleRead()).Returns("State");
            inputService.Setup(p => p.pickUserCityConsoleRead()).Returns("City");
            inputService.Setup(p => p.integerConsoleRead()).Returns("5A");
            inputService.Setup(p => p.pickConfirmDenyConsoleRead()).Returns("1");
            inputService.Setup(p => p.pickBookAnotherConsoleRead()).Returns("2");
            Assert.AreEqual(transactionController.transactionInterface(true, true, true, true, new UserData(),
                       new InventoryServiceImpl(), new TransactionServiceImpl(), new NotificationServiceImpl(),
                       new Ticket(), new Route(), new UserData()), 2000);

        }

        [Test]
        public void transactionInterface_lowSeatLowTicket()
        {
            inputService.Setup(p => p.pickDestinationConsoleRead()).Returns("1");
            inputService.Setup(p => p.pickUserStateConsoleRead()).Returns("State");
            inputService.Setup(p => p.pickUserCityConsoleRead()).Returns("City");
            inputService.Setup(p => p.integerConsoleRead()).Returns("1A");
            inputService.Setup(p => p.pickConfirmDenyConsoleRead()).Returns("1");
            inputService.Setup(p => p.pickBookAnotherConsoleRead()).Returns("2");
            Assert.AreEqual(transactionController.transactionInterface(true, true, true, true, new UserData(),
                       new InventoryServiceImpl(), new TransactionServiceImpl(), new NotificationServiceImpl(),
                       new Ticket(), new Route(), new UserData()), 450);

        }
    }
}
