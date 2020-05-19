using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeGameRules
    {
        public const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        GameBoard myGameBoard;
        GameBoard aiGameBoard;
        public static int winningLength { get; set; }
        bool gameOver;
        List<Player> myPlayers;
        public Player currentPlayer { get; set; }
        public Player opponent { get; set; }
        public int minimaxDepth { get; set; }

        public TicTacToeGameRules(GameBoard board, GameBoard aiBoard, int length, int depth, List<Player> players)
        {
            myGameBoard = board;
            aiGameBoard = aiBoard;
            winningLength = length;
            minimaxDepth = depth;
            myPlayers = players;
            string firstPlayer = DetermineFirstPlayer();
            currentPlayer = myPlayers.Find(p => p.myPiece == firstPlayer);
            if (currentPlayer.myPiece == "X") opponent = myPlayers.Find(p => p.myPiece == "O");
            else opponent = myPlayers.Find(p => p.myPiece == "X");
            gameOver = false;
            do
            {
                myGameBoard.DrawGameBoard();
                if (currentPlayer.myType == "Computer" && opponent.myType == "Computer") Thread.Sleep(1000);
                TakeTurn(myGameBoard, aiBoard, currentPlayer);
                if (!gameOver) SwitchPlayer();
            }
            while (!gameOver);
        }

        private string DetermineFirstPlayer()
        {
            string input;
            bool validInput = false;
            do
            {
                Console.Write(" Which player goes first? (X/O): ");
                input = Console.ReadLine().ToUpper();
                if (input != "X" && input != "O") Console.WriteLine(" Invalid input -- try again.");
                else validInput = true;
            } while (!validInput);
            return input;
        }

        private void TakeTurn(GameBoard board, GameBoard aiBoard, Player player)
        {
            bool validMove;
            int row;
            int col;
            do
            {
                if(player.myType == "Human")
                {
                    row = SelectRow(board);
                    col = SelectColumn(board);
                }
                else if (player.myType == "Computer" && currentPlayer.mySkill == "Amateur")
                {
                    Random rand = new Random();
                    row = rand.Next(board.rows);
                    col = rand.Next(board.cols);
                }
                else if (player.myType == "Computer" && currentPlayer.mySkill == "Expert")
                {
                    AI.ExpertMove(board, aiBoard, player, this, out row, out col);
                }
                else
                {
                    //Skip Turn
                    return;
                }
                validMove = PlacePiece(board, row, col, player);
            } while (!validMove);
            if (CheckForWin(board, row, col, player.myPiece))
            {
                gameOver = true;
                board.DrawGameBoard();
                Console.WriteLine(" Game over! {0} Wins!", player.myPiece);
                return;
            }
            if (CheckForDraw(board))
            {
                gameOver = true;
                board.DrawGameBoard();
                Console.WriteLine(" The game is a draw!");
                return;
            }
            return;
        }

        private void SwitchPlayer()
        {
            if (currentPlayer.myPiece == "X")
            {
                currentPlayer = myPlayers.Find(p => p.myPiece == "O");
                opponent = myPlayers.Find(p => p.myPiece == "X");
            }
            else
            {
                currentPlayer = myPlayers.Find(p => p.myPiece == "X");
                opponent = myPlayers.Find(p => p.myPiece == "O");
            }
        }

        private int SelectRow(GameBoard board)
        {
            int input;
            bool validInput = false;
            do
            {
                if (LabelBorder.horizontalType == "letter")
                {
                    Console.Write(" Player {0}, select a row (A-{1}): ", currentPlayer.myPiece, letters[board.rows - 1]);
                    string str = Console.ReadLine().ToUpper();
                    input = letters.IndexOf(str);
                    if (input == -1 || str.Length > 1) Console.WriteLine(" Invalid input -- try again.");
                    else validInput = true;
                }
                else
                {
                    Console.Write(" Player {0}, select a row (0-{1}): ", currentPlayer.myPiece, (board.rows - 1));
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        if (input < 0 || input >= board.rows) Console.WriteLine(" Invalid row -- try again.");
                        else validInput = true;
                    }
                    else Console.WriteLine(" Invalid input -- try again.");
                }
                
            } while (!validInput);
            return input;
        }

        private int SelectColumn(GameBoard board)
        {
            int input;
            bool validInput = false;
            do
            {
                if (LabelBorder.verticalType == "letter")
                {
                    Console.Write(" Player {0}, select a column (A-{1}): ", currentPlayer.myPiece, letters[board.cols - 1]);
                    string str = Console.ReadLine().ToUpper();
                    input = letters.IndexOf(str);
                    if (input == -1 || str.Length > 1) Console.WriteLine(" Invalid input -- try again.");
                    else validInput = true;
                }
                else
                {
                    Console.Write(" Player {0}, select a column (0-{1}): ", currentPlayer.myPiece, (board.cols - 1));
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        if (input < 0 || input >= board.cols) Console.WriteLine(" Invalid column -- try again.");
                        else validInput = true;
                    }
                    else Console.WriteLine(" Invalid input -- try again.");
                }
            } while (!validInput);
            return input;
        }

        private bool PlacePiece(GameBoard board, int row, int col, Player player)
        {
            if (row >= 0 && row < board.rows && col >= 0 && col < board.cols && board.GetGameBoardSpace(row, col) == " ")
            {
                board.SetGameBoardSpace(row, col, player.myPiece);
                return true;
            }
            else
            {
                if (player.myType == "Human") Console.WriteLine(" Invalid space -- try again.");
                return false;
            }
         }

        public static bool CheckForDraw(GameBoard board)
        {
            int emptySpaces = 0;
            for (int row = 0; row < board.rows; row++)
            {
                for (int col = 0; col < board.cols; col++)
                {
                    if (board.GetGameBoardSpace(row, col) == " ") emptySpaces++;
                }
            }
            if (emptySpaces > 0) return false;
            else return true;
        }
        public static bool CheckForWin(GameBoard board, int row, int col, string piece)
        {
            if (CheckLines.CheckHorizontalLine(board, row, col, piece, winningLength, winningLength)) return true;
            else if(CheckLines.CheckVerticalLine(board, row, col, piece, winningLength, winningLength)) return true;
            else if(CheckLines.CheckDiagonal1Line(board, row, col, piece, winningLength, winningLength)) return true;
            else if(CheckLines.CheckDiagonal2Line(board, row, col, piece, winningLength, winningLength)) return true;
            else return false; 
        }

        
    }
}
