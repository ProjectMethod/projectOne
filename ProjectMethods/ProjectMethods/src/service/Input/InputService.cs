using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.service
{
    public interface InputService
    {
        public string stringConsoleRead();

        public string integerConsoleRead();

        public string pickUserConsoleRead();

        public string pickNameConsoleRead();

        public string pickAgeConsoleRead();

        public string pickEmailConsoleRead();

        public string pickDestinationConsoleRead();

        public string pickUserStateConsoleRead();

        public string pickUserCityConsoleRead();

        public string pickConfirmDenyConsoleRead();

        public string pickBookAnotherConsoleRead();

        public string pickNewBooking();

        public string pickTicketListConsoleRead();

        public string pickNewSeatingConsoleRead();

        public string pickRequestOptionConsoleRead();

        public string pickRequestsToProcessConsoleRead();

        public string pickCOnfirmConsoleRead();

        public string pickConfirmSeatingConsoleRead();

        public string pickConfirmCancelConsoleRead();
    }
}
