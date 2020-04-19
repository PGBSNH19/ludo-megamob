using System;
using System.Collections.Generic;
using System.Text;

namespace LudoGameEngine
{
    public class GameInteraction
    {
        private IGameIOController ioController;

        // Dessa tre var scopade och game var privat så jag kunde inte komma åt
        // dom i testerna´ändrade så att dom kunde vara publica.
        public List<LudoPlayer> players = new List<LudoPlayer>();

        public LudoPlayer player = new LudoPlayer();
        public LudoGame game = new LudoGame();

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

        public void ChooseMenuOption()
        {
            int numberOfPlayers = ioController.GetIntFromMessage("How many players [2-4]:");
            for (int i = 0; i < numberOfPlayers; i++)
            {
                ioController.ShowMessage($"Player {i}:");
                player.Index = i;
                player.PlayerName = ioController.GetStringFromMessage($"What is the name of Player {i}:");
                player.Color = ioController.GetStringFromMessage($"What color is player {i}:");
                players.Add(player);
            }

            game.StartGame(players.ToArray());
            ioController.ShowMessage($"Your new game have ID: {game.GameGuid}");
        }

        public void ShowGameHistory()
        {
            ioController.ShowMessage($"Showing your game history from with ID: {game.GameGuid}");
        }
    }
}