using System.Collections.Generic;

namespace LudoGameEngine
{
    public class GameBoard
    {
        private const int NUMBER_OF_TILES_ON_BOARD = 57;
        private int lastPlayerStartTile = 0;

        public int NumberOfTilesOnboard { get { return NUMBER_OF_TILES_ON_BOARD; } }

        public GameBoard()
        {
            Pieces = new List<Piece>();
        }

        public List<Piece> Pieces { get; set; }

        public void AddPiecesWithPlayer(LudoPlayer player)
        {
            for (int i = 1; i <= 4; i++)
            {
                Pieces.Add(new Piece()
                {
                    TileId = i * -1,
                    Player = player
                });
            }
            lastPlayerStartTile = +NUMBER_OF_TILES_ON_BOARD;
        }
    }
}