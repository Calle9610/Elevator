using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {

            Floor zero = new Floor(0);
            Floor one = new Floor(1);
            Floor two = new Floor(2);
            Floor three = new Floor(3);
            Floor four = new Floor(4);
            Floor five = new Floor(5);
            Floor six = new Floor(6);
            Floor seven = new Floor(7);
            Floor eight = new Floor(8);
            Floor nine = new Floor(9);


            List<Floor> Levels = new List<Floor> { zero, one, two, three, four, five, six, seven, eight, nine };
            Elevator Otis = new Elevator(Levels, 10, 0, 0, 0);

            Passenger Adam = new Passenger(6);
            Passenger Ture = new Passenger(4);
            Passenger Bengt = new Passenger(7);
            Passenger Astrid = new Passenger(1);
            Passenger Bo = new Passenger(5);
            Passenger Fredrik = new Passenger(2);
            Passenger Björn = new Passenger(8);
            Passenger Eva = new Passenger(3);
            Passenger Inger = new Passenger(9);
            Passenger Emma = new Passenger(0);
            Passenger Felicia = new Passenger(6);
            Passenger Berit = new Passenger(9);

            zero.AddPassengerQueue(Adam);
            nine.AddPassengerQueue(Ture);
            zero.AddPassengerQueue(Bengt);
            seven.AddPassengerQueue(Astrid);
            three.AddPassengerQueue(Bo);
            five.AddPassengerQueue(Fredrik);
            two.AddPassengerQueue(Björn);
            eight.AddPassengerQueue(Eva);
            one.AddPassengerQueue(Inger);
            four.AddPassengerQueue(Emma);
            eight.AddPassengerQueue(Felicia);
            six.AddPassengerQueue(Berit);

           //Start(Otis);// Nåt har blibit konstigt här...
            Otis.AddPassenger(zero.Queue);
            Otis.SetDestination(Otis.CurrentPassenger);
            Otis.GoUpp(Levels, Otis.ElevatorDirection);
            Console.ReadLine();

        }
       static public void Start(Elevator o)
        {
            o.AddPassenger(o.CurrentPassenger);
            o.SetDestination(o.CurrentPassenger);
            
        }

    }
}
