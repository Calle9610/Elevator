using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    class Passenger
    {
        public int Destination { get; private set; }
        //vi kan ju lägga till namn, eventuellt individuell timeunit.
        public Passenger(int _destination)
        {
            Destination = _destination;
        }
    }
}
