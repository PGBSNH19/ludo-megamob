using System;
using System.Collections.Generic;

namespace LudoGameEngine
{
    public class LudoGame
    {
        public Guid GameGuid { get; set; }

        private const int NUMBER_OF_TILES_ON_BOARD = 57;

        public List<Piece> Pieces { get; set; }

        public LudoPlayer StartGame(params LudoPlayer[] ludoplayers)
        {
            if (ludoplayers.Length <= 1 || ludoplayers.Length > 4)
            {
                throw new Exception("Unsupport number of players");
            }

            GameGuid = Guid.NewGuid();
            Pieces = new List<Piece>();
            int startTile = 0;
            foreach (var player in ludoplayers)
            {
                AddPiecesWithPlayer(player, startTile);
                startTile += NUMBER_OF_TILES_ON_BOARD;
            }

            return ludoplayers[0];
        }

        private void AddPiecesWithPlayer(LudoPlayer player, int startTile)
        {
            for(int i = 0; i < 4; i++)
            {
                Pieces.Add(new Piece() { 
                    TileId = startTile + i, 
                    Player = player 
                });
            }
        }
    }
}