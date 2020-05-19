using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class CheckLines
    {
        public static bool CheckHorizontalLine(GameBoard board, int placedRow, int placedCol, string piece, int toCheck, int lineLength)
        {
            int checkedSpots = 0;
            int filledByPiece = 0;
            // Check initial spot
            if (board.GetGameBoardSpace(placedRow, placedCol) == piece)
            {
                checkedSpots++;
                filledByPiece++;
                // Check spots to the right
                for (int col = placedCol + 1; col < board.cols; col++)
                {
                    if (board.GetGameBoardSpace(placedRow, col) == piece)
                    {
                        checkedSpots++;
                        filledByPiece++;
                    }
                    else break;
                    if (checkedSpots == toCheck) break;
                }
                // Check spots to the left
                if (checkedSpots < toCheck)
                {
                    for (int col = placedCol - 1; col >= 0; col--)
                    {
                        if (board.GetGameBoardSpace(placedRow, col) == piece)
                        {
                            checkedSpots++;
                            filledByPiece++;
                        }
                        else
                        {
                            checkedSpots++;
                            break;
                        }
                        if (checkedSpots == toCheck) break;
                    }
                }
            }
            //
            if (filledByPiece == lineLength && checkedSpots == toCheck) return true;
            else return false;
        }

        public static bool CheckVerticalLine(GameBoard board, int placedRow, int placedCol, string piece, int toCheck, int lineLength)
        {
            int checkedSpots = 0;
            int filledByPiece = 0;
            // Check initial spot
            if (board.GetGameBoardSpace(placedRow, placedCol) == piece)
            {
                checkedSpots++;
                filledByPiece++;
                // Check spots below
                for (int row = placedRow + 1; row < board.rows; row++)
                {
                    if (board.GetGameBoardSpace(row, placedCol) == piece)
                    {
                        checkedSpots++;
                        filledByPiece++;
                    }
                    else break;
                    if (checkedSpots == toCheck) break;
                }
                //Check spots above
                if (checkedSpots < toCheck)
                {
                    for (int row = placedRow - 1; row >= 0; row--)
                    {
                        if (board.GetGameBoardSpace(row, placedCol) == piece)
                        {
                            checkedSpots++;
                            filledByPiece++;
                        }
                        else
                        {
                            checkedSpots++;
                            break;
                        }
                        if (checkedSpots == toCheck) break;
                    }
                }
            }
            if (filledByPiece == lineLength && checkedSpots == toCheck) return true;
            else return false;
        }

        public static bool CheckDiagonal1Line(GameBoard board, int placedRow, int placedCol, string piece, int toCheck, int lineLength)
        {
            int checkedSpots = 0;
            int filledByPiece = 0;
            // Check initial spot
            if (board.GetGameBoardSpace(placedRow, placedCol) == piece)
            {
                checkedSpots++;
                filledByPiece++;
                // Check spots down and to right
                int col = placedCol + 1;
                for (int row = placedRow + 1; row < board.rows; row++)
                {
                    if (col < board.cols)
                    {
                        if (board.GetGameBoardSpace(row, col) == piece)
                        {
                            checkedSpots++;
                            filledByPiece++;
                            col++;
                        }
                        else break;
                    }
                    else break;
                    if (checkedSpots == toCheck) break;
                }
                // Check spots up and to left
                if (checkedSpots < toCheck)
                {
                    col = placedCol - 1;
                    for (int row = placedRow - 1; row >= 0; row--)
                    {
                        if (col >= 0)
                        {
                            if (board.GetGameBoardSpace(row, col) == piece)
                            {
                                checkedSpots++;
                                filledByPiece++;
                                col--;
                            }
                            else break;
                        }
                        else break;
                        if (checkedSpots == toCheck) break;
                    }
                }
            }
            //
            if (filledByPiece == lineLength && checkedSpots == toCheck) return true;
            else return false;
        }

        public static bool CheckDiagonal2Line(GameBoard board, int placedRow, int placedCol, string piece, int toCheck, int lineLength)
        {
            int checkedSpots = 0;
            int filledByPiece = 0;
            // Check initial spot
            if (board.GetGameBoardSpace(placedRow, placedCol) == piece)
            {
                checkedSpots++;
                filledByPiece++;
                // Check spots down and to left
                int col = placedCol - 1;
                for (int row = placedRow + 1; row < board.rows; row++)
                {
                    if (col >= 0)
                    {
                        if (board.GetGameBoardSpace(row, col) == piece)
                        {
                            checkedSpots++;
                            filledByPiece++;
                            col--;
                        }
                        else break;
                    }
                    else break;
                    if (checkedSpots == toCheck) break;
                }
                // Check spots up and to right
                if (checkedSpots < toCheck)
                {
                    col = placedCol + 1;
                    for (int row = placedRow - 1; row >= 0; row--)
                    {
                        if (col < board.cols)
                        {
                            if (board.GetGameBoardSpace(row, col) == piece)
                            {
                                checkedSpots++;
                                filledByPiece++;
                                col++;
                            }
                            else
                            {
                                checkedSpots++;
                                break;
                            }
                        }
                        else break;
                        if (checkedSpots == toCheck) break;
                    }
                }
            }
            if (filledByPiece == lineLength && checkedSpots == toCheck) return true;
            else return false;
        }
    }
}
