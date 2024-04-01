using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetherEarthGame
{
    internal class GameObjectFactory
    {
        internal void CreateObject(List<GameObject>gameObjects)
        {
            XmlDocument blocksXml = new XmlDocument();
            XmlDocument gameObjectsXml = new XmlDocument();
            XmlDocument gameMapXml = new XmlDocument();

            blocksXml.Load(@"..\..\..\NetherEarthGame\xml\blocks.xml");
            gameObjectsXml.Load(@"..\..\..\NetherEarthGame\xml\game-objects.xml");
            gameMapXml.Load(@"..\..\..\NetherEarthGame\xml\game-map.xml");


            foreach (XmlElement objectXml in gameMapXml.DocumentElement.ChildNodes)
            {
                Point position = new Point(int.Parse(objectXml.Attributes["x"].Value), int.Parse(objectXml.Attributes["y"].Value));

                switch (objectXml.Attributes["name"].Value)
                {
                    case "fance": gameObjects.Add(CreateObject<Fance>(gameObjectsXml.DocumentElement["fance"], blocksXml, position)); break;
                    case "fullBodiedBlock": gameObjects.Add(CreateObject<Block>(gameObjectsXml.DocumentElement["fullBodiedBlock"], blocksXml, position)); break;
                    case "base": gameObjects.Add(CreateObject<Base>(gameObjectsXml.DocumentElement["base"], blocksXml, position)); break;
                    case "followBlock": gameObjects.Add(CreateObject<FollowBlock>(gameObjectsXml.DocumentElement["followBlock"], blocksXml, position)); break;
                    case "factory": gameObjects.Add(CreateObject<Factory>(gameObjectsXml.DocumentElement["factory"], blocksXml, position)); break;
                    case "horizontalDoubleBlock": gameObjects.Add(CreateObject<HorizontalDoubleBlock>(gameObjectsXml.DocumentElement["horizontalDoubleBlock"], blocksXml, position)); break;
                    case "horizontalDoubleFollowBlock": gameObjects.Add(CreateObject<HorizontalDoubleFollowBlock>(gameObjectsXml.DocumentElement["horizontalDoubleFollowBlock"], blocksXml, position)); break;
                    case "horizontalQuadrupleBlock": gameObjects.Add(CreateObject<HorizontalQuadrupleBlock>(gameObjectsXml.DocumentElement["horizontalQuadrupleBlock"], blocksXml, position)); break;
                    case "verticalQuadrupleBlock": gameObjects.Add(CreateObject<VerticalQuadrupleBlock>(gameObjectsXml.DocumentElement["verticalQuadrupleBlock"], blocksXml, position)); break;
                    case "verticalDoubleBlock": gameObjects.Add(CreateObject<VerticalDoubleBlock>(gameObjectsXml.DocumentElement["verticalDoubleBlock"], blocksXml, position)); break;
                    case "horizontalQuadrupleFollowBlock": gameObjects.Add(CreateObject<HorizontalQuadrupleFollowBlock>(gameObjectsXml.DocumentElement["horizontalQuadrupleFollowBlock"], blocksXml, position)); break;
                    case "diagonalTripleBlock": gameObjects.Add(CreateObject<DiagonalTripleBlock>(gameObjectsXml.DocumentElement["diagonalTripleBlock"], blocksXml, position)); break;
                    case "verticalDoubleFollowBlock": gameObjects.Add(CreateObject<VerticalDoubleFollowBlock>(gameObjectsXml.DocumentElement["verticalDoubleFollowBlock"], blocksXml, position)); break;
                    case "hTripleFullCenterBlock": gameObjects.Add(CreateObject<HTripleFullCenterBlock>(gameObjectsXml.DocumentElement["hTripleFullCenterBlock"], blocksXml, position)); break;
                }

            }
        }


        private T CreateObject<T>(XmlElement element, XmlDocument blocksXml, Point position) where T:GameObject, new()
        {
            T block = new T();
            block.SetPosition(position.X, position.Y);
            CreatePoints(element, blocksXml, block);
            return block;
        }

        private void CreatePoints(XmlElement element, XmlDocument blocksXml, GameObject gameObject)
        {
            foreach (XmlElement blockXml in element.ChildNodes)
            {
                XmlElement block = blocksXml.DocumentElement[blockXml.Attributes["name"].Value];

                int x = int.Parse(blockXml.Attributes["x"].Value);
                int y = int.Parse(blockXml.Attributes["y"].Value);

                foreach (XmlElement pointXml in block.ChildNodes)
                {
                    int pointX = int.Parse(pointXml.Attributes["x"].Value);
                    int pointY = int.Parse(pointXml.Attributes["y"].Value);
                    gameObject.AddPoint(x + pointX, y + pointY);
                }
            }
        }
    }
}
