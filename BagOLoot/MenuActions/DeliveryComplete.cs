using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot.MenuActions
{
    public class DeliveryComplete
    {
        public static void DoAction(ChildRegister registry, SantasHelper santa)
        {
            Console.Clear();
            Console.WriteLine("Select A Child To See Their Delivery Status");
            List<Child> childrenGettingToys = santa.GetChildrenWhoGetToys();
            int childCount = 1;
            foreach(Child child in childrenGettingToys)
            {
                Console.WriteLine($"{childCount} {child.Name}");
            }
            int choice;
            Int32.TryParse (Console.ReadLine(), out choice);
            int selectedChildIndex = choice -1;

            bool isDelivered = santa.ChildDeliveryStatus(childrenGettingToys[selectedChildIndex].ChildId);
            if(isDelivered == false)
            {
            Console.WriteLine($"{childrenGettingToys[selectedChildIndex].Name}'s presents have not been delivered");

            }else
            {
            Console.WriteLine($"{childrenGettingToys[selectedChildIndex].Name}'s presents have been delivered");
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