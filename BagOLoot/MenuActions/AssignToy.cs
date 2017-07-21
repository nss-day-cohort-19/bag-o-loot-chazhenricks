using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot.MenuActions
{
    public class AssignToy
    {
        public static void DoAction(ChildRegister registry, SantasHelper santa)
        {
            
            Console.Clear();
            Console.WriteLine ("Select The Number Of A Child You Wish To Give A Toy To.");
            List<Child> listOfChildren = registry.GetChildren();
            int counter = 1;
            foreach(Child child in listOfChildren)
            {
                Console.WriteLine($"{counter}. {child.Name}");
                counter++;
            }
            Console.Write ("> ");
            int choice;
			Int32.TryParse (Console.ReadLine(), out choice);
            int selectedChildIndex = choice -1;
            Console.Clear();
            Console.WriteLine($"Enter A Toy You Wish To Give To {listOfChildren[selectedChildIndex].Name}");
            Console.WriteLine(">");
            string toyToAdd = Console.ReadLine();
            santa.AddItemToBag(toyToAdd, listOfChildren[selectedChildIndex].ChildId);
            listOfChildren.Clear();
        }
    }
}