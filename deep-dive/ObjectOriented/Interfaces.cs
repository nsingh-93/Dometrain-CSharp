namespace ObjectOriented;

public class Interfaces
{
    public interface IHasDoors
    {
        int NumberOfDoors { get; }

        void OpenDoor(int doorIndex);
        void CloseDoor(int doorIndex);
        bool IsDoorOpen(int doorIndex);
    }

    public interface IMotorized
    {
        bool IsEngineRunning { get; }

        void StartEngine();
        void StopEngine();
    }

    public class Bicycyle
    {
    }

    public class Motorcycle : IMotorized
    {
        public bool IsEngineRunning { get; private set; }

        public void StartEngine()
        {
            if (IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = true;

            Console.WriteLine("Engine started!");
        }

        public void StopEngine()
        {
            if (!IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = false;

            Console.WriteLine("Engine stopped!");
        }
    }

    public class Room : IHasDoors
    {
        private readonly bool[] _doors;

        public Room(int numberOfDoors)
        {
            _doors = new bool[numberOfDoors];
        }

        public int NumberOfDoors => _doors.Length;

        public void OpenDoor(int doorIndex)
        {
            _doors[doorIndex] = true;
        }

        public void CloseDoor(int doorIndex)
        {
            _doors[doorIndex] = false;
        }

        public bool IsDoorOpen(int doorIndex)
        {
            return _doors[doorIndex];
        }
    }

    public class Car : IHasDoors, IMotorized
    {
        private readonly bool[] _doors;

        public Car(int numberOfDoors)
        {
            _doors = new bool[numberOfDoors];
        }

        public bool IsEngineRunning { get; private set; }

        public int NumberOfDoors => _doors.Length;

        public void OpenDoor(int doorIndex)
        {
            _doors[doorIndex] = true;
        }

        public void CloseDoor(int doorIndex)
        {
            _doors[doorIndex] = false;
        }

        public bool IsDoorOpen(int doorIndex)
        {
            return _doors[doorIndex];
        }

        public void StartEngine()
        {
            if (IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = true;
            Console.WriteLine("Engine started!");
        }

        public void StopEngine()
        {
            if (!IsEngineRunning)
            {
                return;
            }

            IsEngineRunning = false;
            Console.WriteLine("Engine stopped!");
        }
    }

    public static void RunInterfaces()
    {
        Motorcycle motorcycle = new();

        motorcycle.StartEngine();
        Console.WriteLine(motorcycle.IsEngineRunning);

        motorcycle.StopEngine();
        Console.WriteLine(motorcycle.IsEngineRunning);

        motorcycle.StopEngine();
        Console.WriteLine(motorcycle.IsEngineRunning);

        // Upcasting and downcasting aren't great to do, but can be done
        IMotorized motorized = motorcycle;
        Motorcycle motorcycle2 = (Motorcycle)motorized;


        Car coupe = new(2);
        Car sedan = new(4);

        TestIgnition(coupe);
        TestIgnition(sedan);

        TestDoors(coupe);
        TestDoors(sedan);
    }

    static void TestIgnition(IMotorized motorized)
    {
        motorized.StartEngine();
        Console.WriteLine($"Engine is running: { motorized.IsEngineRunning }");

        motorized.StopEngine();
        Console.WriteLine($"Engine is running: { motorized.IsEngineRunning }");
    }

    static void TestDoors(IHasDoors hasDoors)
    {
        for (int i = 0; i < hasDoors.NumberOfDoors; i++)
        {
            hasDoors.OpenDoor(i);
            Console.WriteLine($"Door { i } is open: { hasDoors.IsDoorOpen(i) }");
        }
    }
}
