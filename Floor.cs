namespace Elevator
{
    class Floor 
    {
        public int FloorLevel { get; private set; } //behövs ens denna
        public List<Passenger> Queue { get; private set; }
        public Floor(int _floor) 
        {
            FloorLevel = _floor;
            Queue = new List<Passenger> { };

        }
        public void AddPassengerQueue(Passenger a)
        {
            Queue.Add(a);

        }
        public void RemovePassengerQueue(Passenger a)
        {
            Queue.Remove(a);
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}


