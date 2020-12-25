using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using ProjectMethods.service;
using Moq;
using ProjectMethods.model;
using AutoFixture;

namespace ProjectMethods.tests.system
{

    class equivalenceTesting
    {
        Mock<InputService> inputService;
        ProjectMethods.Program program;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void seasdf()
        {
            inputService = new Mock<InputService>(MockBehavior.Strict);
            program = new Program(inputService.Object);
            
            inputService.Setup(p => p.stringConsoleRead()).Returns("wa");
            inputService.Setup(p => p.integerConsoleRead()).Returns("0");

            //ProjectMethods.Program.startInterface();
            //Assert.IsTrue(program.testingMethod());

            //inputService.VerifyAll();
        }
    }
}
