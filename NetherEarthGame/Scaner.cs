using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetherEarthGame
{
    internal class Scaner
    {
        internal bool ScanPath(Direction direction, int length, Robot robot)
        {
            List<GameObject> allObjects = (robot.Game.GameObjects.Union(robot.Game.Robots)).ToList();
            allObjects.Remove(robot);

            foreach (GameObject o in allObjects)
            {
                switch (direction)
                {
                    case Direction.RightDirection: return ScanToRight(o, length, robot);

                    case Direction.DownDirection:
                        bool b = ScanToDown(o, length, robot);
                        if(!b) return b;
                        break;
                }
            }

            return true;
        }

        private bool ScanToRight(GameObject gameObject, int length, Robot robot)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < length; i++)
                {
                    if (gameObject.Contains(robot.X + 4 + i, robot.Y + j)) return false;
                }
            }

            return true;
        }

        private bool ScanToDown(GameObject gameObject, int length, Robot robot)
        {
            bool isMoveble = true;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < length; i++)
                {
                    if (gameObject.Contains(robot.X + j, robot.Y + 4 + i)) isMoveble = false;
                }
            }

            return isMoveble;
        }
    }
}
