//Hai Nam Ngo
//Student ID: 103488515

using SemesterTest;

namespace SemesterTest
{
    public class Folder : Thing
    {
        private List<Thing> _contents;

        public Folder(string name) : base(name) 
        {
            _contents = new List<Thing>(); 
        }

        public void Add(Thing toAdd)
        {
            _contents.Add(toAdd);
        }

        public override int Size() 
        {
            int totalSize = 0;

            foreach (Thing file in _contents)
            {
                totalSize += file.Size();
            }
            return totalSize;
        }

        public override void Print()
        {
            //this description is the folder name
            Console.WriteLine($"The folder '{Name}' contains {Size()} bytes total: \n");

            foreach (Thing folder in _contents)
            {
                if (folder.Size() > 0)
                {
                    //a description of each of the files itcontain
                    foreach (Thing file in _contents)
                    {
                        file.Print();
                    }
                }
                else
                {
                    Console.WriteLine($"The folder '{folder.Name}' is empty! \n");
                }
            }
        }
    }
}

