using System;
using NUnit.Framework;
using TicTacToeKata;

namespace Tests
{
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
            _board.MakeMove("X", 2, 0);

            Assert.That(_board.State, Is.EqualTo("PlayerXWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerXWinsSecondColumnAfter3Turns()
        {
            _board.MakeMove("X", 0, 1);
            _board.MakeMove("O", 1, 0);
            _board.MakeMove("X", 1, 1);
            _board.MakeMove("O", 2, 0);
            _board.MakeMove("X", 2, 1);

            Assert.That(_board.State, Is.EqualTo("PlayerXWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerXWinsThirdColumnAfter3Turns()
        {
            _board.MakeMove("X", 0, 2);
            _board.MakeMove("O", 1, 0);
            _board.MakeMove("X", 1, 2);
            _board.MakeMove("O", 2, 0);
            _board.MakeMove("X", 2, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerXWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerOWinsThirdColumnAfter3Turns()
        {
            _board.MakeMove("O", 0, 2);
            _board.MakeMove("X", 1, 0);
            _board.MakeMove("O", 1, 2);
            _board.MakeMove("X", 2, 0);
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

        [Test]
        public void DisplayMovesWhenPlayerOWinsMiddleRowAfter3Turns()
        {
            _board.MakeMove("X", 0, 0);
            _board.MakeMove("O", 1, 0);
            _board.MakeMove("X", 0, 1);
            _board.MakeMove("O", 1, 1);
            _board.MakeMove("X", 2, 1);
            _board.MakeMove("O", 1, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerOWinsBottomRowAfter3Turns()
        {
            _board.MakeMove("X", 0, 0);
            _board.MakeMove("O", 2, 0);
            _board.MakeMove("X", 1, 1);
            _board.MakeMove("O", 2, 1);
            _board.MakeMove("X", 1, 0);
            _board.MakeMove("O", 2, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerXWinsBottomRowAfter3Turns()
        {
            _board.MakeMove("O", 0, 0);
            _board.MakeMove("X", 2, 0);
            _board.MakeMove("O", 1, 1);
            _board.MakeMove("X", 2, 1);
            _board.MakeMove("O", 1, 2);
            _board.MakeMove("X", 2, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerXWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerOWinsTopLeftToBottomRightDiagonal()
        {
            _board.MakeMove("X", 1, 0);
            _board.MakeMove("O", 0, 0);
            _board.MakeMove("X", 2, 1);
            _board.MakeMove("O", 1, 1);
            _board.MakeMove("X", 2, 0);
            _board.MakeMove("O", 2, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerXWinsTopLeftToBottomRightDiagonal()
        {
            _board.MakeMove("O", 2, 0);
            _board.MakeMove("X", 0, 0);
            _board.MakeMove("O", 2, 1);
            _board.MakeMove("X", 1, 1);
            _board.MakeMove("O", 1, 0);
            _board.MakeMove("X", 2, 2);

            Assert.That(_board.State, Is.EqualTo("PlayerXWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerOWinsTopRightToBottomLeftDiagonal()
        {
            _board.MakeMove("X", 0, 0);
            _board.MakeMove("O", 0, 2);
            _board.MakeMove("X", 2, 1);
            _board.MakeMove("O", 1, 1);
            _board.MakeMove("X", 2, 2);
            _board.MakeMove("O", 2, 0);

            Assert.That(_board.State, Is.EqualTo("PlayerOWins"));
        }

        [Test]
        public void DisplayMovesWhenPlayerXWinsTopRightToBottomLeftDiagonal()
        {
            _board.MakeMove("O", 0, 0);
            _board.MakeMove("X", 0, 2);
            _board.MakeMove("O", 2, 1);
            _board.MakeMove("X", 1, 1);
            _board.MakeMove("O", 2, 2);
            _board.MakeMove("X", 2, 0);

            Assert.That(_board.State, Is.EqualTo("PlayerXWins"));
        }

        [Test]
        public void ThrowInvalidOperationExceptionWhenPlayerMakesMoveInPositionAlreadyTaken()
        {
            _board.MakeMove("O", 0, 0);
            var exception = Assert.Throws<InvalidOperationException>(() => _board.MakeMove("X", 0, 0));
            
            Assert.That(exception.Message, Is.EqualTo("Invalid move, position already taken."));
        }
    }
}