using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NetherEarthGame;

namespace NetherEarth
{
    public class GameRunner
    {
        private Game game;
        private Timer timer = new Timer(250);

        public event GameUpdatedEventHandler GameUpdated;

        public GameRunner(Game game)
        {
            this.game = game;
        }

        public void Start()
        {
            game.LoadObjects();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public Game Game => game;

        public void CreateRobot() => game.CreateRobot();

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            game.GameUpdate();
            GameUpdated(game);
        }
    }
}
