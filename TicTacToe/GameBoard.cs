using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameBoard
    {
        public const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public int rows { get; private set; }
        public int cols { get; private set; }
        private List<List<string>> content { get; set; }
        private bool outerBorder;

        public GameBoard(int initRows = 1, int initCols = 1, string fill = " ", bool initBorder = false, string h="left", string ht="number", string v="top", string vt="number")
        {
            rows = initRows;
            cols = initCols;
            outerBorder = initBorder;
            LabelBorder.horizontal = h;
            LabelBorder.horizontalType = ht;
            LabelBorder.vertical = v;
            LabelBorder.verticalType = vt;
            InitializeGameBoard(fill);
        }

        public void InitializeGameBoard(string fill = " ")
        {
            content = new List<List<string>>();
            for (int y = 0; y < rows; y++)
            {
                content.Add(new List<string>());
                for (int x = 0; x < cols; x++)
                {
                    content[y].Add(fill);
                }
            }
            return;
        }
        public string GetGameBoardSpace(int row, int col)
        {
            return content[row][col];
        }

        public void SetGameBoardSpace(int row, int col, string piece)
        {
            content[row][col] = piece;
        }

        public void DrawGameBoard()
        {
            Console.Clear();
            Console.WriteLine();
            
            // Top Label Border
            if (LabelBorder.vertical == "top" || LabelBorder.vertical == "both")
            {
                if (LabelBorder.horizontal == "left" || LabelBorder.horizontal == "both") Console.Write("   ");
                Console.Write(" ");
                if (outerBorder) Console.Write("|");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(" ");
                    if (LabelBorder.verticalType == "letter")
                    {
                        string value = "";
                        if (col >= letters.Length)
                            value += letters[col / letters.Length - 1];
                        value += letters[col % letters.Length];
                        Console.Write(value);
                        if (col < letters.Length) Console.Write(" ");
                    } else
                    {
                        Console.Write(col);
                        if (col < 10) Console.Write(" ");
                    }
                    if (col < cols - 1) Console.Write("|");
                }
                if (outerBorder) Console.Write("|");
                Console.Write(" ");
                if (LabelBorder.horizontal == "right" || LabelBorder.horizontal == "both") Console.Write("   ");
                Console.WriteLine();
            }

            // Top Outer Border
            if (outerBorder)
            {
                Console.Write(" ");
                if (LabelBorder.horizontal == "left" || LabelBorder.horizontal == "both") Console.Write("---");
                Console.Write("+");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("---");
                    if (col < cols - 1) Console.Write("-");
                }
                Console.Write("+");
                if (LabelBorder.horizontal == "right" || LabelBorder.horizontal == "both") Console.Write("---");
                Console.Write(" ");
                Console.WriteLine();
            }

            // Body
            for (int row = 0; row < rows; row++)
            {
                if (LabelBorder.horizontal == "left" || LabelBorder.horizontal == "both")
                {
                    Console.Write(" ");
                    if (LabelBorder.horizontalType == "letter")
                    {
                        if (row < letters.Length) Console.Write(" ");
                        string value = "";
                        if (row >= letters.Length)
                            value += letters[row / letters.Length - 1];
                        value += letters[row % letters.Length];
                        Console.Write(value); 
                    }
                    else
                    {
                        if (row < 10) Console.Write(" ");
                        Console.Write(row);
                    }
                }
                Console.Write(" ");
                if (outerBorder) Console.Write("|");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(" {0}", content[row][col]);
                    if (content[row][col].Length == 1) Console.Write(" ");
                    if (col < cols - 1) Console.Write("|");
                }
                if (outerBorder) { Console.Write("|"); }
                Console.Write(" ");
                if (LabelBorder.horizontal == "right" || LabelBorder.horizontal == "both")
                {
                    if (LabelBorder.horizontalType == "letter")
                    {
                        string value = "";
                        if (row >= letters.Length)
                            value += letters[row / letters.Length - 1];
                        value += letters[row % letters.Length];
                        Console.Write(value);
                        if (row < letters.Length) Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(row);
                        if (row < 10) Console.Write(" ");
                    }
                    Console.Write(" ");
                }

                // Horizontal Outer Border
                if (row < rows - 1)
                {
                    Console.WriteLine();
                    Console.Write(" ");
                    if (LabelBorder.horizontal == "left" || LabelBorder.horizontal == "both") Console.Write("---");
                    if (outerBorder) { Console.Write("|"); }
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write("---");
                        if (col < cols - 1) Console.Write("+");
                    }
                    if (outerBorder) { Console.Write("|"); }
                    if (LabelBorder.horizontal == "right" || LabelBorder.horizontal == "both") Console.Write("---");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            // Bottom Outer Border
            if (outerBorder)
            {
                Console.Write(" ");
                if (LabelBorder.horizontal == "left" || LabelBorder.horizontal == "both") Console.Write("---");
                Console.Write("+");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("---");
                    if (col < cols - 1)  Console.Write("-");
                }
                Console.Write("+");
                Console.Write(" ");
                if (LabelBorder.horizontal == "right" || LabelBorder.horizontal == "both") Console.Write("---");
                Console.Write(" ");
                Console.WriteLine();
            }

            // Bottom Label Border
            if (LabelBorder.vertical == "bottom" || LabelBorder.vertical == "both")
            {
                if (LabelBorder.horizontal == "left" || LabelBorder.horizontal == "both") Console.Write("   ");
                Console.Write(" ");
                if (outerBorder) Console.Write("|");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(" ");
                    if (LabelBorder.verticalType == "letter")
                    {
                        string value = "";
                        if (col >= letters.Length)
                            value += letters[col / letters.Length - 1];
                        value += letters[col % letters.Length];
                        Console.Write(value);
                        if (col < letters.Length) Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(col);
                        if (col < 10) Console.Write(" ");
                    }
                    if (col < cols - 1) Console.Write("|");
                }
                if (outerBorder) Console.Write("|");
                Console.Write(" ");
                if (LabelBorder.horizontal == "right" || LabelBorder.horizontal == "both") Console.Write("   ");
                Console.WriteLine();
            }

            Console.WriteLine();
            return;
        }

    }

    public struct LabelBorder
    {
        public static string horizontal = "left";
        public static string horizontalType = "number";
        public static string vertical = "top";
        public static string verticalType = "number";
    }
}
