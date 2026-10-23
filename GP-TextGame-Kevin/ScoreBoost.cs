using System;
// NICK CHANGE: Unused
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class ScoreBoost : Item
    {
        private int scoreValue;
        public ScoreBoost(int x, int y, int scoreValue) : base(x, y)
        {
            // this denotes which one is which since they have the same name because they share the same idea
            this.scoreValue = scoreValue; 
            icon = 'S';
            color = ConsoleColor.Yellow;
        }
        public override void Use()
        {
            GameManager.Score += scoreValue;
            base.Use();
        }
    }
}