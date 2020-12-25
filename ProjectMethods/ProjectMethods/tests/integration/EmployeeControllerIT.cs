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
    class EmployeeControllerIT
    {
        Mock<InputService> inputService;
        ProjectMethods.controller.EmployeeController employeeController;

        [SetUp]
        public void Setup()
        {
            inputService = new Mock<InputService>(MockBehavior.Strict);
            employeeController = new ProjectMethods.controller.EmployeeController(inputService.Object);
        }

        // Expecting Exceptions

        // employeeLogin
        [Test]
        public void employeeLogin_falseLogout_true()
        {
            inputService.Setup(p => p.pickRequestsToProcessConsoleRead()).Returns("0");
            Assert.AreEqual(employeeController.employeeLogin(false), false) ;
        }

        [Test]
        public void employeeLogin_trueLogout_true()
        {
            inputService.Setup(p => p.pickRequestsToProcessConsoleRead()).Returns("0");
            Assert.AreEqual(employeeController.employeeLogin(true), true);
        }

        [Test]
        public void employeeLogin_falseLogoutReturnLogin_true()
        {
            inputService.Setup(p => p.pickRequestsToProcessConsoleRead()).Returns("b");
            Assert.AreEqual(employeeController.employeeLogin(false), true);
        }

        [Test]
        public void employeeLogin_trueLogoutReturnLogin_true()
        {
            inputService.Setup(p => p.pickRequestsToProcessConsoleRead()).Returns("b");
            Assert.AreEqual(employeeController.employeeLogin(true), true);
        }
    }
}
