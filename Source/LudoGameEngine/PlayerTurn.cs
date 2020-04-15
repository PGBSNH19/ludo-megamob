using System;
using System.Linq;

namespace LudoGameEngine
{
    public class PlayerTurn
    {
        private LudoPlayer player;
        private GameBoard gameboard;
        public PlayerTurn(LudoPlayer player, GameBoard gameboard)
        {
            this.player = player;
            this.gameboard = gameboard;
        }

        public Piece[] GetAvaiablePieces(int diceValue)
        {
            if (diceValue == 1 || diceValue == 6)
            {
                return gameboard.Pieces.Where(p => p.Player == player && p.TileId < 0).ToArray();
            }
            int numberOfPieceOnBoard = gameboard.Tiles.Count(t => t != null && t.Piece.Player == player);
            if (numberOfPieceOnBoard == 0)
            {
                // Nothing to move
                return new Piece[] { };
            }
            return null;
        }
    }
}