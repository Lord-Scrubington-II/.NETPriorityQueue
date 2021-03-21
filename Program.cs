using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace DotNETPriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            bool badInput = false;
            int heapSize = 0;
            bool usingMinHeap = false;
            PriorityQueue<int> theQueue = new PriorityQueue<int>();

            Console.WriteLine(".NET Priority Queue Test\r");
            Console.WriteLine("------------------------\n");

            //initialize the test subject
            do
            {
                //get heapsize
                Console.WriteLine("Enter the initial capacity of the Priority Queue: ");
                string heapSizeStr = Console.ReadLine();

                while (!int.TryParse(heapSizeStr, out heapSize))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    heapSizeStr = Console.ReadLine();
                }

                if (heapSize <= 0)
                {
                    Console.WriteLine("Invalid HeapSize.");
                    badInput = true;
                    continue;
                }

                //get heaptype
                Console.WriteLine("Using M(i)nheap or M(a)xheap?: ");
                string heapType = Console.ReadLine();
                switch (heapType)
                {
                    case "i":
                        Console.WriteLine($"Using Minheap.");
                        usingMinHeap = true;
                        badInput = false;
                        break;
                    case "a":
                        Console.WriteLine($"Using Maxheap.");
                        usingMinHeap = false;
                        badInput = false;
                        break;
                    default:
                        Console.WriteLine("Invalid HeapType.");
                        badInput = true;
                        break;
                }
                
            } while (badInput);

            //init priority queue
            if (usingMinHeap)
            {
                theQueue = new PriorityQueue<int>(heapSize, PriorityQueue<int>.MinHeapCompare);
            }
            else
            {
                theQueue = new PriorityQueue<int>(heapSize, PriorityQueue<int>.MaxHeapCompare);
            }

            //test loop
            do
            {
                Console.WriteLine("Please enter a test directive: ");
                Console.WriteLine("\ti - Insert");
                Console.WriteLine("\tr - Remove");
                Console.WriteLine("\tl - Look at Top");
                Console.WriteLine("\tw - Write");
                Console.WriteLine("\to - Write Ordered");
                Console.WriteLine("\tc - Clear the Queue");
                Console.WriteLine("\ts - Stop Test");
                Console.Write("Selection: ");

                switch (Console.ReadLine())
                {
                    //on insert
                    case "i":
                        Console.WriteLine($"Enter an integer: ");
                        string toInsertString = Console.ReadLine();
                        int toInsert;

                        if(!int.TryParse(toInsertString, out toInsert))
                        {
                            Console.WriteLine("This is not valid input. Please enter an integer value!");
                        }
                        else
                        {
                            theQueue.Enqueue(toInsert);
                        }

                        break;
                    
                    //on remove
                    case "r":
                        try
                        {
                            int removed = theQueue.Dequeue();
                            Console.WriteLine($"Item removed: {removed}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("The queue is empty!");
                        }
                        break;

                    //on look top
                    case "l":
                        try
                        {
                            Console.WriteLine($"Item at top of heap:\n {theQueue.LookTop()}");
                        } catch (InvalidOperationException)
                        {
                            Console.WriteLine("The queue is empty!");
                        }
                        break;

                    //on write
                    case "w":
                        Console.WriteLine($"Contents of heap:\n {theQueue}");
                        break;
                    
                    //on write - ordered
                    case "o":
                        int[] sortedArray = theQueue.ToArraySorted();
                        string outString = "";
                        foreach(int i in sortedArray)
                        {
                            outString += "" + i + " ";
                        }
                        Console.WriteLine($"Sorted contents of heap:\n {outString}");
                        break;
                    
                    //on clear
                    case "c":
                        theQueue.Clear();
                        Console.WriteLine($"Priority queue has been emptied. Contents: \n {theQueue} \n");
                        break;

                    //on stop
                    case "s":
                        Console.WriteLine($"Stopping the test.");
                        Console.WriteLine($"Contents of heap on exit:\n {theQueue}");
                        end = true;
                        break;

                    //bad input
                    default:
                        Console.WriteLine("Unrecognized Command.");
                        break;
                }

            } while (!end);
        }
    }
}
