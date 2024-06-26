﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetherEarthGame
{
    public class Robot : GameObject
    {
        private int helth = 100;
        private Scaner scaner = new Scaner();
        private Gun gun;
        private Rocket rocket;
        private Phazor phazor;
        private Chassis chassis;
        private Electronics electronics;

        public Robot() { }

        public Robot(int x, int y)
        {
            SetPosition(x, y);
            CreatePoints();
        }

        internal IRobotProgram Program { get; set; }

        public Game Game { get; set; }

        internal Scaner Scaner => scaner;

        private void CreatePoints()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Points.Add(new Point(j, i));
                }
            }
        }
    }
}
