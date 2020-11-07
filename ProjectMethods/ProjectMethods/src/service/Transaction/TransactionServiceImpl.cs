using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service.Transaction
{
    class TransactionServiceImpl : TransactionService
    {
        public bool createTransaction(Ticket ticket)
        {
            if (ticket != null) {
                Console.WriteLine("Payment Successful.\n");
                return true;
            } else
            {
                return false;
            }
        }
    }
}
