//Hai Nam Ngo
//Student ID: 103488515

namespace SemesterTest
{
    public abstract class Thing
    {
        private readonly string _name;

        public Thing(string name)
        {
            _name = name; 
        }

        public abstract int Size();

        public abstract void Print();

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
