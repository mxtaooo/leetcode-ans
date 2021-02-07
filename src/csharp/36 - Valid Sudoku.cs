using System;
using System.Collections.Generic;

namespace CSharpConsoleApp
{
    class Program
    {
        static bool IsValidSudoku(char[][] board)
        {
            var set = new HashSet<char>(9);
            char[] cache = new char[9];

            bool IsUnique(char[]? chars)
            {
                chars ??= cache;
                set.Clear();
                foreach (var c in chars)
                {
                    if (c != '.')
                    {
                        if (set.Contains(c))
                        {
                            return false;
                        }
                        else
                        {
                            set.Add(c);
                        }
                    }
                }
                return true;
            }

            bool CheckRow(int row)
            {
                return IsUnique(board[row]);
            }

            bool CheckColumn(int column)
            {
                for (int row = 0; row < 10; row++)
                {

                }
                return IsUnique(cache);
            }
            bool CheckBox(int left, int top)
            {

            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
