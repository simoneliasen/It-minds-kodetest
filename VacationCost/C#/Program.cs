using System;

namespace VacationCost {
    class Program {
        private static void Main(string[] args)
        {

            // Loop until user is given an estimate of their vaication cost
            while (true)
            {
                // Request user input
                Console.WriteLine("Please enter your veichle of choice eg. Car");
                var veichle = Console.ReadLine().ToLower();
                Console.WriteLine("Please enter the distance to your destination eg. 5502");
                var distance = Console.ReadLine().ToLower();

                // Validate user input
                if (!string.IsNullOrEmpty(veichle) && !string.IsNullOrEmpty(distance))
                {

                    // Instantiate cost calculator
                    VacationCostCalculator calculator = new VacationCostCalculator { DistanceToDestination = double.Parse(distance) };

                    // Check if input is unsupported (i know this isn't ideal, but at the time of writing i just had spent way to much time on this section) //** TODO **// ;-)
                    if (calculator.CostOfVacation(veichle) is not null)
                    {
                        Console.WriteLine(calculator.CostOfVacation(veichle));
                        break;
                    }

                    // Error message on bad user input
                    Console.WriteLine("You provided a non-supported veichle, try again!");

                }
            }
        }
    }
}






