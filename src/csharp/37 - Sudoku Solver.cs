using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    class Program
    {
        static bool IsValidSudoku(char[][] board)
        {
            char[] cache = new char[9];

            bool IsUnique(char[] chars)
            {
                var set = new HashSet<char>(9);
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
                for (int row = 0; row < 9; row++)
                {
                    cache[row] = board[row][column];
                }
                return IsUnique(cache);
            }
            bool CheckBox(int row, int column)
            {
                var index = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        cache[index++] = board[row + i][column + j];
                    }
                }
                return IsUnique(cache);
            }

            for (int i = 0; i < 9; i++)
            {
                if (!CheckRow(i) || !CheckColumn(i))
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    if (!CheckBox(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void SolveSudoku(char[][] board)
        {
            HashSet<char> Candidates(int row, int column)
            {
                if (board[row][column] != '.')
                {
                    throw new ArgumentException($"position ({row},{column}) not empty.");
                    //return new List<char>() { board[row][column] };
                }
                var set = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                // remove item in row
                for (int i = 0; i < 9; i++)
                {
                    set.Remove(board[row][i]);
                }
                // remove item in column
                for (int i = 0; i < 9; i++)
                {
                    set.Remove(board[i][column]);
                }
                // remove item in box
                var (top, left) = (row / 3 * 3, column / 3 * 3);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        set.Remove(board[top + i][left + j]);
                    }
                }
                return set;
            }

            bool FillFixed()
            {
                var changed = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i][j] == '.')
                        {
                            var candidates = Candidates(i, j);
                            if (candidates.Count == 1)
                            {
                                board[i][j] = candidates.First();
                                changed = true;
                            }
                        }
                    }
                }
                return changed;
            }

            bool Solve()
            {
                var (row, column) = (-1, -1);
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i][j] == '.')
                        {
                            (row, column) = (i, j);
                        }
                    }
                }
                if (row == -1)
                {
                    return true;
                }
                var candidates = Candidates(row, column);
                if (candidates.Count == 0)
                {
                    return false;
                }
                foreach (var c in candidates)
                {
                    board[row][column] = c;
                    if (Solve())
                    {
                        return true;
                    }
                }
                board[row][column] = '.';
                return false;
            }

            while (FillFixed()) { }

            Solve();

        }

        static void PrettyPrint(char[][] board)
        {
            var str = board.Select(row => string.Join(',', row))
                .Aggregate((r1, r2) => r1 + "\n" + r2);
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var board = new char[][]
            {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };
            PrettyPrint(board);
            SolveSudoku(board);
            Console.WriteLine("============");
            PrettyPrint(board);
        }
    }
}
