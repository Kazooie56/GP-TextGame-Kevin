using FirstPlayable_GP2_Kevin;
using System;
using System.Collections.Generic;
using System.Linq;

// NICK CHANGE: Unused
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class GameManager
    {
        // NICK CHANGE: Constants to replace magic numbers
        const int MinWindowWidth = 130;
        const int MinWindowHeight = 30;
        const int EnemyKillScore = 10;

        public const int forestHeal = 3;
        public const int swampDamage = 3;
        public static int Score = 0;

        public static Map map = new Map();
        public static Player player = new Player(0, 0, 100);

        // NICK CHANGE: Everything in this code is static,
        // and the only time instance is used is directly here. so it's unnecessary.

        //private GameManager() { }

        //private static GameManager _instance;
        //public static GameManager Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new GameManager();
        //        }
        //        return _instance;
        //    }
        //}
        public static void RemoveUsedOrDead()
        {
            // NICK CHANGE: Loop backwards with RemoveAt so removals never shift an index we still need
            for (int i = EnemyManager.enemies.Count - 1; i >= 0; i--)
            {
                var enemy = EnemyManager.enemies[i];
                if (!enemy._health.GetIsAlive())
                {
                    map.RedrawSpace(enemy._xPos, enemy._yPos);
                    EnemyManager.enemies.RemoveAt(i);
                    player.lastEnemy = 0;
                    Score += EnemyKillScore;
                    QuestManager.EnemyKilled();         // NICK CHANGE: counts towards quest
                }
            }

            for (int i = ItemManager.items.Count - 1; i >= 0; i--)
            {
                Item item = ItemManager.items[i];
                if (item.hasBeenUsed)
                {
                    map.RedrawSpace(item.xPos, item.yPos);
                    ItemManager.items.RemoveAt(i);
                }
            }
        }

        public static void CheckWindow()
        {
            // NICK CHANGE: cut down on one redraw and removed magic numbers
            bool resized = false;

            if (Console.WindowWidth < MinWindowWidth)
            {
                Console.WindowWidth = MinWindowWidth;
                resized = true;
            }
            if (Console.WindowHeight < MinWindowHeight)
            {
                Console.WindowHeight = MinWindowHeight;
                resized = true;
            }

            if (resized)
            {
                Console.Clear();
                map.DrawMap();
                Draw();
            }
        }
        public static void Draw()
        {
            // NICK CHANGE: Removed the two CheckWindow calls. CheckWindow called Draw and Draw
            // called CheckWindow.
            player.DrawPlayer();
            EnemyManager.boss.DrawEnemy();

            foreach (Item item in ItemManager.items)
            {
                item.Draw();
            }

            foreach (var enemy in EnemyManager.enemies)
            {
                enemy.DrawEnemy();
            }

            // NICK CHANGE: Cursor reset happens once here instead of inside every Item.Draw
            Console.SetCursorPosition(0, 0);
        }
        public static void Move()
        {
            Console.SetCursorPosition(0, 1);
            GameManager.player.MoveInput();
            if (EnemyManager.enemies.Any())
            {
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {
                    EnemyManager.enemies[i].MoveDirection();
                }
            }

            EnemyManager.boss.MoveDirection();
        }
    }
}