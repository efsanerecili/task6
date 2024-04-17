using Core;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                static void Main(string[] args)
                {
                    CustomList<int> myList = new CustomList<int>();

                    myList.Add(1);
                    myList.Add(2);
                    myList.Add(3);
                    myList.Add(4);
                    myList.Add(5);

                    myList.Remove(3);

                    Console.WriteLine("Count: " + myList.Count);
                    Console.WriteLine("Capacity: " + myList.Capacity);

                    Console.WriteLine("Items:");
                    myList.ForEach(Console.WriteLine);

                    Console.ReadKey();
                }
            }


        }
    }
    
}
