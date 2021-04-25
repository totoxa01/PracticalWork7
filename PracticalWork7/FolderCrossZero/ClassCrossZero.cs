using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalWork7.FolderCrossZero
{
    class ClassCrossZero
    {
        //размер поля
        static int SIZE_X = 5;
        static int SIZE_Y = 5;
        
        //выигрышная длина
        static int DOTS_TO_WIN = 4;

        //массив для поля
        static char[,] field = new char[SIZE_Y, SIZE_X];

        //ход пользователя
        static char PLAYER_DOT = 'X';

        //ход ИИ
        static char AI_DOT = 'O';

        //свободное поле
        static char EMPTY_DOT = '.';

        static Random random = new Random();


        /// <summary>
        /// расстановка
        /// </summary>
        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        /// <summary>
        /// печать поля
        /// </summary>
        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("___________");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------");
        }

        /// <summary>
        /// устанавливает символ в позицию
        /// </summary>
        /// <param name="y">координата y</param>
        /// <param name="x">координата x</param>
        /// <param name="sym">символ</param>
        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        /// <summary>
        /// проверка попадания в диапазон
        /// </summary>
        /// <param name="y">координата y</param>
        /// <param name="x">координата x</param>
        /// <returns></returns>
        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        /// <summary>
        /// информация о заполненности поля
        /// </summary>
        /// <returns></returns>
        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ход человека
        /// </summary>
        private static void playerMove()
        {
            int x, y;
            do
            {
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_Y);
                Console.WriteLine("Координат по столбцу ");                
                x = Int32.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Координат по строке ");
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        /// <summary>
        /// ход ИИ
        /// анализ полей
        /// блокировка ходов пользователя
        /// случайный ход
        /// </summary>
        private static void AiMove()
        {
            int x, y;
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (j + DOTS_TO_WIN <= SIZE_X)
                    {
                        if (CheckLineHorisont(i, j, AI_DOT) == DOTS_TO_WIN - 1)
                        {
                            if (MoveAiLineHorisont(i, j, AI_DOT)) return;
                        }

                        if (i - DOTS_TO_WIN > -2)
                        {
                            if (CheckDiaUp(i, j, AI_DOT) == DOTS_TO_WIN - 1)
                            {
                                if (MoveAiDiaUp(i, j, AI_DOT)) return;
                            }
                        }
                        if (i + DOTS_TO_WIN <= SIZE_Y)
                        {
                            if (CheckDiaDown(i, j, AI_DOT) == DOTS_TO_WIN - 1)
                            {
                                if (MoveAiDiaDown(i, j, AI_DOT)) return;
                            }
                        }

                    }
                    if (i + DOTS_TO_WIN <= SIZE_Y)
                    {
                        if (CheckLineVertical(i, j, AI_DOT) == DOTS_TO_WIN - 1)
                        {
                            if (MoveAiLineVertical(i, j, AI_DOT)) return;
                        }
                    }
                }
            }
            
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (j + DOTS_TO_WIN <= SIZE_X)
                    {
                        if (CheckLineHorisont(i, j, PLAYER_DOT) == DOTS_TO_WIN - 1)
                        {
                            if (MoveAiLineHorisont(i, j, AI_DOT)) return;
                        }

                        if (i - DOTS_TO_WIN > -2)
                        {
                            if (CheckDiaUp(i, j, PLAYER_DOT) == DOTS_TO_WIN - 1)
                            {
                                if (MoveAiDiaUp(i, j, AI_DOT)) return;
                            }
                        }
                        if (i + DOTS_TO_WIN <= SIZE_Y)
                        {
                            if (CheckDiaDown(i, j, PLAYER_DOT) == DOTS_TO_WIN - 1)
                            {
                                if (MoveAiDiaDown(i, j, AI_DOT)) return;
                            }
                        }
                    }
                    if (i + DOTS_TO_WIN <= SIZE_Y)
                    {
                        if (CheckLineVertical(i, j, PLAYER_DOT) == DOTS_TO_WIN - 1)
                        {
                            if (MoveAiLineVertical(i, j, AI_DOT)) return;
                        }
                    }
                }
            }
            
            do
            {
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);

        }

       /// <summary>
       /// ход ИИ по горизонтали
       /// </summary>
       /// <param name="v"></param>
       /// <param name="h"></param>
       /// <param name="dot"></param>
       /// <returns></returns>
        private static bool MoveAiLineHorisont(int v, int h, char dot)
        {
            for (int j = h; j < DOTS_TO_WIN; j++)
            {
                if ((field[v, j] == EMPTY_DOT))
                {
                    field[v, j] = dot;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ход ИИ по вертикали
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static bool MoveAiLineVertical(int v, int h, char dot)
        {
            for (int i = v; i < DOTS_TO_WIN; i++)
            {
                if ((field[i, h] == EMPTY_DOT))
                {
                    field[i, h] = dot;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// проверка заполнения всей линии по диагонале вверх
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static bool MoveAiDiaUp(int v, int h, char dot)
        {
            for (int i = 0, j = 0; j < DOTS_TO_WIN; i--, j++)
            {
                if ((field[v + i, h + j] == EMPTY_DOT))
                {
                    field[v + i, h + j] = dot;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// проверка заполнения всей линии по диагонале вниз
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static bool MoveAiDiaDown(int v, int h, char dot)
        {

            for (int i = 0; i < DOTS_TO_WIN; i++)
            {
                if ((field[i + v, i + h] == EMPTY_DOT))
                {
                    field[i + v, i + h] = dot;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// проверка победы
        /// </summary>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static bool CheckWin(char dot)
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (j + DOTS_TO_WIN <= SIZE_X)
                    {
                        if (CheckLineHorisont(i, j, dot) >= DOTS_TO_WIN) return true;

                        if (i - DOTS_TO_WIN > -2)
                        {
                            if (CheckDiaUp(i, j, dot) >= DOTS_TO_WIN) return true;
                        }
                        if (i + DOTS_TO_WIN <= SIZE_Y)
                        {
                            if (CheckDiaDown(i, j, dot) >= DOTS_TO_WIN) return true;
                        }
                    }
                    if (i + DOTS_TO_WIN <= SIZE_Y)
                    {
                        if (CheckLineVertical(i, j, dot) >= DOTS_TO_WIN) return true;
                    }
                }
            }
            return false;                        
        }

        /// <summary>
        /// проверка заполнения всей линии по диагонале вверх
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static int CheckDiaUp(int v, int h, char dot)
        {
            int count = 0;
            for (int i = 0, j = 0; j < DOTS_TO_WIN; i--, j++)
            {
                if ((field[v + i, h + j] == dot)) count++;
            }
            return count;
        }

        /// <summary>
        /// проверка заполнения всей линии по диагонале вниз
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static int CheckDiaDown(int v, int h, char dot)
        {
            int count = 0;
            for (int i = 0; i < DOTS_TO_WIN; i++)
            {
                if ((field[i + v, i + h] == dot)) count++;
            }
            return count;
        }

        /// <summary>
        /// проверка заполнения всей линии по горизонтали
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static int CheckLineHorisont(int v, int h, char dot)
        {
            int count = 0;
            for (int j = h; j < DOTS_TO_WIN + h; j++)
            {
                if ((field[v, j] == dot)) count++;
            }
            return count;
        }

        /// <summary>
        /// проверка заполнения всей линии по вертикале
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        /// <param name="dot"></param>
        /// <returns></returns>
        private static int CheckLineVertical(int v, int h, char dot)
        {
            int count = 0;
            for (int i = v; i < DOTS_TO_WIN + v; i++)
            {
                if ((field[i, h] == dot)) count++;
            }
            return count;
        }

        /// <summary>
        /// рабочий метод
        /// </summary>
        public static void WorkMethod()
        {
            InitField();
            PrintField();
            do
            {
                playerMove();
                Console.WriteLine("Ваш ход на поле");
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                AiMove();
                Console.WriteLine("Ход Компа на поле");
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
            Console.WriteLine("!Конец игры!");
        }
    }
}
