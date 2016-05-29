using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensage;
using Ensage.Common;
using Ensage.Common.Extensions;
using Ensage.Common.Objects;
using SharpDX;

namespace InvokerLegacyCfg.Abilities
{
    public class Alacrity
    {
        private Ability ability;

        private Ability Q
        {
            get
            {
                return Variables.Quas;
            }
        }

        private Ability W
        {
            get
            {
                return Variables.Wex;
            }
        }

        private Ability E
        {
            get
            {
                return Variables.Exort;
            }
        }

        private Ability R
        {
            get
            {
                return Variables.Invoke;
            }
        }

        private Hero me
        {
            get
            {
                return Variables.Hero;
            }
        }

        private uint level
        {
            get
            {
                return this.ability.Level;
            }
        }

        public Alacrity()
        {
        }

        public bool invoked(string abilityName)
        {
            return me.Spellbook.SpellD.Name.Equals(abilityName)
                || me.Spellbook.SpellF.Name.Equals(abilityName);
        }

        public void getAbility()
        {
            if (invoked("invoker_alacrity"))
            {
                this.ability = me.FindSpell("invoker_alacrity");
            }
        }

        public void invokeAlacrity()
        {
            if (invoked("invoker_alacrity"))
            {
                getAbility();
                return;
            }
            else
            {
                invoke();
                getAbility();
            }
        }

        public void invoke()
        {
            if (!R.CanBeCasted()) return;
            if (Utils.SleepCheck("invoke"))
            {
                W.UseAbility();
                W.UseAbility();
                E.UseAbility();
                R.UseAbility();
                E.UseAbility();
                E.UseAbility();
                E.UseAbility();
                Utils.Sleep(250, "invoke");
            }
        }
    }
}
