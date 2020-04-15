using System;
using System.Collections.Generic;
using System.Text;

namespace LudoGameEngine
{
    public class GameInteraction
    {
        private IGameIOController ioController;
        public GameInteraction(IGameIOController ioController)
        {
            this.ioController = ioController;
        }

        public int StartInteractiveLudoGame()
        {
            ioController.ShowMessage("Welcome to Ludo game");
            ioController.ShowMessage("[0] Start a new game");
            ioController.ShowMessage("[1] Load a game");
            ioController.ShowMessage("[2] Show history");
            return ioController.GetIntFromMessage("Choose a option:");

            
        }

        private LudoGame game;

        public void ChooseMenuOption()
        {
            int numberOfPlayers = ioController.GetIntFromMessage("How many players [2-4]:");
            List<LudoPlayer> players = new List<LudoPlayer>();
            for(int  i = 0; i < numberOfPlayers; i++)
            {
                ioController.ShowMessage($"Player {i}:");
                var player = new LudoPlayer();
                player.Index = i;
                player.PlayerName = ioController.GetStringFromMessage($"What is the name of Player {i}:");
                player.Color = ioController.GetStringFromMessage($"What color is player {i}:");
                players.Add(player);
            }

            game = new LudoGame();
            game.StartGame(players.ToArray());
            ioController.ShowMessage($"Your new game have ID: {game.GameGuid}");
        }
    }
}
