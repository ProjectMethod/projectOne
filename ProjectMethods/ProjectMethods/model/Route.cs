using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMethods.model
{
    class Route
    {
        private Location source;
        private Location destination;
        private int routeNumber;

        public List<string> seats = new List<String>(){ "1A", "1B", "1C", "2A", "2B", "2C", "3A", "3B", "3C" };
        
        public Route()
        {

        }

        public Route(Location source, Location destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public Route(Location destination)
        {
            this.destination = destination;
        }

        public Location Source
        {
            get { return source; }
            set { source = value; }
        }

        public Location Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public int RouteNumber
        {
            get { return routeNumber; }
            set { routeNumber = value; }
        }
    }
}
