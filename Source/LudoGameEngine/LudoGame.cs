using System;
using System.Collections.Generic;

namespace LudoGameEngine
{
    public class LudoGame
    {
        public Guid GameGuid { get; set; }
        private GameBoard gameBoard;

        public LudoPlayer StartGame(params LudoPlayer[] ludoplayers)
        {
            if (ludoplayers.Length <= 1 || ludoplayers.Length > 4)
            {
                throw new Exception("Unsupport number of players");
            }

            GameGuid = Guid.NewGuid();
            gameBoard = new GameBoard();
            
            
            foreach (var player in ludoplayers)
            {
                gameBoard.AddPiecesWithPlayer(player);
            }

            return ludoplayers[0];
        }


    }
}