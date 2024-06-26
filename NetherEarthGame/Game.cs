﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetherEarthGame
{
    public class Game
    {
        public event GameUpdatedEventHandler GameUpdated;

        private List<GameObject> gameObjects = new List<GameObject>();
        private int squareSide = 8;
        private List<Robot> robots = new List<Robot>();

        public void AddGameObject(GameObject gameObject) => gameObjects.Add(gameObject);

        public List<GameObject> GameObjects => gameObjects;

        public List<Robot> Robots => robots;

        public int SquareSide => squareSide;

        public int Height => 32 * squareSide;

        public void GameUpdate()
        {
            foreach (Robot r in robots)
            {
                IRobotProgram program = r.Program;
                program.Move(r);
                GameUpdated(this);
            }
        }

        public void LoadObjects()
        {
            GameObjectFactory gameObjectFactory = new GameObjectFactory();
            gameObjectFactory.CreateObject(gameObjects);
        }

        public void CreateRobot()
        {
            Robot r = new Robot(20, 16) { Program = new InitialProgram(), Game = this };
            robots.Add(r);
        }

        public void Start()
        {
            GameObjectFactory gameObjectFactory = new GameObjectFactory();
            gameObjectFactory.CreateObject(gameObjects);
            GameUpdated(this);
        }
    }
}
