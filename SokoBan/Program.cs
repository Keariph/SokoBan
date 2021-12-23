using System;
using System.IO;
using System.Collections.Generic;

namespace SokoBan
{
    class Program
    {
        public static string path = "D:\\Программирование\\Kontur\\SokoBan\\Levels";
        public static List<List<string>> map;
        public static Field field;
        public static Player player;


        static void Main()
        {
            Console.CursorVisible = false;
            string levelPath = path;
            int countLevels = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
            int choice = 0;
            while (true)
            {
                choice = SelectMainMenu(countLevels);
                if (choice != -1)
                {
                    for (int i = choice; i <= countLevels; i++)
                    {
                        Console.Clear();
                        levelPath = path + "\\Level " + i + ".txt";
                        ReadMap(levelPath);
                        CreateField();
                        field.WriteMap();
                        field.MovePlayer();
                        Console.Clear();
                        Console.WriteLine("1. Back to menu\n2. Next level");
                        if(Console.ReadLine() == "1")
                        {
                            break;
                        }
                    }
                }
                else return;
            }
        }

        /**
         * 
         */
        static void ReadMap(string path)
        {
            string stringMap = File.ReadAllText(path);
            string[] arrey = stringMap.Split("\n");
            map = new List<List<string>>();
            for(int y = 0; y < arrey.Length; y++)
            {
                map.Add(new List<string>());
                for(int x= 0; x < arrey[y].Length; x++)
                {
                    map[y].Add(Convert.ToString(arrey[y][x]));
                }          
            }
        }

        static void CreateField()
        {
            List<Box> boxes = new List<Box>();
            List<PlaceForBox> plases = new List<PlaceForBox>();
            for (int y = 0; y < map.Count; y++)
            {
                for (int x = 0; x < map[y].Count; x++)
                {
                    switch (map[y][x])
                    {
                        case "2": player = new Player(x, y); break;
                        case "3": boxes.Add(new Box(x, y)); break;
                        case "4": plases.Add(new PlaceForBox(x, y, true)); break;
                    }
                }
            }
            field = new Field(player, boxes, plases, map);
        }

        public static int SelectMainMenu(int countLevels)
        {
            int choice = 0;
            while (choice == 0)
            {
                Console.Clear();
                Console.WriteLine("1. New game\n2. Choice level\n3. Exit");
                switch (Console.ReadLine())
                {
                    case "1": return 1;
                    case "2":
                        for (int i = 1; i <= countLevels; i++)
                        {
                            Console.WriteLine(i + ". Level " + i);
                        }
                        return Convert.ToInt32(Console.ReadLine());
                    case "3": return -1;
                    case null:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
            return -1;
        }
    }
}
