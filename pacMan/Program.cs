using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pacMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            Random random = new Random();

            bool isPlaying = true ;
            
            bool isAlive = true;

            int pacmanX, pacmanY;
            int pacmanDX = 0, pacmanDY = 1;

            int ghostX, ghostY;
            int ghostDX = 0, ghostDY = -1;

            int allPoint = 0;
            int collectPoint = 0;

            char[,] map = ReadMap("map1", out pacmanX, out pacmanY, out ghostX, out ghostY, ref allPoint);
            
            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine($"Собрано {collectPoint}/{allPoint}");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);
                }

                if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
                {
                    CollectPoints(map, pacmanX, pacmanY, ref collectPoint);

                    Move(map, '@', ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
                }

                if (map[ghostX + ghostDX, ghostY + ghostDY] != '#')
                {
                    Move(map, '$', ref ghostX, ref ghostY, ghostDX, ghostDY);
                }
                else
                {
                    ChangeDirection(random, ref ghostDX, ref ghostDY);
                }

                if (ghostX == pacmanX && ghostY == pacmanY)
                {
                    isAlive = false;
                }

                System.Threading.Thread.Sleep(150);

                FinishGame(collectPoint, allPoint, isPlaying, isAlive);
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;

                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;

                case ConsoleKey.RightArrow:
                    DX = 0; DY = 1;
                    break;

                case ConsoleKey.LeftArrow:
                    DX = 0; DY = -1;
                    break;
            }
        }

        static void ChangeDirection(Random random, ref int DX, ref int DY)
        {
            int ghostDir = random.Next(1, 5);

            switch (ghostDir) 
            {
                case 1:
                    DX = -1; DY = 0;
                    break;

                case 2:
                    DX = 1; DY = 0;
                    break;

                case 3:
                    DX = 0; DY = 1;
                    break;

                case 4:
                    DX = 0; DY = -1;
                    break;
            }
        }

        static void Move(char[,] map, char symbol, ref int x, ref int y, int DX, int DY)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(map[x,y]);

            x += DX;
            y += DY;

            Console.SetCursorPosition(y, x);
            Console.Write(symbol);
        }

        static void CollectPoints(char[,] map, int pacmanX, int pacmanY, ref int collectPoint)
        {
            if (map[pacmanX, pacmanY] == '*')
            {
                collectPoint++;
                map[pacmanX, pacmanY] = ' ';
            }
        }

        static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, out int ghostX, out int ghostY, ref int allPoint)
        {
            pacmanX = 0;
            pacmanY = 0;
            ghostX = 0;
            ghostY = 0;

            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            for (int i = 0; i < map.GetLength(0); i++) 
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i,j] == '@')
                    {
                        pacmanX = i;
                        pacmanY = j;
                        map[i, j] = '*';
                    }

                    else if (map[i,j] == '$')
                    {
                        ghostX = i;
                        ghostY = j;
                        map[i, j] = '*';
                    }

                    else if (map[i, j] == ' ')
                    {
                        map[i, j] = '*';
                        allPoint++;
                    }
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void FinishGame(int collectPoint, int allPoint, bool isPlaying, bool isAlive)
        {
            if (collectPoint == allPoint)
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Ура!!! Вы выйграли!!!");
                Console.ForegroundColor = defaultColor;
                Console.ReadKey();
                isPlaying = false;
            }
            else if (isAlive == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы мертвы!!!");
                Console.ReadKey();
            }
        }
    }
}
