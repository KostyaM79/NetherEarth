using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetherEarthGame
{
    public abstract class GameObject
    {
        private List<Point> points = new List<Point>();
        private Point position;


        public void AddPoint(Point point) => points.Add(point);

        public void AddPoint(int x, int y) => points.Add(new Point(x, y));

        public List<Point> Points => points;

        public void SetPosition(int x, int y) => position = new Point(x, y);

        public int X => position.X;

        public int Y => position.Y;
    }
}
