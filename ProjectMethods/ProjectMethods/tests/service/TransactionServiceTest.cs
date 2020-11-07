using System.Text;
using NUnit.Framework;
using ProjectMethods.service.Transaction;
using Moq;
using ProjectMethods.model;

namespace ProjectMethods.tests.service
{
    class TransactionServiceTest
    {
        TransactionService transactionService = new TransactionServiceImpl();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void createTransaction_validTicket()
        {
            Assert.IsTrue(transactionService.createTransaction(new Ticket()));
        }

        [Test]
        public void createTransaction_nullTicket()
        {
            Assert.IsFalse(transactionService.createTransaction(null));
        }
    }
}
