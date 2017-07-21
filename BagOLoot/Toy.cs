namespace BagOLoot
{

    public class Toy 
    {
        private int _toyId;
        private string _name;
        private int _childId;

        public int ToyId
        {
            get 
            {
                return _toyId;
            }
        }
        public string Name 
        {
            get
            {
                return _name;
            }
        }
        public int ChildId 
        {
            get 
            {
                return _childId;
            }
        }
        public Toy(int toyId, string name, int childId)
        {
            _toyId = toyId;
            _name = name;
            _childId = childId;
        }
    }
}
