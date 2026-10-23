// NICK CHANGE: Unused
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Health
    {
        public int _health { get; private set; }
        protected int _maxHealth;
        protected bool _isAlive = true;
        public int _revives;
        public Health(int HP, int revives)
        {
            _maxHealth = HP;
            _health = HP;
            _revives = revives;
        }
        // NICK CHANGE: PascalCase
        public void Revive()
        {
            if(_revives > 0)
            {
                _revives--;
                FullHeal();
            }
        }
        public void TakeDamage(int DMG)
        {
            _health -= DMG;
            if (_health <= 0)
            {
                _isAlive = false;
                _health = 0;
                Revive();
            }
        }

        public bool GetIsAlive()
        {
            return _isAlive;
        }

        // NICK CHANGE: We're keeping track of how much health is restored for the quest, So I'm returning what gets healed.
        public int Heal(int Recover)
        {
            int healed = Recover;
            if (_health + Recover > _maxHealth)
            {
                healed = _maxHealth - _health;
            }

            _health += healed;
            return healed;
        }
        public void FullHeal()
        {
            _health = _maxHealth;
            _isAlive = true;
        }
    }
}

