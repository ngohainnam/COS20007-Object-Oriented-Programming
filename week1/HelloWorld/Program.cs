using System;

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Local variables
            Message myMessage;
            Message[] messages = new Message[5];
            string name;

            //Creating a message
            myMessage = new Message("Hello World...");
            //print out the message
            myMessage.Print();

            //assigning 5 messages to the array
            messages[0] = new Message("That is a good name");
            messages[1] = new Message("Interesting name");
            messages[2] = new Message("Such a beautiful name you have");
            messages[3] = new Message("Welcome welcome");
            messages[4] = new Message("Silly but cute");

            //Ask user for the name
            Console.WriteLine("Enter name: ");
            //Read user input
            name = Console.ReadLine();

            //if the name is mark
            if (name.ToLower() == "mark")
            {
                messages[0].Print();
            }
            //if the name is fred
            else if (name.ToLower() == "fred")
            {
                messages[1].Print();
            }
            //if the name is jai
            else if(name.ToLower() == "jai")
            {
                messages[2].Print();
            }
            //if the name is kent (my english name)
            else if(name.ToLower() == "kent")
            {
                messages[3].Print();
            }
            //if they type in other names or leave it blank
            else
            {
                messages[4].Print();
            }
        }
    }
}
