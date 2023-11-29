using System;
namespace SwinAdventure
{
    public class Paths : GameObject
    {
        bool _lockablePath;
        Location _start, _end;

        public Paths(string[] idents, string name, string desc, Location start, Location end) : base(idents, name, desc)
        {
            _start = start;
            _end = end;
            _lockablePath = false;

            AddIdentifier("path");
            foreach (string s in name.Split(" "))
            {
                AddIdentifier(s);
            }
        }

        public Location Start
        {
            get
            {
                return _start;
            }
        }

        public Location End
        {
            get 
            { 
                return _end; 
            }
        }

        public override string FullDescription
        {
            get 
            {
                return Name; 
            }
        }

        public bool LockablePath
        {
            get 
            { 
                return _lockablePath; 
            }
            set 
            {
                _lockablePath = value; 
            }
        }
    }
}

