using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeGame
    {
        List<Player> myPlayers = new List<Player>();
        public TicTacToeGame()
        {
            myPlayers.Add(new Player("X", "Human", "Amateur"));
            myPlayers.Add(new Player("O", "Computer", "Expert"));
        }

        public void PlayGame()
        {
            bool changePlayerLoop;
            do
            {
                Console.Clear();
                Console.WriteLine(" Tic-Tac-Toe\n");
                changePlayerLoop = ChangePlayer();
            } while (!changePlayerLoop);

            GameBoard myGameBoard = new GameBoard(3, 3, " ", true, "left", "number", "top", "letter");
            GameBoard aiGameBoard = new GameBoard(3, 3, " ", true, "left", "number", "top", "letter");

            //GameBoard myGameBoard = new GameBoard(4, 4, " ", true, "left", "number", "top", "letter");
            //GameBoard aiGameBoard = new GameBoard(4, 4, " ", true, "left", "number", "top", "letter");

            //GameBoard myGameBoard = new GameBoard(5, 5, " ", true, "left", "number", "top", "letter");
            //GameBoard aiGameBoard = new GameBoard(5, 5, " ", true, "left", "number", "top", "letter");

            #region
            /*
            myGameBoard.SetGameBoardSpace(0, 0, "O");
            myGameBoard.SetGameBoardSpace(0, 1, " ");
            myGameBoard.SetGameBoardSpace(0, 2, "X");

            myGameBoard.SetGameBoardSpace(1, 0, "X");
            myGameBoard.SetGameBoardSpace(1, 1, "X");
            myGameBoard.SetGameBoardSpace(1, 2, "O");

            myGameBoard.SetGameBoardSpace(2, 0, "O");
            myGameBoard.SetGameBoardSpace(2, 1, " ");
            myGameBoard.SetGameBoardSpace(2, 2, " ");
            */
            #endregion

            #region
            /*
            myGameBoard.SetGameBoardSpace(0, 0, "#");
            myGameBoard.SetGameBoardSpace(0, 1, "#");
            myGameBoard.SetGameBoardSpace(0, 2, " ");
            myGameBoard.SetGameBoardSpace(0, 3, "#");
            myGameBoard.SetGameBoardSpace(0, 4, "#");

            myGameBoard.SetGameBoardSpace(1, 0, "#");
            myGameBoard.SetGameBoardSpace(1, 1, " ");
            myGameBoard.SetGameBoardSpace(1, 2, " ");
            myGameBoard.SetGameBoardSpace(1, 3, " ");
            myGameBoard.SetGameBoardSpace(1, 4, "#");

            myGameBoard.SetGameBoardSpace(2, 0, "#");
            myGameBoard.SetGameBoardSpace(2, 1, " ");
            myGameBoard.SetGameBoardSpace(2, 2, " ");
            myGameBoard.SetGameBoardSpace(2, 3, " ");
            myGameBoard.SetGameBoardSpace(2, 4, "#");

            myGameBoard.SetGameBoardSpace(3, 0, "#");
            myGameBoard.SetGameBoardSpace(3, 1, " ");
            myGameBoard.SetGameBoardSpace(3, 2, " ");
            myGameBoard.SetGameBoardSpace(3, 3, " ");
            myGameBoard.SetGameBoardSpace(3, 4, "#");

            myGameBoard.SetGameBoardSpace(4, 0, "#");
            myGameBoard.SetGameBoardSpace(4, 1, "#");
            myGameBoard.SetGameBoardSpace(4, 2, "#");
            myGameBoard.SetGameBoardSpace(4, 3, "#");
            myGameBoard.SetGameBoardSpace(4, 4, "#");
            */
            #endregion

            //TicTacToeGameRules myGameRules = new TicTacToeGameRules(myGameBoard, aiGameBoard, 5, 3, myPlayers);
            TicTacToeGameRules myGameRules = new TicTacToeGameRules(myGameBoard, aiGameBoard, 3, int.MaxValue, myPlayers);
            //TicTacToeGameRules myGameRules = new TicTacToeGameRules(myGameBoard, aiGameBoard, 5, 9, myPlayers);
            

            PlayAgain();
        }

        private bool ChangePlayer()
        {
            Player playerX = myPlayers.Find(p => p.myPiece.Contains("X"));
            Player playerO = myPlayers.Find(p => p.myPiece.Contains("O"));
            Player playerChange = new Player();
            bool validInput = false;
            do
            {
                Console.Write(" Player X: {0}", playerX.myType);
                if (playerX.myType == "Computer")
                {
                    Console.Write(" | Skill: {0}", playerX.mySkill);
                }
                Console.WriteLine();
                Console.Write(" Player O: {0}", playerO.myType);
                if (playerO.myType == "Computer")
                {
                    Console.Write(" | Skill: {0}", playerO.mySkill);
                }
                Console.WriteLine();
                Console.WriteLine();

                Console.Write(" Change players? (Y/N): ");
                string input = Console.ReadLine();
                if (String.Equals(input, "Y", StringComparison.OrdinalIgnoreCase))
                {
                    validInput = true;
                }
                else if (String.Equals(input, "N", StringComparison.OrdinalIgnoreCase))
                {
                    validInput = true;
                    return true;
                }
                else
                {
                    Console.WriteLine(" Invalid input -- try again.");
                }
            } while (!validInput);

            validInput = false;
            do
            {
                Console.Write(" Which player do you want to change? (X/O): ");
                string input = Console.ReadLine().ToUpper();

                if (input == "X")
                {
                    playerChange = playerX;
                    validInput = true;
                }
                else if (input == "O")
                {
                    playerChange = playerO;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine(" Invalid input -- try again.");
                }
            } while (!validInput);

            if (playerChange.myType == "Human")
            {
                playerChange.myType = "Computer";
            }
            else
            {
                playerChange.myType = "Human";
            }

            if (playerChange.myType == "Computer")
            {
                do
                {
                    Console.WriteLine();
                    Console.Write(" Player X: {0}", playerChange.myType);
                    Console.Write(" | Skill: {0}", playerChange.mySkill);
                    Console.WriteLine();

                    Console.Write(" Change skill level? (Y/N): ");
                    string input = Console.ReadLine().ToUpper();

                    if (input == "Y")
                    {
                        if (playerChange.mySkill == "Amateur")
                        {
                            playerChange.mySkill = "Expert";
                        }
                        else
                        {
                            playerChange.mySkill = "Amateur";
                        }
                        validInput = true;
                    }
                    else if (input == "N")
                    {
                        validInput = true;
                        //return true;
                    }
                    else
                    {
                        Console.WriteLine(" Invalid input -- try again.");
                    }
                } while (!validInput);
            }

            return false;
        }

        public void PlayAgain()
        {
            bool validInput = false;
            do
            {
                Console.Write(" Play again? (Y/N): ");
                string input = Console.ReadLine().ToUpper();

                if (input == "Y")
                {
                    validInput = true;
                    PlayGame();
                }
                else if (input == "N")
                {
                    return;
                }
                else
                {
                    Console.WriteLine(" Invalid input -- try again.");
                }
            } while (!validInput);
            
        }
    }
}
