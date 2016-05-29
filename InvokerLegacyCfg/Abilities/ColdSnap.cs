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
    public class ColdSnap
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

        public ColdSnap()
        {
            //this.ability = ClassID.Invoker;         
            //this.abilityIcon = Drawing.GetTexture("materials/ensage_ui/spellicons/storm_spirit_static_remnant");
            //this.iconSize = new Vector2(HUDInfo.GetHpBarSizeY() * 2);
        }

        public void getAbility()
        {
            if (invoked("invoker_cold_snap"))
            {
                this.ability = me.FindSpell("invoker_cold_snap");
            }
        }

        public bool invoked(string abilityName)
        {
            return me.Spellbook.SpellD.Name.Equals(abilityName)
                || me.Spellbook.SpellF.Name.Equals(abilityName);
        }

        public void invokeColdSnap()
        {
            if (invoked("invoker_cold_snap"))
            {
                getAbility();
                //cast on enemy
                //if (target == null || !target.IsAlive) return;
                //if (Utils.SleepCheck("coldsnap")) {
                //    ability.UseAbility(target);
                //    Utils.Sleep(50, "coldsnap");
                //}
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
                Q.UseAbility();
                Q.UseAbility();
                Q.UseAbility();
                R.UseAbility();
                E.UseAbility();
                E.UseAbility();
                E.UseAbility();
                Utils.Sleep(250, "invoke");
            }
        }
    }
}
