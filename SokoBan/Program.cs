using System;
using System.IO;
using System.Collections.Generic;

namespace SokoBan
{
    class Program
    {
        public static Player player;
        public static List<Box> boxes;
        public static List<PlaceForBox> plases;
        public static List<List<string>> map;
        static void Main()
        {
            Console.CursorVisible = false;
            string levelPath = "D:\\Программирование\\Kontur\\SokoBan\\Levels";
            int countLevels = Directory.GetFiles(levelPath, "*", SearchOption.TopDirectoryOnly).Length;
            for(int i = 1; i <= countLevels; i++)
            {
                levelPath = levelPath + "\\Level " + i + ".txt";
                ReadMap(levelPath);
                WriteMap();
                /*while (IsPassed())
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    player.MoveTo(key);
                    Update();
                }*/
            }        
        }

        static void ReadMap(string path)
        {
            string stringMap = File.ReadAllText(path);
            string[] arrey = stringMap.Split("\n");
            int weight = arrey[0].Length;
            int hight  = arrey.Length;
            map = new List<List<string>>();
            for(int y = 0; y<hight; y++)
            {
                map.Add(new List<string>());
                for(int x= 0; x<arrey[y].Length; x++)
                {
                    map[y].Add(Convert.ToString(arrey[y][x]));
                }
              
            }
        }

        static void WriteMap()
        {           
            for(int y = 0; y < map.Count; y++)
            {
                for(int x = 0; x< map[y].Count; x++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    switch (map[y][x])
                    {
                        case "1":
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(1);
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case "2": 
                            Console.Write('x');
                            player = new Player(x, y);
                            break;
                        case "3": 
                            Console.Write('#'); 
                            break;
                        case "4": Console.Write('*'); break;
                    }              
                }
            }           
        }

        static void Update()
        {

        }

        static bool IsPassed()
        {
            return true;
        }
    }
}
