
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
