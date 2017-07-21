
using System;
using System.Collections.Generic;

namespace BagOLoot
{
    public class Child 
    {
        private int _childId;
        private string _name;
        private int _delivered;

        public int ChildId{ get; set;}

        public string Name {get; set;}

        public int Delivered{get; set;}

        public Child(int childId, string name, int delivered)
        {
            _childId = childId;
            _name = name;
            _delivered = delivered;
        }
    }
}