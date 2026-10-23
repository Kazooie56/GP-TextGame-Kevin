using FirstPlayable_GP2_Kevin;
using System.Collections.Generic;
// NICK CHANGE: Unused
//using System;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal static class EnemyManager
    {
        // NICK CHANGE: Boss spawn values in one place instead of repeated
        const int BossStartX = 99;
        const int BossStartY = 21;
        const int BossHealth = 30;

        public static Enemy boss = new Boss(BossStartX, BossStartY, BossHealth);
        public static List<Enemy> enemies = new List<Enemy>();
        public static void BossSet()
        {
            // NICK CHANGE: Enemy.Reset also clears moveStall and strength, which the old version missed
            boss.Reset(BossStartX, BossStartY);
        }
        public static void SpawnEnemies()
        {
            // NICK CHANGE: no need to write EnemyManager.enemies while we're inside EnemyManager
            enemies.Clear();
            enemies.Add(new Enemy(4, 4, 3));
            enemies.Add(new LostEnemy(2, 14, 3));
            enemies.Add(new Enemy(21, 0, 3));
            enemies.Add(new Enemy(31, 1, 3));
            enemies.Add(new StrongEnemy(14, 16, 5));
            enemies.Add(new TerrainImmuneEnemy(13, 14, 3));
            enemies.Add(new TerrainImmuneEnemy(15, 14, 3));
            enemies.Add(new TerrainImmuneEnemy(19, 17, 3));
            enemies.Add(new TerrainImmuneEnemy(8, 16, 3));
            enemies.Add(new Enemy(19, 10, 5));
            enemies.Add(new TerrainImmuneEnemy(20, 2, 3));
            enemies.Add(new TerrainImmuneEnemy(27, 2, 3));
            enemies.Add(new TerrainImmuneEnemy(25, 8, 3));
            enemies.Add(new TerrainImmuneEnemy(34, 8, 3));
            enemies.Add(new StrongEnemy(33, 15, 3));
            enemies.Add(new Enemy(26, 16, 5));
            enemies.Add(new Enemy(19, 21, 5));
            enemies.Add(new Enemy(21, 21, 5));
            enemies.Add(new LostEnemy(29, 16, 3));
            enemies.Add(new LostEnemy(33, 12, 3));
            enemies.Add(new LostEnemy(41, 20, 3));
            enemies.Add(new Enemy(40, 22, 5));
            enemies.Add(new Enemy(42, 22, 5));
            enemies.Add(new TerrainImmuneEnemy(57, 19, 3));
            enemies.Add(new StrongEnemy(53, 19, 3));
            // NICK CHANGE: Dupe enemy from line 46
            //EnemyManager.enemies.Add(new TerrainImmuneEnemy(57, 19, 3));
            enemies.Add(new Enemy(66, 19, 5));
            enemies.Add(new TerrainImmuneEnemy(47, 6, 3));
            enemies.Add(new Enemy(47, 0, 5));
            enemies.Add(new TerrainImmuneEnemy(58, 4, 3));
            enemies.Add(new StrongEnemy(58, 5, 5));
            enemies.Add(new Enemy(58, 6, 5));
            enemies.Add(new StrongEnemy(43, 2, 5));
            enemies.Add(new LostEnemy(58, 14, 3));
            enemies.Add(new StrongEnemy(56, 12, 5));
            enemies.Add(new StrongEnemy(59, 11, 5));
            enemies.Add(new StrongEnemy(80, 7, 5));
            enemies.Add(new Enemy(85, 4, 5));
            enemies.Add(new Enemy(79, 4, 5));
            enemies.Add(new TerrainImmuneEnemy(77, 7, 3));
            enemies.Add(new TerrainImmuneEnemy(79, 21, 3));
            enemies.Add(new StrongEnemy(79, 19, 5));
            enemies.Add(new Enemy(73, 18, 5));
            enemies.Add(new Enemy(73, 23, 5));
            enemies.Add(new Enemy(79, 23, 5));
        }
    }
}