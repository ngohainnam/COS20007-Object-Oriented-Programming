using SwinAdventure;
using System.IO;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string nextLocation;

            if (text.Length == 1 && IsMoveCommand(text[0].ToLower()))
            {
                return "Where do you want to go?";
            }
            else if (text.Length == 2 && IsMoveCommand(text[0].ToLower()))
            {
                nextLocation = text[1].ToLower();
            }
            else
            {
                return "I don't know where to go";
            }
            return MoveTo(nextLocation, p);
        }

        private bool IsMoveCommand(string command)
        {
            return command == "move" || command == "go" || command == "head" || command == "leave";
        }

        private string MoveTo(string newLocation, Player p)
        {
            Paths path = p.Location.FindPath(newLocation);

            if (path == null)
            {
                return $"Could not find the {newLocation}";
            }
            else
            {
                p.Move(path);
                return $"You have moved {path.FirstID} to the {p.Location.Name}...\n{p.Location.FullDescription}\n{p.Location.PathList}";
            }
        }

    }
}
