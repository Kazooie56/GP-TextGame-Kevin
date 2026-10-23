using FirstPlayable_GP2_Kevin;
using System;

// NICK CHANGE: UNUSED
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class TerrainImmuneEnemy : Enemy
    {
        public TerrainImmuneEnemy(int x, int y, int HP) : base(x, y, HP)
        {
            //changes how enemy is drawn
            _icon = '%';
        }

        protected override void Move(int newX, int newY)
        {
            if (moveStall <= 0)
            {
                //checks space enemy tries to move to
                string spaceMovedTo = GameManager.map.CheckSpace(newX, newY, _xPos, _yPos);
                //stops enemies stacking
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {
                    if (EnemyManager.enemies[i]._xPos == newX && EnemyManager.enemies[i]._yPos == newY)
                    {
                        return;
                    }
                }
                //attacks player
                if (GameManager.player.xPos == newX && GameManager.player.yPos == newY)
                {
                    // Using built in random
                    if (random.Next(0, 10) > 0)
                    {
                        GameManager.player.health.TakeDamage(strength);
                    }
                }
                //moves normally if on grass
                else if (spaceMovedTo != "fail")
                {
                    _xPos = newX;
                    _yPos = newY;
                }
            }
            else
            {
                moveStall -= 1;
            }
        }
    }
}
