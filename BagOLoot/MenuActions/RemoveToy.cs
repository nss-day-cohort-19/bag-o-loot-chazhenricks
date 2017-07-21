using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot.MenuActions
{
    public class RemoveToy
    {
        public static void DoAction(ChildRegister registry, SantasHelper santa)
        {
            Console.Clear();
            Console.WriteLine ("Select The Number Of A Child You Wish To Take A Toy Away From.");
            List<Child> listOfChildrenRemove = santa.GetChildrenWhoGetToys();
            int childCounter = 1;
            foreach(Child child in listOfChildrenRemove)
            {
                Console.WriteLine($"{childCounter}. {child.Name}");
                childCounter++;
            }
            Console.Write ("> ");
            int choice;
			Int32.TryParse (Console.ReadLine(), out choice);
            int selectedChildIndex = choice -1;


            Console.Clear();
            Console.WriteLine($"Select A Toy You Wish To Take Away From {listOfChildrenRemove[selectedChildIndex].Name}");
            List<Toy> listOfToysToRemove = santa.GetChildToyList(listOfChildrenRemove[selectedChildIndex].ChildId);
            int toyCounter = 1;

            foreach(Toy toy in listOfToysToRemove)
            {
                Console.WriteLine($"{toyCounter}. {toy.Name}");
                toyCounter++;
            }
            Console.WriteLine(">");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            string enteredKeyString = enteredKey.KeyChar.ToString();
            int indexValue = int.Parse(enteredKeyString) -1;
            int selectedToyId = listOfToysToRemove[indexValue].ToyId;
            santa.RemoveItemFromBag(selectedToyId, listOfChildrenRemove[selectedChildIndex].ChildId);
            
        }
    }
}