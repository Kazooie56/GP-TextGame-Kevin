using GP_TextGame_Kevin;
using System;

// NICK CHANGE: Unused
//using System.Collections.Generic;
//using System.CodeDom;
//using System.Linq;
//using System.ComponentModel;
//using System.Net.Socket;
//using System.Text;
//using System.Threading;
//using System.Threading.Task;

namespace FirstPlayable_GP2_Kevin
{
    internal class Program
    {
        //I'm sorry

        // It's all good :)


        // NICK CHANGE: These are unused,
        // I commented them out instead of deleting them to make it easier to know what is gone now
        // all of them are unused.

        //static List<int> enemiesToRemove = new List<int>();
        //static List<int> itemsToRemove = new List<int>();
        //static Random random = new Random();
        
        // NICK CHANGE: made a static int perfectScore to remove a magic number, probably unnecessary
        // also it's been dropped to 1000 because I removed 1 duplicate enemy
        static int perfectScore = 1000;

        // NICK CHANGE: Made the intro text a string and made it a method to clean up main a bit.
        public static string IntroText =
            "ITEMS:\n\n" +
            "S: score boost\n" +
            "+: healing\n" +
            "L: extra life\n\n" +
            "ENEMIES:\n\n" +
            "X: basic enemy moves to attack you\n" +
            "?: lost enemies moves randomly\n" +
            "%: not affected by terrain\n" +
            "!: strong but slow\n" +
            "B: the boss, kill him to win, his power and speed change after every attack\n\n" +
            "TERRAIN:\n\n" +
            "`: grass\n" +
            "~: water slows you down\n" +
            "H: heals all that step on it\n" +
            "@: damages all that step on it\n" +
            "^: impassable mountain\n\n\n" +
            "press anything to start";

        static void Main(string[] args)
        {
            bool playing = true;
            while (playing)
            {
                // NICK CHANGE: Cleaning up Main
                //Console.WriteLine("ITEMS:\n\n" +
                //    "" +
                //    "S: score boost\n" +
                //    "+: healing\n" +
                //    "L: extra life\n\n" +
                //    "" +
                //    "ENEMIES:\n\n" +
                //    "" +
                //    "X: basic enemy moves to attack you\n" +
                //    "?: lost enemies moves randomly\n" +
                //    "%: not affected by terrain\n" +
                //    "!: strong but slow\n" +
                //    "B: the boss, kill him to win, his power and speed change after every attack\n\n" +
                //    "" +
                //    "TERRAIN:\n\n" +
                //    "" +
                //    "`: grass\n" +
                //    "~: water slows you down\n" +
                //    "H: heals all that step on it\n" +
                //    "@: damages all that step on it\n" +
                //    "^: impassable mountain\n\n\n" +
                //    "" +
                //    "" +
                //    "press anything to start");


                //Console.ReadKey(true);
                //Console.Clear();

                ShowIntro();
                SetupGame();
                RunGameLoop();
                ShowEndScreen();
                playing = AskToPlayAgain();


                // NICK CHANGE: Removed these three lines, moving the logic into Player.cs
                //GameManager.player._health.FullHeal();
                //GameManager.player._xPos = 0;
                //GameManager.player._yPos = 0;

                //end game
            }
        }
        static void ShowIntro()
        {
            Console.WriteLine(IntroText);
            Console.ReadKey(true);
            Console.Clear();
        }
        static void SetupGame()
        {
            GameManager.CheckWindow();
            Console.Clear();
            GameManager.map.DrawMap();
            GameManager.Score = 0;
            GameManager.player.Reset(0, 0);

            EnemyManager.BossSet();
            ItemManager.SpawnItems();
            EnemyManager.SpawnEnemies();
            // NICK CHANGE: must come after SpawnEnemies so the kill goal matches the enemy count
            QuestManager.Reset();
            GameManager.Draw();
        }
        static void RunGameLoop()
        {
            while (GameManager.player.health.GetIsAlive() && EnemyManager.boss._health.GetIsAlive())
            {
                GameManager.CheckWindow();
                DrawHud();
                GameManager.RemoveUsedOrDead();
                // NICK CHANGE: after RemoveUsedOrDead so the kill count is current
                QuestManager.Draw();
                GameManager.Move();
                GameManager.Draw();
            }
            QuestManager.Update();
        }
        static void DrawHud()
        {
            var player = GameManager.player;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(
                $"Health: {player.health._health}    " +
                $"Strength: {player.strength}    " +
                $"Score: {GameManager.Score}    " +
                $"ExtraLives: {player.health._revives}    " +
                $"Enemy Health: {player.lastEnemyHP}    " +
                $"Enemy Strength: {player.lastEnemyStrength}                  " );
        }
        static void ShowEndScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            if (!GameManager.player.health.GetIsAlive())
            {
                Console.WriteLine("You Died, Game Over");
            }
            else if (GameManager.Score < perfectScore)
            {
                Console.WriteLine("You Won");
            }
            else
            {
                Console.WriteLine("You did Perfect!");
            }

            QuestManager.PrintSummary();
            Console.WriteLine("Press any key to continue.");

            Console.ReadKey(true);
        }
        static bool AskToPlayAgain()
        {
            Console.WriteLine("Would you like to play again? (y/n), then press enter");
            while (true)
            {
                string answer = Console.ReadLine();
                answer = answer.ToLower();
                if (answer == "y" || answer == "yes") 
                    return true;
                if (answer == "n" || answer == "no") 
                    return false;
                Console.WriteLine("That is not a valid answer");
            }
        }
    }
}