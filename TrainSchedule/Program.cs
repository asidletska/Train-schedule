using System;
using System.Linq;


namespace TrainSchedule
{
    struct Train
    {
        public string Destination { get; set; }
        public int TrainNumber { get; set; }
        public DateTime DepartureTime { get; set; }

        public Train(string destination, int trainNumber, DateTime departureTime)
        {
            Destination = destination;
            TrainNumber = trainNumber;
            DepartureTime = departureTime;
        }

        public override string ToString()
        {
            return $"Traine number: {TrainNumber}, Destination: {Destination}, Departure Time: {DepartureTime:HH:mm}";
        }
    }
    class Program
    {
        static void Main()
        {
            const int numberOfTrains = 8;

            Train[] trains = new Train[numberOfTrains];

            for (int i = 0; i < numberOfTrains; i++)
            {
                Console.WriteLine($"Enter details for train {i + 1}: ");

                Console.Write("Destination: ");
                string destination = Console.ReadLine();
                Console.Write("Train number: ");
                int numberTrain = int.Parse(Console.ReadLine());

                Console.Write("Departure time (HH:mm): ");
                DateTime departureTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);

                trains[i] = new Train(destination, numberTrain, departureTime);
            }

            Array.Sort(trains, (train1, train2) => train1.TrainNumber.CompareTo(train2.TrainNumber));

            Console.Write("Enter train number to search: ");
            int searchNumber = int.Parse(Console.ReadLine());

            var FoundTrain = trains.FirstOrDefault(t => t.TrainNumber == searchNumber);

            if (FoundTrain.TrainNumber != 0)
            {
                Console.WriteLine(FoundTrain);
            }
            else
            {
                Console.WriteLine("Train not found");
            }
        }
    }
}
