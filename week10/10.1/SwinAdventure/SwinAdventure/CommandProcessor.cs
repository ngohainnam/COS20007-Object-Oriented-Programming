using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class CommandProcessor : Command
    {
        List<Command> _commands;

        public CommandProcessor() : base(new string[] { "command" })
        {
            _commands = new List<Command>();
            _commands.Add(new LookCommand());
            _commands.Add(new MoveCommand());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command command in _commands)
            {
                if (command.AreYou(text[0].ToLower()))
                {
                    return command.Execute(p, text);
                }
            }
            return "There is no command like that.";
        }
    }
}

