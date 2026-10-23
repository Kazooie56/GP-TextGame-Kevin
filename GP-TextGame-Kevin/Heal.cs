using System;
// NICK CHANGE: Unused
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class Heal : Item
    {
        // NICK CHANGE: changed this int from healing to healAmount to clear up confusion
        private int healAmount; 
        
        // NICK CHANGE: changed HP to healAmount to clear up confusion
        public Heal(int x, int y,int healAmount) :base (x,y)
        {
            this.healAmount = healAmount;
            icon = '+';
            color = ConsoleColor.Magenta;
        }
        public override void Use()
        {
            // NICK CHANGE: creates an int called healed that we use to track progress for the quest
            int healed = GameManager.player.health.Heal(healAmount);
            QuestManager.PlayerHealed(healed);
            base.Use();
        }
    }
}