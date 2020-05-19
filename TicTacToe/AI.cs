using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class AI
    {
        public static void ExpertMove(GameBoard board, GameBoard aiboard, Player player, TicTacToeGameRules myGameRules, out int row, out int col)
        {
            row = 0;
            col = 0;
            int bestScore = -1;
            int score;
            aiboard.InitializeGameBoard();

            if (board.rows == 3 && board.cols == 3 && board.GetGameBoardSpace(1, 1) == " ")
            {
                row = 1;
                col = 1;
            }
            else
            {
                for (int y = 0; y < board.rows; y++)
                {
                    for (int x = 0; x < board.cols; x++)
                    {
                        if (board.GetGameBoardSpace(y, x) == " ")
                        {
                            board.SetGameBoardSpace(y, x, player.myPiece);
                            score = Minimax(board, myGameRules.minimaxDepth, false, y, x, -1, myGameRules);
                            board.SetGameBoardSpace(y, x, " ");
                            if (score > bestScore)
                            {
                                bestScore = score;
                            }
                            aiboard.SetGameBoardSpace(y, x, score.ToString());
                            //aiGameBoard.DrawGameBoard();
                        }
                    }
                }
                // See scores
                //aiboard.DrawGameBoard();
                //Console.WriteLine($"bestScore = {bestScore}");
                //Console.ReadLine();

                // Pick Random From Best
                Random rand = new Random();
                do
                {
                    row = rand.Next(board.rows);
                    col = rand.Next(board.cols);
                } while (aiboard.GetGameBoardSpace(row, col) != bestScore.ToString());
            }
        }
        private static int Minimax(GameBoard board, int depth, bool isMaximizing, int row, int col, int parentBestScore, TicTacToeGameRules myGameRules)
        {
            int maxScore = 1;
            int minScore = -1;
            int score;

            // See move
            //board.DrawGameBoard();
            //Console.ReadLine();
            if (TicTacToeGameRules.CheckForWin(board, row, col, myGameRules.currentPlayer.myPiece))
            {
                score = 1;
                return score;
            }
            else if (TicTacToeGameRules.CheckForWin(board, row, col, myGameRules.opponent.myPiece))
            {
                score = -1;
                return score;
            }
            else if (TicTacToeGameRules.CheckForDraw(board) || depth <= 0)
            {
                score = 0;
                return score;
            }

            if (isMaximizing)
            {
                int bestScore = minScore;
                for (int y = 0; y < board.rows; y++)
                {
                    for (int x = 0; x < board.cols; x++)
                    {
                        if (board.GetGameBoardSpace(y, x) == " ")
                        {
                            board.SetGameBoardSpace(y, x, myGameRules.currentPlayer.myPiece);
                            score = Minimax(board, depth - 1, false, y, x, minScore, myGameRules);
                            board.SetGameBoardSpace(y, x, " ");
                            if (score > bestScore) bestScore = score;
                            if (bestScore >= parentBestScore) return bestScore;
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = maxScore;
                for (int y = 0; y < board.rows; y++)
                {
                    for (int x = 0; x < board.cols; x++)
                    {
                        if (board.GetGameBoardSpace(y, x) == " ")
                        {
                            board.SetGameBoardSpace(y, x, myGameRules.opponent.myPiece);
                            score = Minimax(board, depth - 1, true, y, x, maxScore, myGameRules);
                            board.SetGameBoardSpace(y, x, " ");
                            if (score < bestScore) bestScore = score;
                            if (bestScore <= parentBestScore) return bestScore;
                        }
                    }
                }
                return bestScore;
            }
        }
    }
}
