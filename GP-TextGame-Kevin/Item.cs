using System;
// NICK CHANGE: Added this to use the map offset.
using FirstPlayable_GP2_Kevin;
// NICK CHANGE: Unused
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal abstract class Item
    {
        public int xPos;
        public int yPos;
        protected char icon = 'T';
        protected ConsoleColor color = ConsoleColor.Black;
        public bool hasBeenUsed = false;
        public Item(int x, int y)
        {
            xPos = x;
            yPos = y;
        }
        public virtual void Use()
        {
            hasBeenUsed = true;
        }
        public void Draw()
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(xPos + Map.OffsetX, yPos + Map.OffsetY);
            Console.Write(icon);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
