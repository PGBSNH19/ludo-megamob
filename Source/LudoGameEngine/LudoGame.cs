using System;
using System.Collections.Generic;

namespace LudoGameEngine
{
    public class LudoGame
    {
        public Guid GameGuid { get; set; }
        private int currentPlayerIndex = 0;
        public LudoPlayer CurrentPlayer { get { return ludoplayers[currentPlayerIndex]; } }

        private GameBoard gameBoard;
        private LudoPlayer[] ludoplayers;

        public LudoPlayer StartGame(params LudoPlayer[] ludoplayers)
        {
            if (ludoplayers.Length <= 1 || ludoplayers.Length > 4)
            {
                throw new Exception("Unsupport number of players");
            }

            GameGuid = Guid.NewGuid();
            gameBoard = new GameBoard();
            this.ludoplayers = ludoplayers;

            foreach (var player in ludoplayers)
            {
                gameBoard.AddPiecesWithPlayer(player);
            }

            return CurrentPlayer;
        }


    }
}