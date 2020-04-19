using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LudoGameEngine.Tests
{
    public class GameBoardTests
    {
        [Fact]
        public void AddPiecesWithPlayer_TwoPlayers_AllPiecesAreAtPosition()
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer();
            LudoPlayer lp2 = new LudoPlayer();
            GameBoard sut = new GameBoard();

            // Act
            sut.AddPiecesWithPlayer(lp1);
            sut.AddPiecesWithPlayer(lp2);

            // Assert
            Assert.Equal(-1, sut.Pieces[0].TileId);
            Assert.Equal(-2, sut.Pieces[1].TileId);
            Assert.Equal(-3, sut.Pieces[2].TileId);
            Assert.Equal(-4, sut.Pieces[3].TileId);
            Assert.Equal(-1, sut.Pieces[4].TileId);
            Assert.Equal(-2, sut.Pieces[5].TileId);
            Assert.Equal(-3, sut.Pieces[6].TileId);
            Assert.Equal(-4, sut.Pieces[7].TileId);
        }
    }
}