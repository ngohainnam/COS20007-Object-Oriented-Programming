//Hai Nam Ngo
//Student ID: 103488515

namespace SemesterTest
{
    public class File : Thing
    {
        private string _extension;
        private int _size;

        public File(string name, string extension, int size) : base(name)
        {
            _extension = extension;
            _size = size;
        }

        public override int Size() 
        {
            //returns the size of the file
            return _size;
        }

        public override void Print() 
        {
            //this description is the file’s name, extension, and size
            Console.WriteLine($"File '{Name}.{_extension}' -- {_size} bytes \n"); 
        }
    }
}
