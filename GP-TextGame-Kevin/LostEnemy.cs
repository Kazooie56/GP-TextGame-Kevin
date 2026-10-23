using FirstPlayable_GP2_Kevin;
// NICK CHANGE: Unused
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class LostEnemy : Enemy
    {
        public LostEnemy(int x, int y, int HP) : base(x, y, HP)
        {
            //changes how enemy is drawn
            _icon = '?';
        }

        // NICK CHANGE: uses shared random from enemy instead of making one each frame
        // also made this a switch instead of 4 if/else
        public override void MoveDirection()
        {
            switch (random.Next(4))
            {
                case 0:
                    Move(_xPos, _yPos + 1);
                    break;
                case 1:
                    Move(_xPos, _yPos - 1);
                    break;
                case 2:
                    Move(_xPos + 1, _yPos);
                    break;
                default:
                    Move(_xPos - 1, _yPos);
                    break;
            }
        }
    }
}