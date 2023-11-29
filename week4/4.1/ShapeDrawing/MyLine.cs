using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeDrawing;
using SplashKitSDK;

namespace DrawingShape
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        private int _length;

        public float EndX
        {
            get
            {
                return _endX;
            }
            set
            {
                _endX = value;
            }
        }

        public float EndY
        {
            get
            {
                return _endY;
            }
            set
            {
                _endY = value;
            }
        }

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
        public MyLine() : this(Color.Orange, 0, 0, 100)
        {
        }

        public MyLine(Color clr, float x, float y, int length) : base(clr)
        {
            X = x;
            Y = y;
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
    }
}

