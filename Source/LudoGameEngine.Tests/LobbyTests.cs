using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LudoGameEngine.Tests
{
    public class LobbyTests
    {
        /*
            As a ludo-player I want to decide how many player should be in a new game when creating a new game
            As a ludo-player I want to set my name and color when joining a new game
             As a ludo-player, I want to be able to load an unfinished game, to continue playing that game.
            As a ludo-player, I want to be able look at game-history, to see past games.
            */

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
            Assert.Equal(0, sut.Pieces[0].TileId);
            Assert.Equal(1, sut.Pieces[1].TileId);
            Assert.Equal(2, sut.Pieces[2].TileId);
            Assert.Equal(3, sut.Pieces[3].TileId);
            Assert.Equal(57, sut.Pieces[4].TileId);
            Assert.Equal(58, sut.Pieces[5].TileId);
            Assert.Equal(59, sut.Pieces[6].TileId);
            Assert.Equal(60, sut.Pieces[7].TileId);

        }

        [Fact]
        public void StartGame_StartsLudoGameWithTwoPlayer_CurrentPlayerIsPlayer1()
        {
            // Arrangea
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
    }
}
