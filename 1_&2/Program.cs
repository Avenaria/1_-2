using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static bool ver = false;
    static List<int> arr1 = new List<int>();
    static List<int> arr2 = new List<int>();
    static string pole;
    static int move = 0;
    static int draw = 0;
    static bool flip = false;
    static Random r = new Random();
    public static void Main(string[] args)
    {
        pole = string.Empty;
        while (!ver)
        {
            List<int> numerics = arr1.Concat(arr2).ToList();
            Console.WriteLine(string.Format("Ходит {0}", flip == false ? 1 : 2));
            string ss = string.Empty;
            if (!flip)
            {
                ss = Console.ReadLine();
            }
            else
            {
                ss = r.Next(0, 9).ToString();
                if (numerics.Contains(int.Parse(ss)))
                {
                    ss = r.Next(0, 9).ToString();
                    if (numerics.Contains(int.Parse(ss)))
                    {
                        ss = r.Next(0, 9).ToString();
                        if (numerics.Contains(int.Parse(ss)))
                        {
                            ss = r.Next(0, 9).ToString();
                            if (numerics.Contains(int.Parse(ss)))
                            {
                                Console.WriteLine("Компьютер сдается");
                            }
                        }
                    }
                }
            }
            int input = int.Parse(ss);
            switch (input)
            {
                case 0:
                    if (!flip)
                    {
                        arr1.Add(0);
                        pole = WriteSquare(0, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(0);
                        pole = WriteSquare(0, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 1:
                    if (!flip)
                    {
                        arr1.Add(1);
                        pole = WriteSquare(1, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(1);
                        pole = WriteSquare(1, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 2:
                    if (!flip)
                    {
                        arr1.Add(2);
                        pole = WriteSquare(2, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(2);
                        pole = WriteSquare(2, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 3:
                    if (!flip)
                    {
                        arr1.Add(3);
                        pole = WriteSquare(3, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(3);
                        pole = WriteSquare(3, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 4:
                    if (!flip)
                    {
                        arr1.Add(4);
                        pole = WriteSquare(4, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(4);
                        pole = WriteSquare(4, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 5:
                    if (!flip)
                    {
                        arr1.Add(5);
                        pole = WriteSquare(5, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(5);
                        pole = WriteSquare(5, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 6:
                    if (!flip)
                    {
                        arr1.Add(6);
                        pole = WriteSquare(6, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(6);
                        pole = WriteSquare(6, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 7:
                    if (!flip)
                    {
                        arr1.Add(7);
                        pole = WriteSquare(7, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(7);
                        pole = WriteSquare(7, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
                case 8:
                    if (!flip)
                    {
                        arr1.Add(8);
                        pole = WriteSquare(8, "X");
                        Verify(1, arr1.ToArray());
                        flip = !flip;
                    }
                    else
                    {
                        arr2.Add(8);
                        pole = WriteSquare(8, "O");
                        Verify(2, arr2.ToArray());
                        flip = !flip;
                    }
                    break;
            }
            if (draw == 0) draw = 1;
            Draw(pole);
        }
    }
    static void Draw(string str)
    {
        if (str != string.Empty)
        {
            var array = str.ToCharArray();
            int num = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[num]);
                    num++;
                }
                Console.WriteLine();
            }
        }
    }
    static string WriteSquare(int n, string str)
    {
        string stroka = pole;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int point = 3 * i + j;
                if (draw == 0)
                    stroka += '.';
                if (n == point)
                {
                    stroka = stroka.Remove(n, 1);
                    stroka = stroka.Insert(n, str);
                    continue;
                }
            }
        }
        return stroka;
    }
    static void Verify(int player, params int[] x)
    {
        move++;
        int[,] Wins = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        Array.Sort(x);
        x = x.Distinct().ToArray();
        int count = 0;
        for (int i = 0; i < Wins.GetLength(0); i++)
        {
            count = 0;
            for (int j = 0; j < Wins.GetLength(1); j++)
            {
                for (int n = 0; n < x.Length; n++)
                {
                    if (Wins[i, j] == x[n])
                    {
                        count++;
                        if (count == 3)
                        {
                            ver = true;
                            break;
                        }
                    }
                }
            }
        }
        string st = string.Empty;
        if (ver)
        {
            st = string.Format("выиграл {0} игрок", player);
            move = 0;
            arr1.Clear();
            arr2.Clear();
            pole = new string('.', 9);
            draw = 0;
            ver = false;
            flip = player == 2 ? false : true;
        }
        else
        {
            if (move == 9)
            {
                st = "ничья";
                move = 0;
                arr1.Clear();
                arr2.Clear();
                pole = new string('.', 9);
                draw = 0;
            }
        }
        Console.WriteLine(st);
        static void Main(string[] args)
        {
            bool game = true;
            bool player = true;

            string[,] pole = new string[4, 4];
            for (int i = 1; i < pole.GetLength(0); i++)
            {
                for (int j = 1; j < pole.GetLength(1); j++)
                {
                    pole[i, j] = "*";
                }

            }
            ShowPole(pole);

            while (game)
            {
                string pl;
                string symbol;
                if (player) { pl = "1"; symbol = "X"; } else { pl = "2"; symbol = "O"; }
                Console.WriteLine($"Ход игрока {pl}({symbol})");
                Console.Write($"Введите координаты хода через пробел: ");
                string hod = Console.ReadLine();
                string[] coor = hod.Split(' ');
                int x = int.Parse(coor[0]);
                int y = int.Parse(coor[1]);
                if (x > 3 || x < 1 || y > 3 || y < 1) Console.WriteLine($"Неверные координаты");
                else if (pole[x, y] != "*") Console.WriteLine($"Сюда ходить нельзя");
                else
                {
                    pole[x, y] = symbol;
                    player = !player;
                    ShowPole(pole);
                    game = Win(pole);
                    if (!game) Console.Write($"Победил игрок {pl} ");

                }
            }



            Console.WriteLine();
            Console.ReadKey();
        }

        static void ShowPole(string[,] array)
        {
            Console.Clear();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (i == 0) array[i, j] = j.ToString();
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        static bool Win(string[,] array)
        {
            if ((array[1, 1] == "X" && array[1, 2] == "X" && array[1, 3] == "X") || (array[1, 1] == "O" && array[1, 2] == "O" && array[1, 3] == "O")) return false;
            if ((array[2, 1] == "X" && array[2, 2] == "X" && array[2, 3] == "X") || (array[2, 1] == "O" && array[2, 2] == "O" && array[2, 3] == "O")) return false;
            if ((array[3, 1] == "X" && array[3, 2] == "X" && array[3, 3] == "X") || (array[3, 1] == "O" && array[3, 2] == "O" && array[3, 3] == "O")) return false;


            if ((array[1, 1] == "X" && array[2, 1] == "X" && array[3, 1] == "X") || (array[1, 1] == "O" && array[2, 1] == "O" && array[3, 1] == "O")) return false;
            if ((array[1, 2] == "X" && array[2, 2] == "X" && array[3, 2] == "X") || (array[1, 2] == "O" && array[2, 2] == "O" && array[3, 2] == "O")) return false;
            if ((array[1, 3] == "X" && array[2, 3] == "X" && array[3, 3] == "X") || (array[1, 3] == "O" && array[2, 3] == "O" && array[3, 3] == "O")) return false;

            if ((array[1, 1] == "X" && array[2, 2] == "X" && array[3, 3] == "X") || (array[1, 1] == "O" && array[2, 2] == "O" && array[3, 3] == "O")) return false;
            if ((array[3, 1] == "X" && array[2, 2] == "X" && array[1, 3] == "X") || (array[3, 1] == "O" && array[2, 2] == "O" && array[1, 3] == "O")) return false;

            else return true;
        }
    }
}