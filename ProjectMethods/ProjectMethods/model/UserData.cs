using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.models
{
    class UserData
    {
        enum UserType
        {
            Basic,
            Employee,
            Admin
        }

        private UserType userType;
        private string name;
        private int age;
        private string email;
    }
}
