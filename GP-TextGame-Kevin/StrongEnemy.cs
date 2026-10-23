using FirstPlayable_GP2_Kevin;

// NICK CHANGE: Unused
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class StrongEnemy : Enemy
    {
        public StrongEnemy(int x, int y, int HP) : base(x, y, HP)
        {
            //changes how enemy is drawn
            _icon = '!';
        }
        protected override void SetStrength()
        {
            strength = 5;
        }
        protected override void Move(int newX, int newY)
        {
            //almost the same as base enemy but stalls after moving
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
                    GameManager.player.health.TakeDamage(strength);
                }

                //moves normally if on grass
                else if (spaceMovedTo == "clear")
                {
                    _xPos = newX;
                    _yPos = newY;
                }
                else if (spaceMovedTo == "water")
                {
                    _xPos = newX;
                    _yPos = newY;
                    moveStall+= 2;
                }
                else if (spaceMovedTo == "forest")
                {
                    _xPos = newX;
                    _yPos = newY;
                    _health.Heal(GameManager.forestHeal);
                }
                else if (spaceMovedTo == "swamp")
                {
                    _xPos = newX;
                    _yPos = newY;
                    _health.TakeDamage(GameManager.swampDamage);
                }
                moveStall += 2;
            }
            else
            {
                moveStall -= 1;
            }
        }
    }
}
