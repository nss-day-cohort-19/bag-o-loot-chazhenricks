using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot.MenuActions
{
    public class AddChild
    {
        public static void DoAction(ChildRegister registry)
        {
                Console.Clear();
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
        }
    }
}