using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_task__Singly_linked_list_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SinglyLinkedList<int> numbers = new SinglyLinkedList<int>();
                numbers.Add(1);
                numbers.Insert(0, 0);
                numbers.Insert(2, 2);
                numbers.Add(3);
                numbers.Add(4);
                numbers.Add(5);
                numbers.RemoveAt(3);
                Console.WriteLine($"Number of elements: {numbers.Count}");
                foreach (int i in numbers)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine($"Second element is: {numbers.GetByIndex(1)}");
                Console.WriteLine("Odd numbers:");
                //LINQ query for getting odd numbers from the list
                var oddNumbers = from num in numbers
                           where (num % 2) == 1
                           select num;
                foreach (int num in oddNumbers)
                {
                    Console.WriteLine(num);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
