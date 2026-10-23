using System.Collections.Generic;

// NICK CHANGE: Unused
//using System;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal static class ItemManager
    {
        const int ScoreBoostValue = 20;
        const int HealValue = 20;
        const int ExtraLifeValue = 1;

        public static List<Item> items = new List<Item>();
        public static void SpawnItems()
        {
            items.Clear();

            items.Add(new ExtraLife(18, 9, ExtraLifeValue));
            items.Add(new ExtraLife(55, 21, ExtraLifeValue));

            items.Add(new ScoreBoost(99, 17, ScoreBoostValue));
            items.Add(new ScoreBoost(99, 23, ScoreBoostValue));
            items.Add(new ScoreBoost(91, 17, ScoreBoostValue));
            items.Add(new ScoreBoost(91, 23, ScoreBoostValue));
            items.Add(new ScoreBoost(77, 6, ScoreBoostValue));
            items.Add(new ScoreBoost(85, 6, ScoreBoostValue));
            items.Add(new ScoreBoost(4, 16, ScoreBoostValue));
            items.Add(new ScoreBoost(13, 17, ScoreBoostValue));
            items.Add(new ScoreBoost(20, 8, ScoreBoostValue));
            items.Add(new ScoreBoost(2, 8, ScoreBoostValue));
            items.Add(new ScoreBoost(17, 0, ScoreBoostValue));
            items.Add(new ScoreBoost(22, 23, ScoreBoostValue));
            items.Add(new ScoreBoost(25, 13, ScoreBoostValue));
            items.Add(new ScoreBoost(55, 10, ScoreBoostValue));
            items.Add(new ScoreBoost(29, 1, ScoreBoostValue));
            items.Add(new ScoreBoost(29, 8, ScoreBoostValue));
            items.Add(new ScoreBoost(43, 0, ScoreBoostValue));
            items.Add(new ScoreBoost(53, 1, ScoreBoostValue));
            items.Add(new ScoreBoost(41, 23, ScoreBoostValue));
            items.Add(new ScoreBoost(64, 21, ScoreBoostValue));
            items.Add(new ScoreBoost(55, 14, ScoreBoostValue));
            items.Add(new ScoreBoost(73, 20, ScoreBoostValue));
            items.Add(new ScoreBoost(90, 17, ScoreBoostValue));
            items.Add(new ScoreBoost(90, 23, ScoreBoostValue));
            items.Add(new ScoreBoost(98, 17, ScoreBoostValue));
            items.Add(new ScoreBoost(98, 23, ScoreBoostValue));
            items.Add(new ScoreBoost(0, 18, ScoreBoostValue));
            items.Add(new ScoreBoost(34, 17, ScoreBoostValue));

            items.Add(new Heal(23, 20, HealValue));
            items.Add(new Heal(56, 1, HealValue));
            items.Add(new Heal(55, 12, HealValue));
            // This one below this line healed for 40, I think this was an accident
            items.Add(new Heal(0, 21, HealValue));
            items.Add(new Heal(24, 0, HealValue));
        }
    }
}