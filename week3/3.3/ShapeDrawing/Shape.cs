using SplashKitSDK;

namespace ShapeDrawing
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        public Shape()
        {
            Color = Color.Green; // Setting initial color
            Width = Height = 100; // Setting shape dimensions
        }

        public Color Color
        {
            get 
            { 
                return _color; 
            }
            set 
            { 
                _color = value; 
            }
        }

        public float X
        {
            get 
            { 
                return _x; 
            }
            set 
            { 
                _x = value; 
            }
        }

        public float Y
        {
            get 
            { 
                return _y; 
            }
            set 
            { 
                _y = value; 
            }
        }

        public int Width
        {
            get
            { 
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, X, Y, Width, Height);
        }

        public bool IsAt(Point2D p)
        {
            return SplashKit.PointInRectangle(p, SplashKit.RectangleFrom(X, Y, Width, Height));
        }

        public bool Selected
        {
            get 
            { 
                return _selected;
            }
            set 
            { 
                _selected = value; 
            }
        }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }
    }
}
