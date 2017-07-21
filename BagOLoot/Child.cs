
using System;
using System.Collections.Generic;

namespace BagOLoot
{
    public class Child : IEquatable<Child>
    {
        private int _childId;
        private string _name;
        private int _delivered;

        public int ChildId
        {
            get 
            {
                return _childId;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Delivered
        {
            get
            {
                return _delivered;
            }
        }

        public Child(int childId, string name, int delivered)
        {
            _childId = childId;
            _name = name;
            _delivered = delivered;
        }

        public bool Equals(Child other)
        {
            return this.ChildId == other.ChildId && 
            this.Name == other.Name && 
            this.Delivered == other.Delivered; 
      
        }
    }
}