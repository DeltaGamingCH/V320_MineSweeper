using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic.Tests
{
    public class GameModelTests
    {
        [Test]
        public void InitializeFields_CreatesCorrectNumberOfFields()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            // Act
            gameModel.InitializeFields();
            // Assert
            int actualFieldCount = gameModel.Fields.Cast<Field>().Count();
            int expectedFieldCount = difficulty.Size[0].Width * difficulty.Size[0].Height;
            Assert.AreEqual(expectedFieldCount, actualFieldCount);
        }
        [Test]
        public void IsGameWon_ReturnsFalseWhenGameIsNotWon()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            // Act
            bool isGameWon = gameModel.IsGameWon();
            // Assert
            Assert.IsFalse(isGameWon);
        }
        [Test]
        public void IsGameWon_ReturnsTrueWhenGameIsWon()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            foreach (var field in gameModel.Fields)
            {
                if (!field.IsMine)
                {
                    field.IsVisible = true;
                }
            }
            // Act
            bool isGameWon = gameModel.IsGameWon();
            // Assert
            Assert.IsTrue(isGameWon);
        }
        [Test]
        public void DisplayFields_ShowsCorrectNumberOfFields()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            // Act
            gameModel.DisplayFields();
            // Assert
            int actualFieldCount = gameModel.Fields.Cast<Field>().Count();
            int expectedFieldCount = difficulty.Size[0].Width * difficulty.Size[0].Height;
            Assert.AreEqual(expectedFieldCount, actualFieldCount);
        }
        [Test]
        public void GetDisplayChar_ReturnsCorrectCharForMine()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            var mineField = new Field { IsMine = true };
            // Act
            char displayChar = gameModel.GetDisplayChar(mineField);
            // Assert
            Assert.AreEqual('*', displayChar);
        }
        [Test]
        public void GetDisplayChar_ReturnsCorrectCharForVisibleField()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            var visibleField = new Field { IsVisible = true };
            // Act
            char displayChar = gameModel.GetDisplayChar(visibleField);
            // Assert
            Assert.AreEqual(' ', displayChar);
        }
        [Test]
        public void GetDisplayChar_ReturnsCorrectCharForInvisibleField()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            var invisibleField = new Field { IsVisible = false };
            // Act
            char displayChar = gameModel.GetDisplayChar(invisibleField);
            // Assert
            Assert.AreEqual('.', displayChar);
        }
        [Test]
        public void AdjacentMines_ReturnsCorrectCount()
        {
            // Arrange
            var difficulty = new DifficultyEasy();
            var gameModel = new GameModel(difficulty);
            gameModel.Fields[0, 0].IsMine = true;
            gameModel.Fields[0, 1].IsMine = true;
            gameModel.Fields[1, 0].IsMine = true;
            // Act
            int adjacentMines = gameModel.AdjacentMines(1, 1);
        }
    }
}