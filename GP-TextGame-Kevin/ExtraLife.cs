using System;
// NICK CHANGE: Unused
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class ExtraLife : Item
    {
        // NICK CHANGE: renamed it from _liveToAdd to livesToAdd
        int livesToAdd;

        public ExtraLife(int x, int y,int livesToAdd) : base(x, y)
        {
            icon = 'L';
            color = ConsoleColor.DarkGreen;
            this.livesToAdd = livesToAdd;
        }
        public override void Use()
        {
            GameManager.player.health._revives += livesToAdd;
            base.Use();
        }
    }
}