using GP_TextGame_Kevin;
using System;

// NICK CHANGE: UNUSED
//using System.Collections.Generic;
//using System.ComponentModel.Design;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Enemy
    {
        // NICK CHANGE: Hit chance was a bare 0 and 10 in Move. Enemies miss 1 time in 10.
        const int MissOneIn = 10;

        public int _xPos;
        public int _yPos;
        public Health _health;
        public int moveStall = 0;
        public int strength;
        public char _icon = 'X';
        protected int _sightRange = 10;

        // NICK CHANGE: making random protected static
        // fixes the LostEnemies from all moving the same direction each "turn"
        // also puts the random logic as one line to save us from making it each enemy type
        protected static Random random = new Random();

        public Enemy(int x, int y, int HP)
        {
            _xPos = x;
            _yPos = y;
            _health = new Health(HP,0);
            SetStrength();
        }

        // NICK CHANGE: Replaces the hand-written reset in EnemyManager.BossSet.
        // Virtual so Boss can reset its own power and speed (confirm with Boss.cs)
        public virtual void Reset(int x, int y)
        {
            _health.FullHeal();
            _xPos = x;
            _yPos = y;
            moveStall = 0;
            SetStrength();
        }

        protected virtual void SetStrength()
        {
            strength = 1;
        }

        //checks if the player is within 10 spaces in all directions
        private bool PlayerIsClose()
        {
            // NICK CHANGE: y was written three times and that meant enemies had infinite range to the right of them
            if (GameManager.player.xPos <= _xPos + _sightRange // this one here
                && GameManager.player.xPos >= _xPos - _sightRange 
                && GameManager.player.yPos <= _yPos + _sightRange 
                && GameManager.player.yPos >= _yPos - _sightRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //determines how enemy will move
        public virtual void MoveDirection()
        {
            // instead of asking if PlayerIsClose 4 times, this asks it once then moves on
            if (!PlayerIsClose())
            {
                return;
            }

            int playerX = GameManager.player.xPos;
            int playerY = GameManager.player.yPos;

            int stepX = 0;
            if (_xPos < playerX) stepX = 1;
            else if (_xPos > playerX) stepX = -1;

            int stepY = 0;
            if (_yPos < playerY) stepY = 1;
            else if (_yPos > playerY) stepY = -1;

            bool xFirst = random.Next(2) == 0;

            if (xFirst)
            {
                if (stepX != 0) Move(_xPos + stepX, _yPos);
                else if (stepY != 0) Move(_xPos, _yPos + stepY);
            }
            else
            {
                if (stepY != 0) Move(_xPos, _yPos + stepY);
                else if (stepX != 0) Move(_xPos + stepX, _yPos);
            }
        }
        //will move enemy or attack if player is in the way
        protected virtual void Move(int newX, int newY)
        {
            // NICK CHANGE: early return for the stall case so the rest isn't indented inside an if
            if (moveStall > 0)
            {
                moveStall--;
                return;
            }

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
                //enemies have a chance to miss
                if (random.Next(0, MissOneIn) > 0)
                {
                    GameManager.player.health.TakeDamage(strength);
                }
                return;
            }


            // NICK CHANGE: THE position was assigned in 4 else ifs with multiple lines,
            // this shrinks it down to a switch with one line each

            //moves normally if on grass
            switch (spaceMovedTo)
            {
                case "clear":
                    MoveTo(newX, newY);
                    break;
                case "water":
                    MoveTo(newX, newY);
                    moveStall++;
                    break;
                case "forest":
                    MoveTo(newX, newY);
                    _health.Heal(GameManager.forestHeal);
                    break;
                case "swamp":
                    MoveTo(newX, newY);
                    _health.TakeDamage(GameManager.swampDamage);
                    break;
                default:
                    // mountain and fail: the enemy doesn't move
                    break;
            }
        }

        private void MoveTo(int newX, int newY)
        {
            _xPos = newX;
            _yPos = newY;
        }

        public  void DrawEnemy()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_xPos + Map.OffsetX, _yPos + Map.OffsetY);
            Console.Write(_icon);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}

