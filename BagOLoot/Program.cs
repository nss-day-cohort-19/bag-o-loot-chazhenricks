using System;
using System.Collections.Generic;
using BagOLoot.MenuActions;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChildRegister registry = new ChildRegister();
            SantasHelper santa = new SantasHelper();
            MenuBuilder menu = new MenuBuilder();

            var db = new DatabaseInterface();
            db.CheckForChildTable();
            db.CheckForToyTable();


            
			// Read in the user's choice
			int choice;
            do{
                choice = menu.ShowMainMenu();

                switch (choice)
                {
                    case 1:
                        AddChild.DoAction(registry);
                        break;

                    case 2:
                        AssignToy.DoAction(registry, santa);
                        break;

                    case 3:
                        RemoveToy.DoAction(registry, santa);
                        break;

                    case 4:
                        ViewToyList.DoAction(registry, santa);
                        break;

                    case 5:
                    DeliveryComplete.DoAction(registry, santa);
                    break;
                    
                    case 6:
                    YuletimeDelivery.DoAction(registry, santa);
                    break;

                }
            }while(choice != 7);
        }
    }
}
