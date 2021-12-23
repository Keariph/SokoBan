using System;
using System.Collections.Generic;
using System.Text;

namespace SokoBan
{
    class Field
    {
        public Player player;
        public List<Box> boxes;
        public List<PlaceForBox> plases;
        public List<List<string>> map;


        public Field(Player player, List<Box> boxes, List<PlaceForBox> plases, List<List<string>> map)
        {
            this.player = player;
            this.boxes = boxes;
            this.plases = plases;
            this.map = map;
        }


        public void WriteMap()
        {
            for (int y = 0; y < map.Count; y++)
            {
                for (int x = 0; x < map[y].Count; x++)
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
                            break;
                        case "3":
                            Console.Write('#');                            
                            break;
                        case "4":
                            Console.Write('*');
                            break;
                    }
                }
            }
        }


        public void MovePlayer()
        {
            int x, y, startX, startY;
            while (!IsWin())
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Escape)
                {
                    startX = player.X;
                    startY = player.Y;
                    player.MoveTo(key);
                    x = player.X;
                    y = player.Y;
                    if (map[y][x] == "1")
                    {
                        player.Y = startY;
                        player.X = startX;
                    }
                    else
                    {
                        if (map[y][x] == "3" && !CanBoxMove(key, x, y))
                        {
                            player.Y = startY;
                            player.X = startX;
                        }
                        else
                        {
                            Console.CursorLeft = startX;
                            Console.CursorTop = startY;
                            map[startY][startX] = "0";
                            Console.Write(' ');
                            Console.CursorLeft = player.X;
                            Console.CursorTop = player.Y;
                            map[player.Y][player.X] = "2";
                            Console.Write('x');
                        }
                    }                   
                }
                else return;
            }
        }


        public bool CanBoxMove(ConsoleKeyInfo key, int x,int y)
        {
            
            int startX = player.X;
            int startY = player.Y;
            int i = FindBox(x, y);
            boxes[i].MoveTo(key);
            x = boxes[i].X;
            y = boxes[i].Y;
            if (map[y][x] == "1" || map[y][x] == "3")
            {
                boxes[i].Y = startY;
                boxes[i].X = startX;
                Console.CursorLeft = boxes[i].X;
                Console.CursorTop = boxes[i].Y;
                Console.Write('#');
                return false;
            }
            else
            {
                if(map[y][x] == "4")
                {
                    ClosePlace(x, y);
                }
                Console.CursorLeft = startX;
                Console.CursorTop = startY;
                map[startY][startX] = "0";
                Console.Write(' ');
                Console.CursorLeft = boxes[i].X;
                Console.CursorTop = boxes[i].Y;
                map[boxes[i].Y][boxes[i].X] = "3";
                Console.Write('#');   
                return true;
            }
            
        }


        public int FindBox(int x, int y)
        {
            for(int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].X == x && boxes[i].Y == y)
                    return i;
            }
            return -1;
        }

        public void ClosePlace(int x, int y)
        {
            for (int i = 0; i < plases.Count; i++)
            {
                if (plases[i].X == x && plases[i].Y == y)
                    plases[i].IsOpen = false;
            }
        }

        public bool IsWin()
        {
            int closePlase = 0;
            for (int i = 0; i < plases.Count; i++)
            {
               if(plases[i].IsOpen == false)
                {
                    closePlase++;
                }
            }
            if (closePlase == plases.Count)
            {
                return true;
            }
            else return false;
        }
    }
}
