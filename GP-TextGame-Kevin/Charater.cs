// NICK CHANGE: Completely unused, making it commented out makes it easier to realize it doesn't do anything.

//using FirstPlayable_GP2_Kevin;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Design;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GP_TextGame_Kevin
//{
//    internal class Charater
//    {

//        public int _xPos { get; private set; }
//        public int _yPos { get; private set; }
//        protected Health _health;
//        public Charater(int HP, int x, int y)
//        {
//            _xPos = x;
//            _yPos = y;
//            _health = new Health(HP);
//        }
//        public virtual void Move(Player player, List<Enemy> enemies, Map map, int newX, int newY)
//        {
//            //checks space enemy tries to move to
//            string spaceMovedTo = map.CheakSpace(newX, newY);
//            //stops enemies stacking
//            for (int i = 0; i < enemies.Count; i++)
//            {
//                if (enemies[i]._xPos == newX && enemies[i]._yPos == newY)
//                {

//                    return;
//                }
//            }
//            //attacks player
//            if (player._xPos == newX && player._yPos == newY)
//            {
//                player._health.TakeDamage(1);
//            }
//            //moves normally if on grass
//            else if (spaceMovedTo == "clear")
//            {
//                _xPos = newX;
//                _yPos = newY;
//            }
//        }



//    }
//}
