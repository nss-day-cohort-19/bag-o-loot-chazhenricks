using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot.MenuActions
{
    public class ViewToyList
    {
        public static void DoAction(ChildRegister registry, SantasHelper santa)
        {
            Console.Clear();
            Console.WriteLine("Select A Child From The List To See The Toys They Will Be Getting");
            List<Child>childrenToGetToys = santa.GetChildrenWhoGetToys();
            int nameCount = 1;
            foreach(Child child in childrenToGetToys)
            {
                Console.WriteLine($"{nameCount} {child.Name}");
                nameCount++;
            }
            
            int choice;
            Int32.TryParse (Console.ReadLine(), out choice);
            int selectedChildIndex = choice -1;
            List<Toy> childToyList = santa.GetChildToyList(childrenToGetToys[selectedChildIndex].ChildId);

            Console.Clear();
            Console.WriteLine($"These are the toys {childrenToGetToys[selectedChildIndex].Name} is getting");
            int toyCount = 1;
            foreach(Toy toy in childToyList)
            {
                Console.WriteLine($"{nameCount} {toy.Name}");
                toyCount++;
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