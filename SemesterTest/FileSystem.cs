//Hai Nam Ngo
//Student ID: 103488515

namespace SemesterTest
{
    public class FileSystem
    {
        private List<Thing> _contents;

        public FileSystem()
        {
            _contents = new List<Thing>();
        }

        public void Add(Thing toAdd)
        {
            _contents.Add(toAdd);
        }

        public void PrintContents()
        {
            Console.WriteLine("This file system contains: \n");
            foreach (Thing folder in _contents)
            {
                folder.Print();
            }
        }
    }
}
