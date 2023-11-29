//Hai Nam Ngo
//Student ID: 103488515

namespace SemesterTest
{
    class Program
    {
        static void Main()
        {
            // a) Creating a FileSystem
            FileSystem FileSys = new FileSystem();

            // b) Adding files to the file system
            //creat a new file
            File file1 = new File("Save 1 - Hai Nam Ngo's podcast of the Day", "mp3", 100);
            //add file to the file system
            FileSys.Add(file1);

            // c) Adding a folder that contains files to the file system
            Folder folder1 = new Folder("Audio");
            File file2 = new File("Save 2 - Radio", "mp4", 200);
            folder1.Add(file2);
            FileSys.Add(folder1);

            // d) Adding a folder that contains a folder that contains files to the file system
            Folder subFolder1 = new Folder("Scripts");
            File file3 = new File("Podcast Script (made by Hai Nam Ngo)", "txt", 300);
            subFolder1.Add(file3);

            Folder folder2 = new Folder("Text File");
            folder2.Add(subFolder1);
            FileSys.Add(folder2);

            // e) Adding an empty folder to the file system
            Folder emptyFolder = new Folder("Sountrack");
            FileSys.Add(emptyFolder);

            // f) Calling the PrintContents method
            FileSys.PrintContents();
        }
    }
}
