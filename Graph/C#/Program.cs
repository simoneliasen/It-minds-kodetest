using System;
using System.Threading;

namespace Graph {
    class Program {
        static void Main()
        {
            var currentCustomer = Customers
                .Create("Kim")
                .Previous("Hans")
                .Previous("Ole")
                .Previous("Peter");

            // Implementation of Finder method
            IFinder instance = new Finder();
            Console.WriteLine(instance.FromRight(currentCustomer, 3));

            // Print list items 
            while (currentCustomer != null)
            {
                if (currentCustomer.Next != null)
                    Console.Write(currentCustomer.Person + " -> ");
                else
                    Console.WriteLine(currentCustomer.Person);

                currentCustomer = currentCustomer.Next;
            }

            Console.ReadLine();
        }
    }
}
