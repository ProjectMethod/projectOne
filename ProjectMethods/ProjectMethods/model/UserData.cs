using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.model
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

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Email { get { return email; } set { email = value; } }
    }
}
