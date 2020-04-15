
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LudoGameEngine.Tests
{
    public class GameTests
    {


        [Fact]
        public void StartGame_StartsLudoGameWithOnePlayer_Exception()
        {
            // Arrange
            LudoPlayer lp = new LudoPlayer();
            LudoGame sut = new LudoGame();

            // Act + Assert
            Assert.Throws<Exception>(() => sut.StartGame(lp));

        }

        [Fact]
        public void StartGame_StartsLudoGameWithFivePlayers_Exception()
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer();
            LudoPlayer lp2 = new LudoPlayer();
            LudoPlayer lp3 = new LudoPlayer();
            LudoPlayer lp4 = new LudoPlayer();
            LudoPlayer lp5 = new LudoPlayer();
            LudoGame sut = new LudoGame();

            // Act + Assert
            Assert.Throws<Exception>(() => sut.StartGame(lp1, lp2, lp3, lp4, lp5));

        }



        [Fact]
        public void StartGame_StartsLudoGameWithNoPlayers_Exception()
        {
            // Arrange
            LudoGame sut = new LudoGame();

            // Act + Assert
            Assert.Throws<Exception>(() => sut.StartGame());

        }



        [Fact]
        public void StartGame_StartsLudoGameWithTwoPlayer_CurrentPlayerIsPlayer1()
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer("player1");
            LudoPlayer lp2 = new LudoPlayer("player2");
            LudoGame sut = new LudoGame();

            // Act
            var currentPlayer = sut.StartGame(lp1, lp2);

            // Assert
            Assert.Equal("player1", currentPlayer.PlayerName);
        }

        [Fact]
        public void StartGame_StartsLudoGameWithTwoPlayer_GameGuidWhichIsNotEmptyGuid()
        {
            // Arrangea
            LudoPlayer lp1 = new LudoPlayer("player1");
            LudoPlayer lp2 = new LudoPlayer("player2");
            LudoGame sut = new LudoGame();

            // Act
            sut.StartGame(lp1, lp2);

            // Assert
            Assert.NotEqual(Guid.Empty, sut.GameGuid);
        }


        [Fact]
        public void StartGame_StartsLudoGameWithFourPlayers_GameGuidWhichIsNotEmptyGuid()
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer();
            LudoPlayer lp2 = new LudoPlayer();
            LudoPlayer lp3 = new LudoPlayer();
            LudoPlayer lp4 = new LudoPlayer();
            LudoGame sut = new LudoGame();

            // Act 
            sut.StartGame(lp1, lp2, lp3, lp4);

            // Assert
            Assert.NotEqual(Guid.Empty, sut.GameGuid);

        }

        [Fact]
        public void CurrentPlayer_StartsLudoGameWithTwoPlayers_CurrentPlayerIsPlayer1()
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer("player1");
            LudoPlayer lp2 = new LudoPlayer("player2");
            LudoGame sut = new LudoGame();

            // Act
            sut.StartGame(lp1, lp2);

            // Assert
            Assert.Equal("player1", sut.CurrentPlayer.PlayerName);

        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(5, 0)]
        [InlineData(6, 4)]
        public void GetAvaiablePieces_PlayerIsInHome_NumberOfPiecesWhichCanBeMovedOutOfHome(int diceRollValue, int expectedAvaiablePieces)
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer("player1");
            GameBoard gb = new GameBoard();
            gb.AddPiecesWithPlayer(lp1);
            var sut = new PlayerTurn(lp1, gb);

            // Act
            Piece[] pieces = sut.GetAvaiablePieces(diceRollValue);

            // Assert
            Assert.Equal(expectedAvaiablePieces, pieces.Length);
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 4)]
        public void GetAvaiablePieces_PlayerHaveOnePieceInBoardRestInHome_NumberOfPiecesWhichCanBeMoved(int diceRollValue, int expectedAvaiablePieces)
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer("player1");
            GameBoard gb = new GameBoard();
            gb.AddPiecesWithPlayer(lp1);
            gb.Pieces[0].TileId = 0;
            var sut = new PlayerTurn(lp1, gb);

            // Act
            Piece[] pieces = sut.GetAvaiablePieces(diceRollValue);

            // Assert
            Assert.Equal(expectedAvaiablePieces, pieces.Length);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        [InlineData(5, 4)]
        [InlineData(6, 4)]
        public void GetAvaiablePieces_PlayerHaveAllPiecesOnBoard_NumberOfPiecesWhichCanBeMoved(int diceRollValue, int expectedAvaiablePieces)
        {
            // Arrange
            LudoPlayer lp1 = new LudoPlayer("player1");
            GameBoard gb = new GameBoard();
            gb.AddPiecesWithPlayer(lp1);
            gb.Pieces[0].TileId = 0;
            gb.Pieces[1].TileId = 1;
            gb.Pieces[2].TileId = 2;
            gb.Pieces[3].TileId = 3;
            var sut = new PlayerTurn(lp1, gb);

            // Act
            Piece[] pieces = sut.GetAvaiablePieces(diceRollValue);

            // Assert
            Assert.Equal(expectedAvaiablePieces, pieces.Length);
        }
    }
}
