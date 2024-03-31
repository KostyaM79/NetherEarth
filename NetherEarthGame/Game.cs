using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetherEarthGame
{
    public class Game
    {
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

        }

        public void LoadObjects()
        {
            GameObjectFactory gameObjectFactory = new GameObjectFactory();
            gameObjectFactory.CreateObject(gameObjects);
        }

        public void CreateRobot()
        {
            robots.Add(new Robot(20, 16));
        }
    }
}
