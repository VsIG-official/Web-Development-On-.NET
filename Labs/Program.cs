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
        RemoveExample(cars);
    }

    private static void AddExample(Car[] cars)
    {
        var carsList = new CircularLinkedList<Car>();
        carsList.Add(cars[0]);
        carsList.AddFirst(cars[1]);
        carsList.AddAt(cars[2], 1);

        Console.WriteLine(carsList.ToString()); // Nissan Honda Toyota
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
}
