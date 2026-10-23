using System;

namespace GP_TextGame_Kevin
{
    internal static class QuestManager
    {
        // variables instead of magic numbers
        const int HealGoal = 200;
        const int QuestRow = 2; // rows 0-1 are the HUD and input, the map starts at row 5

        // the three quests
        static Quest healQuest = new Quest("Heal 200 damage", HealGoal);
        static Quest killQuest = new Quest("Kill all minor enemies", 1);
        static Quest bossQuest = new Quest("Defeat the boss", 1);

        // quest[0] = healQuest. Made an array so 
        static Quest[] quests = { healQuest, killQuest, bossQuest };

        // call after SpawnEnemies so the kill goal matches the enemy count
        public static void Reset()
        {
            healQuest.Reset(HealGoal);
            killQuest.Reset(EnemyManager.enemies.Count);
            bossQuest.Reset(1);
        }

        public static void PlayerHealed(int amount) { healQuest.AddProgress(amount); }
        public static void EnemyKilled() { killQuest.AddProgress(1); }

        public static void Update()
        {
            if (!EnemyManager.boss._health.CheckIfAlive() && GameManager.player._health.CheckIfAlive())
            {
                bossQuest.AddProgress(1);
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < quests.Length; i++)
            {
                Console.SetCursorPosition(0, QuestRow + i);
                Console.ForegroundColor = quests[i].completed ? ConsoleColor.Green : ConsoleColor.Yellow;
                Console.Write(quests[i].GetText().PadRight(Console.WindowWidth - 1));
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintSummary()
        {
            Console.WriteLine();
            for (int i = 0; i < quests.Length; i++)
            {
                Console.WriteLine(quests[i].GetText());
            }
            Console.WriteLine();
        }
    }
}