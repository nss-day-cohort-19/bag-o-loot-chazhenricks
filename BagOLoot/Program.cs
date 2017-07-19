using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            db.CheckForChildTable();
            db.CheckForToyTable();

            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Register a child");
            Console.WriteLine ("2. Assign a toy to a child");
            Console.WriteLine ("3. Revoke a toy from a child");
            Console.WriteLine ("4. Review a child's toy list");
            Console.WriteLine ("5. Child toy delivery complete");
            Console.WriteLine ("6. Yuletime delivery report");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                ChildRegister registry = new ChildRegister();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
        }
    }
}
