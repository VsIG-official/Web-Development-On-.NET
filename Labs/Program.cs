using Lab1.CircularLinkedList;

namespace Labs;

internal class Program
{
    private static void Main()
    {
        Car firstCar = new(1, "Toyota", "Red");
        Car secondCar = new(2, "Nissan", "White");
        Car thirdCar = new(3, "Honda", "Black");

        Car[] cars = new Car[] { firstCar, secondCar, thirdCar };

        //AddExample(cars);
        //RemoveExample(cars);
        //ForeachExample(cars);
        OtherFeaturesExample(cars);
    }

    private static void AddExample(Car[] cars)
    {
        var carsList = new CircularLinkedList<Car>();
        carsList.Add(cars[0]);

        Console.WriteLine(carsList.ToString()); // Toyota
        Console.WriteLine("///////");

        carsList.AddFirst(cars[1]);

        Console.WriteLine(carsList.ToString()); // Nissan Toyota
        Console.WriteLine("///////");

        carsList.AddAt(cars[2], 1);

        Console.WriteLine(carsList.ToString()); // Nissan Honda Toyota
        Console.WriteLine("///////");
    }

    private static void RemoveExample(Car[] cars)
    {
        var carsList = new CircularLinkedList<Car>();
        carsList.Add(cars[2]);
        carsList.Add(cars[0]);
        carsList.Add(cars[0]);
        carsList.Add(cars[0]);
        carsList.Add(cars[1]);
        carsList.Add(cars[2]);
        Console.WriteLine(carsList.ToString()); // Honda Toyota Toyota Toyota Nissan Honda

        Console.WriteLine("///////");

        carsList.RemoveAt(2);
        Console.WriteLine(carsList.ToString()); // Honda Toyota Toyota Nissan Honda

        Console.WriteLine("///////");

        carsList.Remove(cars[1]);
        Console.WriteLine(carsList.ToString()); // Honda Toyota Toyota Honda

        Console.WriteLine("///////");

        carsList.RemoveHead();
        Console.WriteLine(carsList.ToString()); // Toyota Toyota Honda

        Console.WriteLine("///////");

        carsList.RemoveTail();
        Console.WriteLine(carsList.ToString()); // Toyota Toyota

        Console.WriteLine("///////");

        carsList.RemoveAll(cars[0]);
        Console.WriteLine(carsList.ToString()); // -_-
        Console.WriteLine("///////");
    }

    private static void ForeachExample(Car[] cars)
    {
        var carsList = new CircularLinkedList<Car>();
        carsList.Add(cars[0]);
        carsList.Add(cars[1]);
        carsList.Add(cars[2]);

        foreach (var car in carsList)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("//////");

        foreach (var car in carsList.Reverse())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("//////");
    }

    private static void OtherFeaturesExample(Car[] cars)
    {
        var carsList = new CircularLinkedList<Car>(cars[0]);
        carsList.Add(cars[1]);
        carsList.Add(cars[2]);

        Console.WriteLine(carsList.Contains(cars[0])); // True;

        Console.WriteLine("//////");

        Car[] carsCopy = new Car[carsList.Count];
        carsList.CopyTo(carsCopy, 0);

        carsList.Clear();

        Console.WriteLine(carsList.ToString()); // -_-

        Console.WriteLine("//////");

        Console.WriteLine(carsCopy[0]); // Toyota

        Console.WriteLine("//////");

        carsCopy[0] = carsCopy[1];

        Console.WriteLine(carsCopy[0]); // Nissan
    }
}
