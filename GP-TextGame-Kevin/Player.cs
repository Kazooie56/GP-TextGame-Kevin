using GP_TextGame_Kevin;
using System;
using System.Linq;
// NICK CHANGES: Unused
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Player
    {
        public int lastEnemyHP = 5;
        public int lastEnemyStrength = 1;
        public int lastEnemy = 0;
        public int xPos;
        public int yPos;
        public Health health;
        public int moveStall = 0;
        public int strength { get; private set; }
        public Player(int x, int y, int HP)
        {
            xPos = x;
            yPos = y;
            health = new Health(HP,0);
            strength = 1;
        }

        //handles movement input
        public void MoveInput()
        {
            if (moveStall <= 0)
            {
                ConsoleKeyInfo moveInput = Console.ReadKey(true);

                if (moveInput.Key == ConsoleKey.W)
                {
                    Move(xPos, yPos - 1);
                }
                else if (moveInput.Key == ConsoleKey.S)
                {
                    Move( xPos, yPos + 1);
                }
                else if (moveInput.Key == ConsoleKey.A)
                {
                    Move(xPos - 1, yPos);
                }
                else if (moveInput.Key == ConsoleKey.D)
                {
                    Move(xPos + 1, yPos);
                }
            }
            else
            {
                moveStall -= 1;
            }

        }

        //actually moves player or attacks if enemy is in the way
        private void Move(int newX, int newY)
        {
            bool didNotAct = true;
            if (EnemyManager.enemies.Any())
            {
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {
                    if (EnemyManager.enemies[i]._xPos == newX && EnemyManager.enemies[i]._yPos == newY)
                    {

                        EnemyManager.enemies[i]._health.TakeDamage(strength);
                        didNotAct = false;
                        lastEnemy = i+1;
                    }
                }
            }
            
            if (EnemyManager.boss._xPos == newX && EnemyManager.boss._yPos == newY)
            {
                EnemyManager.boss._health.TakeDamage(strength);
                didNotAct = false;
                lastEnemy = 0;
            }

            //sets enemy stats in hud
            if (lastEnemy == 0)
            {
                lastEnemyHP = EnemyManager.boss._health._health;
                lastEnemyStrength = EnemyManager.boss.strength;
            }
            else
            {
                lastEnemyHP = EnemyManager.enemies[lastEnemy-1]._health._health;
                lastEnemyStrength = EnemyManager.enemies[lastEnemy-1].strength;
            }
            if (ItemManager.items.Any())
            {
                for (int i = 0; i < ItemManager.items.Count; i++)
                {
                    if (ItemManager.items[i].xPos == newX && ItemManager.items[i].yPos == newY)
                    {
                        ItemManager.items[i].Use();
                        didNotAct = false;
                    }
                }
            }
            if (didNotAct)
            {
                string spaceMovedTo = GameManager.map.CheckSpace(newX, newY, xPos, yPos);
                if (spaceMovedTo == "clear")
                {
                    xPos = newX;
                    yPos = newY;
                }
                else if (spaceMovedTo == "water")
                {
                    xPos = newX;
                    yPos = newY;
                    moveStall++;
                }
                else if (spaceMovedTo == "forest")
                {
                    xPos = newX;
                    yPos = newY;
                    // heal player and add to quest
                    int healed = health.Heal(GameManager.forestHeal);
                    QuestManager.PlayerHealed(healed);
                }
                else if (spaceMovedTo == "swamp")
                {
                    xPos = newX;
                    yPos = newY;
                    health.TakeDamage(GameManager.swampDamage);
                }
            }
        }

        public void DrawPlayer()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(xPos + 5, yPos + 5);
            Console.Write("*");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }

        // NICK CHANGE: Added Reset();
        // Used to reset the players stats back to the beginning
        // Also resets the enemy HUD stats and moveStall which weren't being reset at the end of a game
        public void Reset(int x, int y)
        {
            xPos = 0;
            yPos = 0;
            health.FullHeal();
            moveStall = 0;
            lastEnemyHP = 5;
            lastEnemyStrength = 1;
            lastEnemy = 0;
        }
    }
}
