using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensage;
using InvokerLegacyCfg.Abilities;
using InvokerLegacyCfg.Utilities;

namespace InvokerLegacyCfg
{
    public static class Variables
    {
        public static Team EnemyTeam { get; set; }

        public static Hero Hero { get; set; }

        public static List<Unit> Familiars { get; set; }

        public static ColdSnap coldSnap;

        public static GhostWalk ghostWalk;

        public static IceWall iceWall;

        public static EMP emp;

        public static Tornado tornado;

        public static Alacrity alacrity;

        public static SunStrike sunStrike;

        public static ForgeSpirit forgeSpirit;

        public static ChaosMeteor chaosMeteor;

        public static DeafeningBlast deafeningBlast;

        public static Ability Quas;

        public static Ability Wex;

        public static Ability Exort;

        public static Ability Invoke;

        public static MenuManager MenuManager { get; set; }

        public static PowerTreadsSwitcher PowerTreadsSwitcher { get; set; }

        public static float TickCount
        {
            get
            {
                return Environment.TickCount & int.MaxValue;
            }
        }
    }
}
