using System;
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
        public List<Passenger> Temp { get; private set; } //problematisk
        public Elevator(List<Floor> floors, int capacity, int _currentFloor, int _timeunits, int _ED, List<Passenger> _temp)
        {
            Floorlevels = floors;
            Capacity = capacity;
            CurrentPassenger = new List<Passenger> { };
            Currentfloor = _currentFloor;
            TimeUnits = _timeunits;
            ElevatorDirection = _ED;
            Temp = _temp; // ta bort
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
            AddPassengerUpp(Floorlevels[Currentfloor].Queue);
            SetDestination(CurrentPassenger);
            if (Currentfloor < ElevatorDirection)
            {
                // AddPassengerUpp(CurrentPassenger);
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
            AddPassengerUpp(CurrentPassenger);
            SetDestination(CurrentPassenger);

            if (Currentfloor > ElevatorDirection)
            {
                // AddPassengerUpp(CurrentPassenger);
                GoUpp(Floorlevels, ElevatorDirection);
            }
            else if (Currentfloor < ElevatorDirection)
            {
                // AddPassengerDown(CurrentPassenger);
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
                    CurrentPassenger.Remove(a[i]); ///Skapade en del problem
                    //      Temp.Add(pass);
                }
            }
            /*foreach (Passenger pass in a) //for
            {
                if (CurrentPassenger.Count < Capacity) //behövs ej här??
                {
                    if (pass.Destination == Currentfloor)
                    {
                       CurrentPassenger.Remove(pass); ///Skapade en del problem
                  //      Temp.Add(pass);
                    }

                }
            }
            if(Temp.Count > 0)
            {
                for (int i = 0; i < a.Count; i++) //KANSKE INTE BÄSTA LÖSNINGEN; HAR NI BÄTTRE FÖRSLAG
                {
                    for (int j = 0; j < Temp.Count; j++)
                    {
                        if (a[i] == Temp[j])
                        {
                            CurrentPassenger.Remove(a[i]);
                            Temp.Remove(a[i]);
                        }
                    }
                }
            } */

        }
        public void AddPassengerUpp(List<Passenger> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (CurrentPassenger.Count < Capacity)
                {
                    //   if (a[i].Destination > Currentfloor)
                    {
                        CurrentPassenger.Add(a[i]);
                        // Floorlevels[Currentfloor].RemovePassengerQueue(pass);
                    }

                }
            }
            /*  foreach (Passenger pass in a) //FUUUUck vad är problemet :(
              {
                   if(CurrentPassenger.Count < Capacity)
                   {
                      if (pass.Destination > Currentfloor )
                      {
                          CurrentPassenger.Add(pass);
                        //  Floorlevels[Currentfloor].RemovePassengerQueue(pass); åtgärdar problem
                      }

                   }

              }
              foreach(Passenger pass in CurrentPassenger) //lr ha en tillf'llig list för borttagning
              { 
                  Floorlevels[Currentfloor].RemovePassengerQueue(pass);
              } */
        }
        public void AddPassengerDown(List<Passenger> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (CurrentPassenger.Count < Capacity)
                {
                    if (a[i].Destination < Currentfloor)
                    {
                        CurrentPassenger.Add(a[i]);
                        // Floorlevels[Currentfloor].RemovePassengerQueue(pass);
                    }

                }
            }
            /*  foreach (Passenger pass in a)
              {
                  if (CurrentPassenger.Count < Capacity)
                  {
                      if (pass.Destination < Currentfloor)
                      {
                          CurrentPassenger.Add(pass);
                       // Floorlevels[Currentfloor].RemovePassengerQueue(pass);
                      }

                  }

              } 
              foreach (Passenger pass in CurrentPassenger) //lr ha en tillf'llig list för borttagning - kontrollera att dett funkar
              {
                  Floorlevels[Currentfloor].RemovePassengerQueue(pass);
              } */

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
            return 0;
        }
    }
}
