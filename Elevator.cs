using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    class Elevator
    {
        public List<Floor> Floors { get; private set; }
        public List<Passenger> Riders { get; private set; }
        public int Capacity { get; private set; }
        public int CurrentFloor { get; private set; }
        public Elevator(List<Floor> floors, int capacity, int _currentFloor)
        {
            Floors = floors;
            Capacity = capacity;
            Riders = new List<Passenger> { };
            CurrentFloor = _currentFloor;
        }
        public Floor Drive(List<Floor> a, int b)
        {

            int j = 0;
            for (int i = j; i <= b; i++)
            {
                j = i;
               
            }
            
            Console.WriteLine($"Våningsplan {j}");
            return a[j];
        }
        public void F1(Floor a)
        {
            foreach (var Passenger in a)
            {

            }
        }
    }

}g
