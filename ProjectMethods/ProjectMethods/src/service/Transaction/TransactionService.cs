using ProjectMethods.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service.Transaction
{
    interface TransactionService
    {
        public bool createTransaction(Ticket ticket);
    }
}
