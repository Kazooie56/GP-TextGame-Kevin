using System;

namespace GP_TextGame_Kevin
{
    internal static class QuestManager
    {
        // variables instead of magic numbers
        const int HealGoal = 300;
        const int QuestRow = 2; // rows 0-1 are the HUD and input, the map starts at row 5

        // the three quests
        // each quest holds a string which has the condition and a goal which is an int.
        static Quest healQuest = new Quest($"Heal {HealGoal} damage", HealGoal);
        static Quest killQuest = new Quest("Kill all minor enemies", 1);
        static Quest bossQuest = new Quest("Defeat the boss", 1);

        // quest[0] = healQuest. Made an array so it can loop through each one in Program
        static Quest[] quests = { healQuest, killQuest, bossQuest };

        // call after SpawnEnemies so the kill goal matches the enemy count
        public static void Reset()
        {
            healQuest.Reset(HealGoal);
            killQuest.Reset(EnemyManager.enemies.Count);
            bossQuest.Reset(1);
        }

        // These next three scripts all allow other scripts to incrementally add progress to each example
        // PlayerHealed runs for forest healing and Heal spaces.
        public static void PlayerHealed(int amount)
        { 
            healQuest.AddProgress(amount);
        }
        public static void EnemyKilled()
        {
            killQuest.AddProgress(1);
        }

        public static void Update()
        {
            if (!EnemyManager.boss._health.GetIsAlive() && GameManager.player.health.GetIsAlive())
            {
                bossQuest.AddProgress(1);
            }
        }

        public static void Draw()
        {
            // for each quest
            for (int i = 0; i < quests.Length; i++)
            {
                // set the cursorposition to the start of that row
                Console.SetCursorPosition(0, QuestRow + i);
                // for each quest, if it's complete, make it green, 
                if (quests[i].completed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                // if it's still in progress, make it White.
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(quests[i].QuestTextLine());
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintSummary()
        {
            Console.WriteLine();
            for (int i = 0; i < quests.Length; i++)
            {
                Console.WriteLine(quests[i].QuestTextLine());
            }
            Console.WriteLine();
        }
    }
}