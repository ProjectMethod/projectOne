using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.model
{
    class Location
    {
        private string state;
        private string city;

        public Location(string state)
        {
            this.state = state;
        }

        public Location(string state, string city)
        {
            this.state = state;
            this.city = city;
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
