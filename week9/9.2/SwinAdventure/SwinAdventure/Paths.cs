namespace SwinAdventure
{
    public class Paths : GameObject
    {
        bool _lockablePath;
        Location _end;

        public Paths(string[] idents, string name, string desc, Location end) : base(idents, name, desc)
        {
            _end = end;
            _lockablePath = false;

            AddIdentifier("path");
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
