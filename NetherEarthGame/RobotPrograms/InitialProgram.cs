using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetherEarthGame
{
    internal class InitialProgram : IRobotProgram
    {
        private int stepCount = 6;

        public void Move(Robot robot)
        {
            if (stepCount > 0)
                if (!robot.Scaner.ScanPath(Direction.DownDirection, 2, robot)) stepCount = 0;

            if (stepCount > 0 && stepCount < 6)
            {
                int x = robot.X;
                int y = robot.Y + 2;
                robot.SetPosition(x, y);
            }
            
            if(stepCount > 0) stepCount--;
        }
    }
}
