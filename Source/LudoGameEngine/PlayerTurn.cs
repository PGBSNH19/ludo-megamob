using System;
using System.Collections.Generic;
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
            List<Piece> aviablePiecesInHome = new List<Piece>();
            if (diceValue == 1 || diceValue == 6)
            {
                aviablePiecesInHome = gameboard.Pieces.Where(p => p.Player == player && p.TileId < 0).ToList();
            }

            int numberOfPieceOnBoard = gameboard.Pieces.Count(p => p.TileId >= 0 && p.Player == player);
            if (numberOfPieceOnBoard == 0 && aviablePiecesInHome.Count == 0)
            {
                // Nothing to move
                return new Piece[] { };
            }

            List<Piece> aviablePiecesOnBoard = gameboard.Pieces.Where(p => p.Player == player && p.TileId >= 0 && IsMoveAllowed(p.TileId, diceValue)).ToList();
            List<Piece> piecesWhichCanBeMoved = new List<Piece>();
            piecesWhichCanBeMoved.AddRange(aviablePiecesOnBoard);
            piecesWhichCanBeMoved.AddRange(aviablePiecesInHome);
            return piecesWhichCanBeMoved.ToArray();
        }

        private bool IsMoveAllowed(int position, int numberOfMoves)
        {
            var numberOfPiecesOnNewPosition = gameboard.Pieces.Count(p => p.TileId == position + numberOfMoves && p.Player == player);
            return numberOfPiecesOnNewPosition == 0;
        }
    }
}