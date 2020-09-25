using ProjectMethods.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service.Transaction
{
    interface TransactionService
    {
        public void createTransaction(Ticket ticket);
    }
}
