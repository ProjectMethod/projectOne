using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using ProjectMethods.service;
using Moq;
using ProjectMethods.model;

namespace ProjectMethods.tests.integration
{
    class UserControllerTest
    {
        Mock<InputService> inputService;
        ProjectMethods.controller.UserController userController;

        [SetUp]
        public void Setup()
        {
            inputService = new Mock<InputService>(MockBehavior.Strict);
            userController = new ProjectMethods.controller.UserController(inputService.Object);
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
        public void userCreatingReservationInterface_validParams_returntrue()
        {
            inputService.Setup(p => p.pickUserConsoleRead()).Returns("2");
            Assert.AreEqual(userController.userSelectInterface(new UserData(), true), "2");
        }
    }
}
