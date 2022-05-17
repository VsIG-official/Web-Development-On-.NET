using Lab1.CircularLinkedList;

namespace Labs;

internal class Program
{
    private static CircularLinkedList<Car> s_listing = new();

    private static void Main()
    {
        Car firstCar = new(1, "Toyota", "Red");
        Car secondCar = new(2, "Nissan", "White");
        Car thirdCar = new(3, "Honda", "Black");

        Car[] cars = new Car[] { firstCar, secondCar, thirdCar };

        s_listing.Added += OnAdded;
        s_listing.Removed += OnRemoved;

        RunAllExamples(cars);
    }

    private static void RunAllExamples(Car[] cars)
    {
        //AddExample(cars);
        //RemoveExample(cars);
        //ForeachExample(cars);
        OtherFeaturesExample(cars);
    }

    private static void OnAdded()
    {
        Console.WriteLine("New element added");
        Console.WriteLine(s_listing.ToString());
    }

    private static void OnRemoved()
    {
        Console.WriteLine("Element removed");
        Console.WriteLine(s_listing.ToString());
    }

    private static void AddExample(Car[] cars)
    {
        s_listing.Add(cars[0]);

        // Toyota

        s_listing.AddFirst(cars[1]);

        // Nissan Toyota
        
        s_listing.AddAt(cars[2], 1);

        // Nissan Honda Toyota

        ResetList();
    }

    private static void RemoveExample(Car[] cars)
    {
        s_listing.Add(cars[2]);
        s_listing.Add(cars[0]);
        s_listing.Add(cars[0]);
        s_listing.Add(cars[0]);
        s_listing.Add(cars[1]);
        s_listing.Add(cars[2]);

        // Honda Toyota Toyota Toyota Nissan Honda

        s_listing.RemoveAt(2);

        // Honda Toyota Toyota Nissan Honda

        s_listing.Remove(cars[1]);

        // Honda Toyota Toyota Honda

        s_listing.RemoveHead();

        // Toyota Toyota Honda

        s_listing.RemoveTail();

        // Toyota Toyota

        s_listing.RemoveAll(cars[0]);

        // Toyota
        // -_-
    }

    private static void ForeachExample(Car[] cars)
    {
        s_listing.Add(cars[0]);
        s_listing.Add(cars[1]);
        s_listing.Add(cars[2]);

        // Toyota Nissan Honda

        foreach (var car in s_listing)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("//////");

        foreach (var car in s_listing.Reverse())
        {
            Console.WriteLine(car);
        }
        Console.WriteLine();

        ResetList();
    }

    private static void OtherFeaturesExample(Car[] cars)
    {
        s_listing.Add(cars[0]);
        s_listing.Add(cars[1]);
        s_listing.Add(cars[2]);

        // Toyota Nissan Honda

        Console.WriteLine(s_listing.Contains(cars[0])); // True;
        Console.WriteLine("//////");

        CircularLinkedList<Car> carClone = (CircularLinkedList<Car>)s_listing.Clone();
        Console.WriteLine(carClone.ToString());

        // Toyota Nissan Honda

        Car[] carsCopy = new Car[s_listing.Count];
        s_listing.CopyTo(carsCopy, 0);

        s_listing.Clear();

        Console.WriteLine(s_listing.ToString()); // -_-
        Console.WriteLine("//////");

        Console.WriteLine(carsCopy[0]); // Toyota
        Console.WriteLine("//////");

        carsCopy[0] = carsCopy[1];

        Console.WriteLine(carsCopy[0]); // Nissan
        Console.WriteLine();

        ResetList();
    }

    private static void ResetList()
    {
        s_listing.Clear();
    }
}
