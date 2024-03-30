using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetherEarthGame
{
    public class GameObjectFactory
    {
        public void CreateObject(Game game)
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
                    case "fance": game.AddGameObject(CreateFance(gameObjectsXml.DocumentElement["fance"], blocksXml, position)); break;
                    case "fullBodiedBlock": game.AddGameObject(CreateBlock(gameObjectsXml.DocumentElement["fullBodiedBlock"], blocksXml, position)); break;
                    case "base": game.AddGameObject(CreateBase(gameObjectsXml.DocumentElement["base"], blocksXml, position)); break;
                    case "followBlock": game.AddGameObject(CreateFollowBlock(gameObjectsXml.DocumentElement["followBlock"], blocksXml, position)); break;
                    case "factory": game.AddGameObject(CreateFactory(gameObjectsXml.DocumentElement["factory"], blocksXml, position)); break;
                    case "horizontalDoubleBlock": game.AddGameObject(CreateHorizontalDoubleBlock(gameObjectsXml.DocumentElement["horizontalDoubleBlock"], blocksXml, position)); break;
                    case "horizontalDoubleFollowBlock": game.AddGameObject(CreateHorizontalDoubleFollowBlock(gameObjectsXml.DocumentElement["horizontalDoubleFollowBlock"], blocksXml, position)); break;
                    case "horizontalQuadrupleBlock": game.AddGameObject(CreateHorizontalQuadrupleBlock(gameObjectsXml.DocumentElement["horizontalQuadrupleBlock"], blocksXml, position)); break;
                    case "verticalQuadrupleBlock": game.AddGameObject(CreateVerticalQuadrupleBlock(gameObjectsXml.DocumentElement["verticalQuadrupleBlock"], blocksXml, position)); break;
                    case "verticalDoubleBlock": game.AddGameObject(CreateVerticalDoubleBlock(gameObjectsXml.DocumentElement["verticalDoubleBlock"], blocksXml, position)); break;
                }

            }
        }

        private Fance CreateFance(XmlElement fanceXml, XmlDocument blocksXml, Point position)
        {
            Fance fance = new Fance();
            fance.SetPosition(position.X, position.Y);
            CreatePoints(fanceXml, blocksXml, fance);
            return fance;
        }

        private Block CreateBlock(XmlElement blockXml, XmlDocument blocksXml, Point position)
        {
            Block block = new Block();
            block.SetPosition(position.X, position.Y);
            CreatePoints(blockXml, blocksXml, block);
            return block;
        }

        private Base CreateBase(XmlElement baseXml, XmlDocument blocksXml, Point position)
        {
            Base b = new Base();
            b.SetPosition(position.X, position.Y);
            CreatePoints(baseXml, blocksXml, b);
            return b;
        }

        private FollowBlock CreateFollowBlock(XmlElement followBlockXml, XmlDocument blocksXml, Point position)
        {
            FollowBlock followBlock = new FollowBlock();
            followBlock.SetPosition(position.X, position.Y);
            CreatePoints(followBlockXml, blocksXml, followBlock);
            return followBlock;
        }

        private Factory CreateFactory(XmlElement factoryXml, XmlDocument blocksXml, Point position)
        {
            Factory factory = new Factory();
            factory.SetPosition(position.X, position.Y);
            CreatePoints(factoryXml, blocksXml, factory);
            return factory;
        }

        private HorizontalDoubleBlock CreateHorizontalDoubleBlock(XmlElement element, XmlDocument blocksXml, Point position)
        {
            HorizontalDoubleBlock horizontalDoubleBlock = new HorizontalDoubleBlock();
            horizontalDoubleBlock.SetPosition(position.X, position.Y);
            CreatePoints(element, blocksXml, horizontalDoubleBlock);
            return horizontalDoubleBlock;
        }

        private HorizontalDoubleFollowBlock CreateHorizontalDoubleFollowBlock(XmlElement element, XmlDocument blocksXml, Point position)
        {
            HorizontalDoubleFollowBlock horizontalDoubleFollowBlock = new HorizontalDoubleFollowBlock();
            horizontalDoubleFollowBlock.SetPosition(position.X, position.Y);
            CreatePoints(element, blocksXml, horizontalDoubleFollowBlock);
            return horizontalDoubleFollowBlock;
        }

        private HorizontalQuadrupleBlock CreateHorizontalQuadrupleBlock(XmlElement element, XmlDocument blocksXml, Point position)
        {
            HorizontalQuadrupleBlock horizontalQuadrupleBlock = new HorizontalQuadrupleBlock();
            horizontalQuadrupleBlock.SetPosition(position.X, position.Y);
            CreatePoints(element, blocksXml, horizontalQuadrupleBlock);
            return horizontalQuadrupleBlock;
        }

        private VerticalQuadrupleBlock CreateVerticalQuadrupleBlock(XmlElement element, XmlDocument blocksXml, Point position)
        {
            VerticalQuadrupleBlock verticalQuadrupleBlock = new VerticalQuadrupleBlock();
            verticalQuadrupleBlock.SetPosition(position.X, position.Y);
            CreatePoints(element, blocksXml, verticalQuadrupleBlock);
            return verticalQuadrupleBlock;
        }

        private VerticalDoubleBlock CreateVerticalDoubleBlock(XmlElement element, XmlDocument blocksXml, Point position)
        {
            VerticalDoubleBlock verticalDoubleBlock = new VerticalDoubleBlock();
            verticalDoubleBlock.SetPosition(position.X, position.Y);
            CreatePoints(element, blocksXml, verticalDoubleBlock);
            return verticalDoubleBlock;
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
