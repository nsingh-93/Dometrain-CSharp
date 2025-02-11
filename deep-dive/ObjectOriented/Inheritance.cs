namespace ObjectOriented;

public class Inheritance
{
    public class Vehicle
    {
        public int DoorCount { get; init; }

        public void OpenDoors()
        {
            Console.WriteLine($"{ GetType().Name } opening { DoorCount } doors");
        }
    }

    public class Automobile : Vehicle
    {
    }

    public class Car : Automobile
    {
    }

    public class Truck : Automobile
    {
    }

    public class Van : Automobile
    {
    }

    public class Bike : Vehicle
    {
        public Bike()
        {
            DoorCount = 0;
        }
    }

    public class Plane : Vehicle
    {
    }

    public static void RunInheritance()
    {
        Car sedan = new() { DoorCount = 4 };
        Car coupe = new() { DoorCount = 2 };

        Truck pickupTruck = new() { DoorCount = 2 };
        
        Bike bike = new();

        sedan.OpenDoors();
        coupe.OpenDoors();

        pickupTruck.OpenDoors();
        
        bike.OpenDoors();
    }
}
