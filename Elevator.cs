ing System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    class Elevator
    {
        public List<Floor> Floorlevels { get; private set; }
        public List<Passenger> CurrentPassenger { get; private set; }
        public int Capacity { get; private set; }
        public int Currentfloor { get; private set; }
        public int TimeUnits { get; private set; }
        public int ElevatorDirection { get; private set; }
        public Elevator(List<Floor> floors, int capacity, int _currentFloor, int _timeunits, int _ED)
        {
            Floorlevels = floors;
            Capacity = capacity;
            CurrentPassenger = new List<Passenger> { };
            Currentfloor = _currentFloor;
            TimeUnits = _timeunits;
            ElevatorDirection = _ED;
        }
        public Floor GoUpp(List<Floor> a, int Destination)
        {
            for (int i = Currentfloor; i < Destination; i++)
            {
                Currentfloor += 1;
                TimeUnits += 1;
            }

            Console.WriteLine($"Våningsplan {Currentfloor}");
            RemovePassenger(CurrentPassenger);
            AddPassenger(Floorlevels[Currentfloor].Queue);
            SetDestination(CurrentPassenger);
            if (Currentfloor < ElevatorDirection)
            {
                // AddPassengerUpp(CurrentPassenger); //Fixa till enbart en metod
                GoUpp(Floorlevels, ElevatorDirection);
            }
            else if (Currentfloor > ElevatorDirection)
            {
                // AddPassengerDown(CurrentPassenger);
                GoDown(Floorlevels, ElevatorDirection);

            }
            else
            {

            }
            //Else stäng av??

            return a[Currentfloor];
        }
        public Floor GoDown(List<Floor> a, int Destination)
        {
            for (int i = Currentfloor; i > Destination; i--)
            {
                Currentfloor -= 1;
                TimeUnits += 1;
            }

            Console.WriteLine($"Våningsplan {Currentfloor}");
            RemovePassenger(CurrentPassenger);
            AddPassenger(CurrentPassenger);
            SetDestination(CurrentPassenger);

            if (Currentfloor < ElevatorDirection)
            {
                GoUpp(Floorlevels, ElevatorDirection);
            }
            else if (Currentfloor > ElevatorDirection)
            {
                GoDown(Floorlevels, ElevatorDirection);
            }
            return a[Currentfloor];
        }
        public void RemovePassenger(List<Passenger> a)
        {

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Destination == Currentfloor)
                {
                    CurrentPassenger.Remove(a[i]); 
                }
            }
        }
        public void AddPassenger(List<Passenger> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (CurrentPassenger.Count < Capacity)
                {
                    {
                        CurrentPassenger.Add(a[i]);
                           Floorlevels[Currentfloor].RemovePassengerQueue(a[i]);
                        i -= 1;
                    }

                }
            }

        }
        public int SetDestination(List<Passenger> CuP)
        {
            if (CuP.Count > 0)
            {
                ElevatorDirection = CuP[0].Destination;
                return ElevatorDirection;
            }
            else
            {

                for (int i = 0; i < Floorlevels.Count; i++)
                {

                    if (Floorlevels[i].Queue.Count > 0)
                    {
                        ElevatorDirection = i;
                        return ElevatorDirection;
                    }
                }
             

            }
            return 0; //tillfällig lösning
        }
    }
}
