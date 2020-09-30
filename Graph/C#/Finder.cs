using Microsoft.AspNetCore.Http;
using System;

namespace Graph {
    public class Finder : IFinder {

        // This implementation finds the n'th node from the end of a Singly linked list (the object graph provided)
        // First intuition was to simply go from the head to the desired customer and subtract it with the length of the list
        // Upon a bit of confusion in regards to the inclusion of a customer name i decided to go with a doubler pointer approach
        // both pointers are intialized at the head, the refference pointer traverses the list to the end, marking the end of the singly linkked list
        // Afterwards the mainpointer will traverse the singly linked list to mark the n'th node from the end, and voila!
        public string FromRight(Customers customers, int numberFromRight)
        {

            // Both refference pointer and mainpointer is assigned to the head
            Customers mainPointer = customers;
            Customers refferencePointer = customers;

            // Initialize counter
            int count = 0;

            //Check if not null
            if (customers != null)
            {
                // while loop runs until count == numberfrom right
                while (count < numberFromRight)
                {
                    //Check if number provided is larger than the size of the object graph
                    if (refferencePointer == null)
                    {
                        return numberFromRight + " is greater than the no " + " of nodes in the list";
                    }

                    //Traverse the list with the refference pointer while incrementing the count value
                    refferencePointer = refferencePointer.Next;
                    count++;
                }

                //Traversing both the mainpointer and refference pointer should supply us with the n'th element from right by the mainpointer
                while (refferencePointer != null)
                {
                    mainPointer = mainPointer.Next;
                    refferencePointer = refferencePointer.Next;
                }

                // Return result if succesfull
                return "Node no. " + numberFromRight + " from last is " + mainPointer.Person;
            }

            // Present error messages if something unexpectally went wrong
            return "Something went wrong while traversing the customers, contact a server admin";
        }
    }
}