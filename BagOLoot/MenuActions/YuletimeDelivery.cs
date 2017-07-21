using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot.MenuActions
{
    public class YuletimeDelivery
    {
        public static void DoAction(ChildRegister registry, SantasHelper santa)
        {
            Console.Clear();
            Console.WriteLine("YULETIME DELIVERY REPORT");
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%");

            List<Child> childrenToGetPresents = santa.GetChildrenWhoGetToys();
            foreach(Child child in childrenToGetPresents)
            {
                Console.WriteLine(child.Name);
                List<Toy> childToyList = santa.GetChildToyList(child.ChildId);
                foreach(Toy toy in childToyList)
                {
                    Console.WriteLine($"   {toy.Name}");
                }
            }
            Console.WriteLine($"Press 9 to exit");

            int escapeKey;
            Int32.TryParse (Console.ReadLine(), out escapeKey);
            do
            {
            }while(escapeKey != 9);
        }
    }
}