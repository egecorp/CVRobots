using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class ConsoleParser
    {

        private ConsoleState currentState;

        private Grid currentGrid;

        private Robot currentRobot;

        /// <summary>
        /// This command is out of tasks conditions, but precense of that is convinient to testing
        /// </summary>
        private const string REPEATE_COMMAND = "C";

        public ConsoleParser()
        {
            Clear();
        }

        /// <summary>
        /// Parse current string
        /// </summary>
        /// <param name="inputString">string from input stream</param>
        /// <returns>Return true, if it needs to keep on inputing</returns>
        public bool Input(string inputString)
        {
            inputString = (inputString ?? "").Trim();

            if (inputString == "")
            {
                if (currentState == ConsoleState.RobotInitialization) return false;
                return true;
            }

            if (inputString == REPEATE_COMMAND)
            {
                Clear();
                return true;
            }

            switch (currentState)
            {
                case ConsoleState.GridSize:
                    ParseGridSize(inputString);
                    currentState = ConsoleState.RobotInitialization;
                    System.Console.WriteLine("Input robot's position and orientation");
                    return true;
                case ConsoleState.RobotInitialization:
                    ParseRobotInitialization(inputString);
                    currentState = ConsoleState.RobotCommands;
                    System.Console.WriteLine("Input command");
                    return true;
                default:
                    ParseRobotCommand(inputString);
                    currentState = ConsoleState.RobotInitialization;
                    System.Console.WriteLine("Input robot's position and orientation");
                    return true;

            }

        }

        public void Clear()
        {
            currentState = ConsoleState.GridSize;

            currentGrid = null;

            currentRobot = null;

            System.Console.WriteLine("Input size of grid");
        }

        private void ParseGridSize(string inputString)
        {
            string[] parts = inputString.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new Exception("Incorrect input format");
            }
            int w = int.Parse(parts[0]);
            int h = int.Parse(parts[1]);

            if ((w < Grid.MIN_X) || (w > Grid.MAX_X) || (h < Grid.MIN_Y) || (h > Grid.MAX_Y))
            {
                throw new Exception("Incorrect input format");
            }

            currentGrid = new Grid(w, h);
        }


        private void ParseRobotInitialization(string inputString)
        {
            string[] parts = inputString.Split(new char[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                throw new Exception("Incorrect input format");
            }
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);

            Orientation o;
            switch (parts[2])
            {
                case "N":
                    o = Orientation.N;
                    break;
                case "W":
                    o = Orientation.W;
                    break;
                case "E":
                    o = Orientation.E;
                    break;
                case "S":
                    o = Orientation.S;
                    break;
                default:
                throw new Exception("Incorrect input format");
            }

            currentRobot = new Robot(x, y, o);
        }


        private void ParseRobotCommand(string inputString)
        {
            CommandSet currentCommandSet = new CommandSet(inputString);
            currentRobot.Go(currentCommandSet.CommandList, currentGrid);
            Console.WriteLine(currentRobot.GetResultString());
        }
    }
}
