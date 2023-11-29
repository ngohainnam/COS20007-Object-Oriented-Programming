using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawing
{
    public class MyLine : Shape
    {
        private int _length;

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        public MyLine() : this(Color.Orange,100)
        {
        }

        public MyLine(Color clr, int length) : base(clr)
        {
            Length = length;
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, X + Length, Y);
        }

        public override void DrawOutline()
        {
            // Draw a small circle at the beginning of the line
            int circleRadius = 3;
            SplashKit.FillCircle(Color.Black, X, Y, circleRadius);
            SplashKit.FillCircle(Color.Black, X + Length, Y, circleRadius);
        }

        public override bool IsAt(Point2D p)
        {
            return SplashKit.PointOnLine(p, SplashKit.LineFrom(X, Y, X + Length, Y));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(Length);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Length = reader.ReadInteger();
        }
    }
}

