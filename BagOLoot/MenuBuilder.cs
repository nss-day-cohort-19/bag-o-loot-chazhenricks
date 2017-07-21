using System;

namespace BagOLoot
{
    public class MenuBuilder
    {
        public int ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Register a child");
            Console.WriteLine ("2. Assign a toy to a child");
            Console.WriteLine ("3. Revoke a toy from a child");
            Console.WriteLine ("4. Review a child's toy list");
            Console.WriteLine ("5. Child toy delivery status");
            Console.WriteLine ("6. Yuletime delivery report");
            Console.WriteLine ("7. Exit");
			Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            return int.Parse(enteredKey.KeyChar.ToString());
        }
    }
}