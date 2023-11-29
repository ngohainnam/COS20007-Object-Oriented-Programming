using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyCircle : Shape
    {
        private int _radius;

        public int Radius
        {
            get 
            { 
                return _radius; 
            }
            set 
            {
                _radius = value; 
            }
        }

        public MyCircle() : this(Color.Blue,0,0,50)
        {
        }

        public MyCircle(Color clr, float x, float y, int radius) : base(clr)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X , Y, _radius + 2);
        }

        public override bool IsAt(Point2D p)
        {
            return SplashKit.PointInCircle(p, SplashKit.CircleAt(X, Y, _radius));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
