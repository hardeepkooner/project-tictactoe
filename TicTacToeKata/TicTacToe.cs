using System;

// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace TicTacToeKata
{
    public class TicTacToe
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

            if (_board[x, y] != null)
            {
                throw new InvalidOperationException("Invalid move, position already taken.");
            }

            _board[x, y] = player;

            State = CheckHorizontalWin();
            if (State == string.Empty)
            {
                State = CheckVerticalWin();
            }

            if (State == string.Empty)
            {
                State = CheckTopLeftToBottomRightDiagonalWin();
            }

            if (State == string.Empty)
            {
                State = CheckTopRightToBottomLeftDiagonalWin();
            }

            

            return _board;
        }

        private string CheckTopRightToBottomLeftDiagonalWin()
        {
            string cross = "X";
            if (_board[FirstRow, ThirdColumn] == cross &&
                _board[SecondRow, SecondColumn] == cross &&
                _board[ThirdRow, FirstColumn] == cross)
            {
                return "PlayerXWins";
            }

            string naught = "O";
            if (_board[FirstRow, ThirdColumn] == naught &&
                _board[SecondRow, SecondColumn] == naught &&
                _board[ThirdRow, FirstColumn] == naught)
            {
                return "PlayerOWins";
            }

            return string.Empty;
        }

        private string CheckTopLeftToBottomRightDiagonalWin()
        {
            string cross = "X";
            if (_board[FirstRow, FirstColumn] == cross &&
                _board[SecondRow, SecondColumn] == cross &&
                _board[ThirdRow, ThirdColumn] == cross)
            {
                return "PlayerXWins";
            }

            string naught = "O";
            if (_board[FirstRow, FirstColumn] == naught &&
                _board[SecondRow, SecondColumn] == naught &&
                _board[ThirdRow, ThirdColumn] == naught)
            {
                return "PlayerOWins";
            }

            return string.Empty;
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

            if (CheckColumn(naught, FirstRow) ||
                CheckColumn(naught, SecondRow) ||
                CheckColumn(naught, ThirdRow))
            {
                return playerOWins;
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
            const string playerXWins = "PlayerXWins";
            const string naught = "O";
            const string cross = "X";

            if (CheckRow(naught, FirstRow) ||
                CheckRow(naught, SecondRow) ||
                CheckRow(naught, ThirdRow))
            {
                return playerOWins;
            }

            if (CheckRow(cross, FirstRow) ||
                CheckRow(cross, SecondRow) ||
                CheckRow(cross, ThirdRow))
            {
                return playerXWins;
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