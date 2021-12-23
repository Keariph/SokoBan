﻿using System;
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
            for(int i = 1; i <= countLevels;i++)
            {
                    Console.Clear();
                    levelPath = path + "\\Level " + i + ".txt";
                    ReadMap(levelPath);
                    CreateField();
                    field.WriteMap();
                    field.MovePlayer();
                //Console.WriteLine("1. New game\n2.Choose level\n3.Exit");
            }
        }

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
        
        //public void OpenMenu()
        //{
        //    Console.WriteLine("1. New game\n2.Choose level\n3.Exit");
        //    switch (Console.ReadLine())
        //    {
        //        case 1: 
        //    }
        //}
    }
}
