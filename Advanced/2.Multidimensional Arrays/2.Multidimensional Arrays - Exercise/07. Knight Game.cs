using System.Data;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string figures = Console.ReadLine();
                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {
                        board[row, col] = figures[col];
                    }
                }
            }


            int currentRow = 0;
            int currentCol = 0;
            int knightsMoved = 0;

            for (int row = 0; row < size; row++)
            {

                for (int col = 0; col < size; col++)
                {
                    //bool isBoard = row - 1 >= 0
                    //                && row - 2 >= 0
                    //                && row + 1 <= size - 1
                    //                && row + 2 <= size - 1
                    //                && col - 1 >= 0
                    //                && col - 2 >= 0
                    //                && col + 1 <= size - 1
                    //                && col + 2 <= size - 1;

                    if (board[row, col] == 'K')
                    {
                        currentRow = row;
                        currentCol = col;

                        if (currentCol - 1 >= 0
                                && currentCol - 1 <= size - 1
                                && currentCol + 1 >= 0
                                && currentCol + 1 >= 0
                                && currentCol + 1 <= size - 1
                                && currentRow - 1 >= 0
                                && currentRow - 1 <= size - 1
                                && currentRow + 1 >= 0
                                && currentRow + 1 <= size - 1
                                && currentCol - 2 >= 0
                                && currentCol - 2 <= size - 1
                                && currentCol + 2 >= 0
                                && currentCol + 2 <= size - 1
                                && currentRow - 2 >= 0
                                && currentRow - 2 <= size - 1
                                && currentRow + 2 >= 0
                                && currentRow + 2 <= size - 1)
                        {
                            currentRow++;
                            currentCol += 2;

                            if (board[currentRow,currentCol] == 'K')
                            {
                                board[row, col] = (char)0;
                                knightsMoved++;
                            }
                        }

                    }




                    //if (isBoard) 
                    //{
                    //    if (board[row, col] == 'K')
                    //    {
                    //        if (board[row + 1, col + 2] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //        else if (board[row + 1, col - 2] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //        else if (board[row - 1, col + 2] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //        else if (board[row - 1, col - 2] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //        else if (board[row + 2, col - 1] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //        else if (board[row + 2, col + 1] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //        else if (board[row - 2, col + 1] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //        else if (board[row - 2, col - 1] == 'K')
                    //        {
                    //            board[row, col] = '0';
                    //            knightsMoved++;

                    //        }
                    //    }

                    //knightsMoved = MoveKnight(board, knightsMoved, row, col);
                }
            }
            Console.WriteLine(knightsMoved);
        }

        
        }



}

