namespace ObjectOriented;

public class HeadToHead
{
    public enum DoorPosition
    {
        FrontDriverSide,
        FrontPassengerSide,
        RearDriverSide,
        RearPassengerSide
    }

    // Inheritance section
    public abstract class Vehicle
    {
    }

    public abstract class Automobile : Vehicle
    {
        public abstract void StartEngine();

        public abstract void OpenDoor(DoorPosition doorPosition);
    }

    public abstract class ConfigAutomobile : Vehicle
    {
        private readonly string _engineType;

        protected ConfigAutomobile(string engineType)
        {
            _engineType = engineType;
        }

        public void StartEngine()
        {
            StartEngine(_engineType);
        }

        public abstract void OpenDoor(DoorPosition doorPosition);

        protected static void StartEngine(string engineType)
        {
            Console.WriteLine($"Starting { engineType } engine");
        }
    }

    public abstract class Car : Automobile
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car starting engine 1.8L engine");
        }
    }

    public class Sedan : Car
    {
        public override void OpenDoor(DoorPosition doorPosition)
        {
            Console.WriteLine($"Sedan opening { doorPosition } door");
        }
    }

    public class Coupe : Car
    {
        public override void OpenDoor(DoorPosition doorPosition)
        {
            if (doorPosition == DoorPosition.RearDriverSide ||
                doorPosition == DoorPosition.RearPassengerSide)
            {
                throw new InvalidOperationException("Coupes only have two doors");
            }

            Console.WriteLine($"Coupe opening { doorPosition } door");
        }
    }

    public class PickupTruck : Automobile
    {
        public override void StartEngine()
        {
            Console.WriteLine("Truck starting engine 3.6L engine");
        }

        public override void OpenDoor(DoorPosition doorPosition)
        {
            if (doorPosition == DoorPosition.RearDriverSide ||
                doorPosition == DoorPosition.RearPassengerSide)
            {
                throw new InvalidOperationException("Coupes only have two doors");
            }

            Console.WriteLine($"Truck opening { doorPosition } door");
        }
    }

    public class Van : Automobile
    {
        public override void StartEngine()
        {
            Console.WriteLine("Van starting engine 3.6L engine");
        }

        public override void OpenDoor(DoorPosition doorPosition)
        {
            if (doorPosition == DoorPosition.RearDriverSide ||
                doorPosition == DoorPosition.RearPassengerSide)
            {
                Console.WriteLine($"Van sliding open { doorPosition } door");
            }
            else
            {
                Console.WriteLine($"Van swinging open { doorPosition } door");
            }
        }
    }

    // Composition section
    public interface IEngine
    {
        void Start();
    }

    public class V8Engine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("V8 engine starting");
        }
    }

    public class ConfigurableEngine : IEngine
    {
        private readonly float _displacementInLiters;

        public ConfigurableEngine(float displacementInLiters)
        {
            _displacementInLiters = displacementInLiters;
        }

        public void Start()
        {
            Console.WriteLine($"Starting { _displacementInLiters }L engine");
        }
    }

    public interface IDoor
    {
        void Open();
    }

    public class SwingingDoor : IDoor
    {
        public void Open()
        {
            Console.WriteLine($"Swinging door opening");
        }
    }

    public class SlidingDoor : IDoor
    {
        public void Open()
        {
            Console.WriteLine($"Sliding door opening");
        }
    }

    public class ComposedVehicle
    {
        private readonly IEngine _engine;
        private readonly IReadOnlyDictionary<DoorPosition, IDoor> _doors;

        public ComposedVehicle(IEngine engine,
                               Dictionary<DoorPosition, IDoor> doors)
        {
            _engine = engine;
            _doors = doors;
        }

        public void StartEngine()
        {
            _engine.Start();
        }

        public void OpenDoor(DoorPosition doorPosition)
        {
            if (!_doors.TryGetValue(doorPosition, out IDoor? door))
            {
                throw new InvalidOperationException($"There is no door at position { doorPosition }");
            }

            Console.WriteLine($"Opening { doorPosition } door");
            door.Open();
        }
    }

    // Composition and iheritance
    public abstract class EngineSwapCoupe : Coupe
    {
        private readonly IEngine _engine;

        protected EngineSwapCoupe(IEngine engine)
        {
            _engine = engine;
        }

        public override void StartEngine()
        {
            _engine.Start();
        }
    }

    public static void RunHeadToHead()
    {
        Automobile sedan = new Sedan();
        Automobile coupe = new Coupe();
        Automobile pickupTruck = new PickupTruck();
        Automobile van = new Van();

        ComposedVehicle composedSedan = new(
            new ConfigurableEngine(1.8f),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new SwingingDoor() },
                { DoorPosition.FrontPassengerSide, new SwingingDoor() },
                { DoorPosition.RearDriverSide, new SwingingDoor() },
                { DoorPosition.RearPassengerSide, new SwingingDoor() }
            });

        ComposedVehicle composedCoupe = new(
            new ConfigurableEngine(1.8f),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new SwingingDoor() },
                { DoorPosition.FrontPassengerSide, new SwingingDoor() }
            });

        ComposedVehicle composedPickupTruck = new(
            new V8Engine(),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new SwingingDoor() },
                { DoorPosition.FrontPassengerSide, new SwingingDoor() },
            });

        ComposedVehicle composedPickupTruck2 = new(
            new V8Engine(),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new SwingingDoor() },
                { DoorPosition.FrontPassengerSide, new SwingingDoor() },
                { DoorPosition.RearDriverSide, new SwingingDoor() },
                { DoorPosition.RearPassengerSide, new SwingingDoor() }
            });

        ComposedVehicle composedVan = new(
            new ConfigurableEngine(3.6f),
            new Dictionary<DoorPosition, IDoor>
            {
                { DoorPosition.FrontDriverSide, new SwingingDoor() },
                { DoorPosition.FrontPassengerSide, new SwingingDoor() },
                { DoorPosition.RearDriverSide, new SlidingDoor() },
                { DoorPosition.RearPassengerSide, new SlidingDoor() }
            });
    }
}
