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

        public void AddGameObject(GameObject gameObject) => gameObjects.Add(gameObject);

        public List<GameObject> GameObjects => gameObjects;
    }
}
