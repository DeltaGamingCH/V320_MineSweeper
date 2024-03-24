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
    [TestClass]
    public class GameModelTests
    {
        private StringWriter _stringWriter;
        private StringReader _stringReader;
        private GameModel _gameModel;
        private Field[,] _fields;


        [TestInitialize]
        public void TestInitialize()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
            IGameDifficulty difficulty = new DifficultyEasy();
            _gameModel = new GameModel(difficulty);
        }

        [TestMethod]
        public void DoTurn_InvalidMove_ShouldPrintErrorMessage()
        {
            // Arrange
            _stringReader = new StringReader("Z9\n");
            Console.SetIn(_stringReader);

            // Act
            _gameModel.DoTurn();

            // Assert
            Assert.IsTrue(_stringWriter.ToString().Contains("Invalid move. Please enter a valid coordinate."));
        }
        [TestMethod]
        public void IsGameWon_AllNonMineFieldsVisible_ReturnsTrue()
        {
            // Arrange
            Field[,] fields = new Field[3, 3]
            {
        { new Field { IsMine = false, IsVisible = true }, new Field { IsMine = true, IsVisible = false }, new Field { IsMine = false, IsVisible = true } },
        { new Field { IsMine = false, IsVisible = true }, new Field { IsMine = false, IsVisible = true }, new Field { IsMine = true, IsVisible = false } },
        { new Field { IsMine = false, IsVisible = true }, new Field { IsMine = false, IsVisible = true }, new Field { IsMine = false, IsVisible = true } }
            };
            IGameDifficulty difficulty = new DifficultyEasy();
            GameModel gameModel = new GameModel(difficulty);

            // Act
            bool result = gameModel.IsGameWon(fields);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DoTurn_HitMine_ShouldEndGame()
        {
            // Arrange
            _stringReader = new StringReader("A1\n");
            Console.SetIn(_stringReader);
            _gameModel._fields[0, 0].IsMine = true; // Assume A1 is a mine

            // Act
            _gameModel.DoTurn();

            // Assert
            Assert.IsTrue(_stringWriter.ToString().Contains("Boom! You hit a mine. Game over."));
        }
        [TestMethod]
        public void DoTurn_WinGame_ShouldPrintWinMessage()
        {
            // Arrange
            _stringReader = new StringReader("A1\n");
            Console.SetIn(_stringReader);
            _gameModel._fields[0, 0].IsMine = false; // Assume A1 is not a mine
            _gameModel._fields[0, 1].IsMine = true; // Assume A2 is a mine
            _gameModel._fields[0, 0].IsVisible = true; // Assume A1 is already revealed

            // Act
            _gameModel.DoTurn();

            // Assert
            Assert.IsTrue(_stringWriter.ToString().Contains("Congratulations! You've cleared all the mines. You won!"));
        }
        [TestMethod]
        public void DoTurn_UndoMove_ShouldRestorePreviousState()
        {
            // Arrange
            _stringReader = new StringReader("A1\nundo\n");
            Console.SetIn(_stringReader);
            _gameModel._fields[0, 0].IsMine = false; // Assume A1 is not a mine

            // Act
            _gameModel.DoTurn();

            // Assert
            Assert.IsFalse(_gameModel._fields[0, 0].IsVisible); // The field should not be visible after undoing the move
        }
        [TestMethod]
        public void TestAdjacentMines_NoMines_ReturnsZero()
        {
            // Arrange
            Field[,] fields = new Field[3, 3]
            {
        { new Field { IsMine = false }, new Field { IsMine = false }, new Field { IsMine = false } },
        { new Field { IsMine = false }, new Field { IsMine = false }, new Field { IsMine = false } },
        { new Field { IsMine = false }, new Field { IsMine = false }, new Field { IsMine = false } }
            };
            IGameDifficulty difficulty = new DifficultyEasy();
            GameModel gameModel = new GameModel(difficulty);

            // Act
            int result = gameModel.TestAdjacentMines(fields, 1, 1);

            // Assert
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void AdjacentMines_AllMines_ReturnsEight()
        {
            // Arrange
            Field[,] fields = new Field[3, 3]
            {
                { new Field { IsMine = true }, new Field { IsMine = true }, new Field { IsMine = true } },
                { new Field { IsMine = true }, new Field { IsMine = true }, new Field { IsMine = true } },
                { new Field { IsMine = true }, new Field { IsMine = true }, new Field { IsMine = true } }
            };
            IGameDifficulty difficulty = new DifficultyEasy();
            GameModel gameModel = new GameModel(difficulty);

            // Act
            int result = gameModel.TestAdjacentMines(fields, 1, 1);

            // Assert
            Assert.AreEqual(8, result);
        }
        [TestMethod]
        public void InitializeFields_FieldsInitialized_NotNull()
        {
            // Act
            _gameModel.InitializeFields();

            // Assert
            for (int row = 0; row < _gameModel._fields.GetLength(0); row++)
            {
                for (int column = 0; column < _gameModel._fields.GetLength(1); column++)
                {
                    Assert.IsNotNull(_gameModel._fields[row, column]);
                }
            }
        }
        [TestMethod]
        public void DisplayFields_ValidFields_ShouldPrintCorrectly()
        {
            // Arrange
            Field[,] fields = new Field[3, 3]
            {
                { new Field { IsMine = false }, new Field { IsMine = false }, new Field { IsMine = false } },
                { new Field { IsMine = false }, new Field { IsMine = false }, new Field { IsMine = false } },
                { new Field { IsMine = false }, new Field { IsMine = false }, new Field { IsMine = false } }
            };

            // Act
            GameModel.DisplayFields(fields);

            // Assert
            string expectedOutput = "   | 1 | 2 | 3 |\n---- ---- ---- ----\nA |   |   |   |\n---- ---- ---- ----\nB |   |   |   |\n---- ---- ---- ----\nC |   |   |   |\n---- ---- ---- ----\n";
            Assert.AreEqual(expectedOutput, _stringWriter.ToString());
        }

[TestCleanup]
        public void TestCleanup()
        {
            _stringWriter.Close();
            _stringReader.Close();
        }
    }
}