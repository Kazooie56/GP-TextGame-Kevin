using System;
using System.Collections.Generic;
using System.IO;
using GP_TextGame_Kevin;
// NICK CHANGE: Unused
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Cryptography.X509Certificates;
//using System.Diagnostics.Eventing.Reader;
//using System.Runtime.InteropServices;

namespace FirstPlayable_GP2_Kevin
{
    internal class Map
    {
        public const int OffsetX = 5;
        public const int OffsetY = 5;

        private Dictionary<char, ConsoleColor> backgroundColors = new Dictionary<char, ConsoleColor>()
        {
            {'`',ConsoleColor.Green },
            {'~', ConsoleColor.DarkBlue },
            {'^', ConsoleColor.DarkGray },
            {'H',ConsoleColor.DarkGreen },
            {'@',ConsoleColor.DarkMagenta },
            {'#' , ConsoleColor.White},
        };
        // NICK CHANGE: removed pointless { get }
        public string[] _map = File.ReadAllLines(@"MapText.txt");

        public void DrawMap()
        {
            GameManager.CheckWindow();
            for (int i = 0; i < _map.Length; i++)
            {
                for (int j = 0; j < _map[i].Length; j++)
                {
                    // RedrawSpace does the 4 lines of code for us,
                    // plus it already includes map offsets,
                    RedrawSpace(j, i);
                }
            }
        }
        public string CheckSpace(int x, int y,int oldX, int oldY)
        {
            // NICK CHANGE: instead of the many if statements,
            // turned the ones that return "fail" into a single if statement
            // turned the ones that check for a space into a switch

            if (y < 0 || y >= _map.Length || x < 0 || x >= _map[y].Length)
            {
                return "fail";
            }

            string spaceResult;
            switch (_map[y][x])
            {
                // for each space on the MapText.txt
                case '`':
                    spaceResult = "clear";
                    break;
                case '~':
                    spaceResult = "water";
                    break;
                case 'H':
                    spaceResult = "forest";
                    break;
                case '@':
                    spaceResult = "swamp";
                    break;
                case '^':
                    spaceResult = "mountain";
                    break;
                default:
                    spaceResult = "fail";
                    break;
            }

            // if we can walk on said space
            if (spaceResult != "fail")
            {
                // NICK CHANGE: Removes the dupe shit
                RedrawSpace(oldX, oldY);
            }
            return spaceResult;
        }

        
        public void RedrawSpace(int x, int y)
        {
            // replaced the 5 with the map Offset
            Console.SetCursorPosition(x + OffsetX, y + OffsetY);
            Console.BackgroundColor = backgroundColors[_map[y][x]];
            Console.Write(_map[y][x]);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
