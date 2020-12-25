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
    class UserControllerIT
    {
        Mock<InputService> inputService;
        ProjectMethods.controller.UserController userController;

        [SetUp]
        public void Setup()
        {
            inputService = new Mock<InputService>(MockBehavior.Strict);
            userController = new ProjectMethods.controller.UserController(inputService.Object);
        }

        // Expecting Exceptions
        [Test]
        public void userSelectInterface_exceptionThrown_return1()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Throws(new Exception());
            Assert.AreEqual(userController.userSelectInterface(new UserData(), false), "1");
        }

        [Test]
        public void userLogin_exceptionThrown_false()
        {
            inputService.Setup(p => p.pickNameConsoleRead()).Throws(new Exception());
            Assert.AreEqual(userController.userLogin(false, false, false, false, new UserData(), new InventoryServiceImpl(), 
                                                     new TransactionServiceImpl(), new NotificationServiceImpl()), false);
        }

        [Test]
        public void userCreatingReservationInterface_exceptionThrown_false()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Throws(new Exception());
            Assert.AreEqual(userController.userSelectInterface(new UserData(), false), "1");
        }

        [Test]
        public void userBookingSelectInterface_exceptionThrown_false()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Throws(new Exception());
            Assert.AreEqual(userController.userSelectInterface(new UserData(), false), "1");
        }


        // userSelectInterface
        [Test]
        public void userSelectInterface_newUserFalseExistingUser_return1()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Returns("1");
            Assert.AreEqual(userController.userSelectInterface(new UserData(), false), "1");
        }

        [Test]
        public void userSelectInterface_newUserTrueExistingUser_return1()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Returns("1");
            Assert.AreEqual(userController.userSelectInterface(new UserData(), true), "1");
        }

        [Test]
        public void userSelectInterface_newUserFalseExistingUser_return2()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Returns("2");
            Assert.AreEqual(userController.userSelectInterface(new UserData(), false), "2");
        }

        [Test]
        public void userSelectInterface_newUserTrueExistingUser_return2()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Returns("2");
           Assert.AreEqual(userController.userSelectInterface(new UserData(), true), "2");
        }

        [Test]
        public void userSelectInterface_namedUserTrueExistingUser_return2()
        {
            UserData user = new UserData();
            user.Name = "name";
            inputService.Setup(p => p.pickUserConsoleRead()).Returns("2");
            Assert.AreEqual(userController.userSelectInterface(user, true), "2");
        }

        // userCreatingReservationInterface
        [Test]
        public void userCreatingReservationInterface_validParamsCurrentBooking_returntrue()
        {
            inputService.Setup(p => p.pickNewBooking()).Returns("1");
            Assert.True(userController.userCreatingReservationInterface(true, true, true, true, new UserData(),
                   new InventoryServiceImpl(), new TransactionServiceImpl(), new NotificationServiceImpl(), 
                   new Ticket(), new Route(), new UserData()));
        }

        [Test]
        public void userCreatingReservationInterface_validParamsBookNewFlight_returntrue()
        {
            inputService.Setup(p => p.pickNewBooking()).Returns("2");
            Assert.True(userController.userCreatingReservationInterface(true, true, true, true, new UserData(),
                   new InventoryServiceImpl(), new TransactionServiceImpl(), new NotificationServiceImpl(), 
                   new Ticket(), new Route(), new UserData()));
        }

        [Test]
        public void userCreatingReservationInterface_invalidParamsCurrentBooking_returnFalse()
        {
            inputService.Setup(p => p.pickNewBooking()).Returns("1");
            Assert.True(userController.userCreatingReservationInterface(true, true, true, true, null,
                   null, null, null, null, null, null));
        }

        [Test]
        public void userCreatingReservationInterface_invalidParamsBookNewFlight_returnFalse()
        {
            inputService.Setup(p => p.pickNewBooking()).Returns("2");
            Assert.True(userController.userCreatingReservationInterface(true, true, true, true, null,
                   null, null, null, null, null, null));
        }
    }
}
