using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Robot
    {

        private Point currentPosition;

        private Orientation currentOrientation;

        private bool IsLost;

        public Robot(int x, int y, Orientation o)
        {
            currentPosition = new Point(x, y);
            currentOrientation = o;
            IsLost = false;
        }

        public string GetResultString()
        {
            string res = currentPosition.X.ToString() + " " + currentPosition.Y.ToString() + " ";
            switch (currentOrientation)
            {
                case Orientation.E:
                    res += "E";
                    break;
                case Orientation.N:
                    res += "N";
                    break;
                case Orientation.S:
                    res += "S";
                    break;
                default:
                    res += "W";
                    break;
            }

            if (IsLost) res += " LOST";
            return res;
        }

        private void TurnLeft()
        {
            switch (currentOrientation)
            {
                case Orientation.E:
                    currentOrientation = Orientation.N;
                    return;
                case Orientation.N:
                    currentOrientation = Orientation.W;
                    return;
                case Orientation.S:
                    currentOrientation = Orientation.E;
                    return;
                default:
                    currentOrientation = Orientation.S;
                    return;
            }
        }

        private void TurnRight()
        {
            switch (currentOrientation)
            {
                case Orientation.W:
                    currentOrientation = Orientation.N;
                    return;
                case Orientation.S:
                    currentOrientation = Orientation.W;
                    return;
                case Orientation.N:
                    currentOrientation = Orientation.E;
                    return;
                default:
                    currentOrientation = Orientation.S;
                    return;
            }
        }

        private void GoForward(Grid grid)
        {
            if (!grid.IsMovingAccept(currentPosition, currentOrientation)) return;

            if (!grid.DoStep(ref currentPosition, currentOrientation)) IsLost = true;
        }

        public void Go(IEnumerable<OneCommand> commands, Grid grid)
        {
            foreach (OneCommand c in commands)
            {
                switch (c)
                {
                    case OneCommand.L:
                        TurnLeft();
                        break;
                    case OneCommand.R:
                        TurnRight();
                        break;
                    case OneCommand.F:
                        GoForward(grid);
                        break;
                }
                if (IsLost) return;
            }
        }

    }
}
