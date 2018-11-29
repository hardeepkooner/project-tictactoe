using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace TicTacToeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    [TestFixture]
    class TicTacToeShould
    {
        private TicTacToe _board;

        [SetUp]
        public void SetUp()
        {
            _board = new TicTacToe();
        }

        [Test]
        public void DisplayMoveWhenPlayerXSelectsTopLeft()
        {
            var result = _board.MakeMove("X", 0, 0);

            Assert.That(result[0, 0], Is.EqualTo("X"));
        }

        [Test]
        public void DisplayMovesWhenPlayerXSelectsTopLeftAndPlayerOSelectsTopMiddle()
        {
            _board.MakeMove("X", 0, 0);
            var result = _board.MakeMove("O", 0, 1);

            Assert.That(result[0, 0], Is.EqualTo("X"));
            Assert.That(result[0, 1], Is.EqualTo("O"));
        }

        [Test]
        public void DisplayMovesWhenPlayerXWinsFirstColumnAfter3Turns()
        {
            _board.MakeMove("X", 0, 0);
            _board.MakeMove("O", 0, 1);
            _board.MakeMove("X", 1, 0);
            _board.MakeMove("O", 0, 2);
            var result = _board.MakeMove("X", 2, 0);

            Assert.That(_board.State, Is.EqualTo("PlayerXWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerOWinsMiddleRowAfter3Turns()
        {
            _board.MakeMove("X", 0, 0);
            _board.MakeMove("O", 1, 0);
            _board.MakeMove("X", 0, 1);
            _board.MakeMove("O", 1, 1);
            _board.MakeMove("X", 2, 1);


            var result = _board.MakeMove("O", 1, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerOWinsBottomRowAfter3Turns()
        {
            _board.MakeMove("X", 2, 0);
            _board.MakeMove("O", 2, 0);
            _board.MakeMove("X", 2, 1);
            _board.MakeMove("O", 2, 1);
            _board.MakeMove("X", 1, 0);
            _board.MakeMove("O", 2, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerOWinsTopRowAfter3Turns()
        {
            _board.MakeMove("X", 2, 0);
            _board.MakeMove("O", 0, 0);
            _board.MakeMove("X", 2, 1);
            _board.MakeMove("O", 0, 1);
            _board.MakeMove("X", 1, 0);
            _board.MakeMove("O", 0, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
        }

//        [Test]
//        public void DisplayMovesWhenPlayerOWinsTopLeftDiagonal()
//        {
//            _board.MakeMove("X", 2, 0);
//            _board.MakeMove("O", 0, 0);
//            _board.MakeMove("X", 2, 1);
//            _board.MakeMove("O", 1, 1);
//            _board.MakeMove("X", 0, 2);
//            _board.MakeMove("O", 2, 2);
//            
//            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
//        }
    }

    internal class TicTacToe
    {
        private string[,] _board;
        public string State { get; set; }

        private const int FirstColumn = 0;
        private const int SecondColumn = 1;
        private const int ThirdColumn = 2;

        private const int FirstRow = 0;
        private const int SecondRow = 1;
        private const int ThirdRow = 2;

        public TicTacToe()
        {
            _board = new string[3, 3];
        }

        public string[,] MakeMove(string player, int x, int y)
        {
            _board[x, y] = player;
            
            State = CheckHorizontalWin();
            if (State == string.Empty)
            {
                State = CheckVerticalWin();
            }
            

            return _board;
        }

        private string CheckVerticalWin()
        {
            const string playerOWins = "PlayerOWins";
            const string playerXWins = "PlayerXWins";
            const string naught = "O";
            const string cross = "X";

            if (CheckColumn(cross, FirstRow) ||
                CheckColumn(cross, SecondRow) ||
                CheckColumn(cross, ThirdRow))
            {
                return playerXWins;
            }

            return "";
        }

        private bool CheckColumn(string player, int column)
        {
            return _board[FirstRow, column] == player &&
                   _board[SecondRow, column] == player &&
                   _board[ThirdRow, column] == player;
        }

        private string CheckHorizontalWin()
        {
            const string playerOWins = "PlayerOWins";
            const string naught = "O";

            if (CheckRow(naught, FirstRow) ||
                CheckRow(naught, SecondRow) ||
                CheckRow(naught, ThirdRow))
            {
                return playerOWins;
            }

            return "";
        }

        private bool CheckRow(string naught, int row)
        {
            return _board[row, FirstColumn] == naught &&
                   _board[row, SecondColumn] == naught &&
                   _board[row, ThirdColumn] == naught;
        }
    }
}