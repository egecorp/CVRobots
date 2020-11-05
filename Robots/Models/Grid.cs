using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Grid
    {

        public const int MIN_X = 0;

        public const int MIN_Y = 0;

        public const int MAX_X = 50;

        public const int MAX_Y = 50;


        private int Width;

        private int Height;

        private List<Point?> ScentPoints;

        public Grid(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            ScentPoints = new List<Point?>();
        }

        /// <summary>
        /// Can robot do one step  
        /// </summary>
        /// <param name="currentPoint">Current point</param>
        /// <param name="o">Orientation</param>
        /// <returns>True, if robot can do step</returns>
        public bool IsMovingAccept(Point currentPoint, Orientation o)
        {
            Point nextPoint = GetNextPoint(currentPoint, o);

            // If new position is inside grid, all good, return true
            if (CheckInside(nextPoint)) return true;

            // If ScentPoints doesn't containts mark "Scent" in the old position, return true
            return !ScentPoints.Find(sp => sp.Equals(currentPoint)).HasValue;
        }

        /// <summary>
        /// Do one step by robot
        /// </summary>
        /// <param name="currentPoint">Current point</param>
        /// <param name="o">Orientation</param>
        /// <returns>True, if robot remains inside of grid</returns>
        public bool DoStep(ref Point currentPoint, Orientation o)
        {
            // If this point has scent and robot tries to move off, return true without moving
            if (!IsMovingAccept(currentPoint, o)) return true;

            Point nextPoint = GetNextPoint(currentPoint, o);
            
            // If next point is out of grid, add scent and return false
            if (!CheckInside(nextPoint))
            {
                ScentPoints.Add(currentPoint);
                return false;
            }

            currentPoint = nextPoint;
            return true;
        }


        private Point GetNextPoint(Point p, Orientation o)
        {
            int x = p.X;
            int y = p.Y;

            switch (o)
            {
                case Orientation.E:
                    return new Point(x + 1, y);
                case Orientation.S:
                    return new Point(x, y - 1);
                case Orientation.W:
                    return new Point(x - 1, y);
                default:
                    return new Point(x, y + 1);
            }
        }

        private bool CheckInside(Point p)
        {
            return ((p.X >= Grid.MIN_X) && (p.X <= this.Width) && (p.Y >= Grid.MIN_Y) && (p.Y <= this.Height));
        }
    }
}
