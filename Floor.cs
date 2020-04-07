using System;
using System.Collections.Generic;
using System.Text;
// HEJHEJEHEJE
namespace Elevator
{
   class Floor
    {
       public int floor { get; private set; }
       public List<Passenger> queue { get; private set; }
            public Floor(int _floor)
            {
                floor = _floor;
                queue = new List<Passenger> { };
            
           }
        public void AddPassenger(Passenger a)
        {
            queue.Add(a);

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    }

