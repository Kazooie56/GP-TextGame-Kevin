using System;
using FirstPlayable_GP2_Kevin;
// NICK CHANGE: Unused
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class Boss : Enemy
    {
        public Boss(int x, int y, int HP) : base(x, y, HP)
        {
            //changes how enemy is drawn
            _icon = 'B';
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
                    moveStall += 2;
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

                // NICK CHANGE: uses shared random from enemy instead of making one each frame
                // The roll is how many extra frames the boss stalls, and the longer the stall, the harder the next hit
                int stallRoll = random.Next(4);
                moveStall += stallRoll;

                // NICK CHANGE: originally, when you checked if movestall was 0, it checked movestall instead of the stallRoll
                // this switch is easier to read and fixes the issue.
                switch (stallRoll)
                {
                    case 0:
                        strength = 3;
                        break;
                    case 1:
                        strength = 5;
                        break;
                    case 2:
                        strength = 10;
                        break;
                    default:
                        strength = 30;
                        break;
                }
            }
            else
            {
                moveStall -= 1;
            }
        }
    }
}
