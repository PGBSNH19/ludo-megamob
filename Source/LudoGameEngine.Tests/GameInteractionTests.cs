using LudoGameEngine.Tests.TestDubbles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LudoGameEngine.Tests
{
    public class GameInteractionTests
    {



        [Fact]
        public void PlayerGetsWelcomeMessage()
        {
            //Arrange
            var gameIo = new ListIOController();
            GameInteraction gi = new GameInteraction(gameIo);

            //Act
            gi.StartInteractiveLudoGame();

            //Assert
            Assert.Equal("Welcome to Ludo game", gameIo.Messages[0]);
        }

        [Fact]
        public void PlayerGetsInitialOptions()
        {
            //Arrange
            var gameIo = new ListIOController();
            gameIo.Actions = new List<object>() { 0 };
            GameInteraction gi = new GameInteraction(gameIo);

            //Act
            gi.StartInteractiveLudoGame();

            //Assert
            Assert.Equal("[0] Start a new game", gameIo.Messages[1]);
            Assert.Equal("[1] Load a game", gameIo.Messages[2]);
            Assert.Equal("[2] Show history", gameIo.Messages[3]);
            Assert.Equal("Choose a option:", gameIo.Messages[4]);
        }

        [Fact]
        public void CanStartNewGameWithTwoPlayers()
        {
            //Arrange
            var gameIo = new ListIOController();
            gameIo.Actions = new List<object>() { 0, 2, "MyFirstPlayer", "Red", "MySecondPlayer", "Green" };
            GameInteraction gi = new GameInteraction(gameIo);

            //Act
            gi.StartInteractiveLudoGame();
            gi.ChooseMenuOption();

            //Assert
            Assert.StartsWith("Your new game have ID:", gameIo.Messages[12]);



            //As a ludo-player I want to be able to start a new ludo game where all peices are at the inital positons
        }

        [Fact]
        public void ShowGameHistory()
        {
            //As a ludo-player, I want to be able look at game-history, to see past games.
            //Arrange
            var gameIo = new ListIOController();
            GameInteraction gi = new GameInteraction(gameIo);

            //Act
            gameIo.Actions = new List<object>() { 0, 2, "MyFirstPlayer", "Red", "MySecondPlayer", "Green" };
            gi.StartInteractiveLudoGame();
            gi.ChooseMenuOption();
            gi.ShowGameHistory();

            //Assert
            Assert.StartsWith("Showing your game history from with ID: ", gameIo.Messages[13]);
        }

        [Fact]
        public void LoadUnifinishedGame()
        {
            //As a ludo-player, I want to be able to load an unfinished game, to continue playing that game.

            //Arrange
            var gameIo = new ListIOController();
            gameIo.Actions = new List<object>() { 0, 2, "MyFirstPlayer", "Red", "MySecondPlayer", "Green" };
            GameInteraction gi = new GameInteraction(gameIo);
            gi.StartInteractiveLudoGame();
            gi.ChooseMenuOption();
        }

        [Fact]
        public void PossibleToSetNameAndColor()
        {
            //As a ludo-player I want to set my name and color when joining a new game
            throw new NotImplementedException();
        }

        [Fact]
        public void CanProviceNumberOfPlayers()
        {
            //As a ludo-player I want to decide how many player should be in a new game when creating a new game
            throw new NotImplementedException();
        }





        [Fact]
        public void CanSeeCurrentPlayer()
        {
            //As a ludo-player, I want to to see who turn it currently is all the time
            throw new NotImplementedException();
        }

        [Fact]
        public void CanRollDiceAndMovePiece()
        {
            //As a ludo-player, I want to be able to roll the dice, so I can move a game piece.
            throw new NotImplementedException();
        }

        [Fact]
        public void ChoosePieceToMove()
        {
            //As a ludo-player, I want to be able to choose which piece in the game to move.
            throw new NotImplementedException();
        }

        [Fact]
        public void KnockOverOpponent()
        {
            //As a ludo-player, I want to be able to "knock over" a opponent gamepiece, so that game piece gets returned to the home of the player when landing on the same tile this happens when two peices are at the same position (*collision position*).
            throw new NotImplementedException();
        }

        [Fact]
        public void GetPointsOnReachingGoal()
        {
            //As a ludo-player, I want to be able to move my game piece to the *goal position*, so I can get points.
            throw new NotImplementedException();
        }

        [Fact]
        public void GetScoreBoardAfterMove()
        {
            //As a ludo - player, I want to be able to keep track of how many points all players in the game have after each move
            throw new NotImplementedException();
        }

        [Fact]
        public void IsWinnerWith4Points()
        {
            //As a ludo player I want to be declared as the winner when reaching 4 points
            throw new NotImplementedException();
        }

        [Fact]
        public void CanMoveToGameBoard()
        {
            //As a ludo player I want to be allowed to move a game peice from home to the gameboard start position when hitting 1 or 6 with a dice, if the start position is empty
            throw new NotImplementedException();
        }

        [Fact]
        public void ExtraRollOn6()
        {
            //As a ludo player if I het 6 with the dice will I be given an extra roll
            
        }
    }
}
