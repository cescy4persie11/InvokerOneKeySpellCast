using System.Linq;
using Ensage.Common.Extensions;
using Ensage;
using InvokerLegacyCfg.Utilities;
using InvokerLegacyCfg.Abilities;
using System.Windows.Input;
using System;

namespace InvokerLegacyCfg
{
    public class InvokerSharp
    {
        private static Hero Me
        {
            get
            {
                return Variables.Hero;
            }
        }

        private ColdSnap coldSnap;

        private Alacrity alacrity;

        private ChaosMeteor chaosMeteor;

        private DeafeningBlast deafeningBlast;

        private EMP emp;

        private ForgeSpirit forgeSpirit;

        private GhostWalk ghostWalk;

        private IceWall iceWall;

        private SunStrike sunStrike;

        private Tornado tornado;

        private bool pause;

        private TargetFind targetFind;

        private Hero Target
        {
            get
            {
                return this.targetFind.Target;
            }
        }

        public InvokerSharp()
        {
            //this.invokerOneKeyCast = new InvokerOneKeyCast();
        }

        public void OnDraw()
        {
            if (this.pause || Variables.Hero == null || !Variables.Hero.IsValid || !Variables.Hero.IsAlive)
            {
                return;
            }
        }

        public void OnLoad()
        {
            Variables.Hero = ObjectManager.LocalHero;
            this.pause = Variables.Hero.ClassID != ClassID.CDOTA_Unit_Hero_Invoker;
            if (this.pause) return;
            Variables.MenuManager = new MenuManager(Me.Name);
            this.coldSnap = new ColdSnap();
            this.alacrity = new Alacrity();
            this.chaosMeteor = new ChaosMeteor();
            this.deafeningBlast = new DeafeningBlast();
            this.forgeSpirit = new ForgeSpirit();
            this.ghostWalk = new GhostWalk();
            this.iceWall = new IceWall();
            this.sunStrike = new SunStrike();
            this.tornado = new Tornado();
            this.emp = new EMP();
            Variables.Quas = Me.Spellbook.SpellQ;
            Variables.Wex = Me.Spellbook.SpellW;
            Variables.Exort = Me.Spellbook.SpellE;
            Variables.Invoke = Me.Spellbook.SpellR;

            Variables.MenuManager.Menu.AddToMainMenu();
            Variables.EnemyTeam = Me.GetEnemyTeam();
            this.targetFind = new TargetFind();
            Game.PrintMessage(
                "Invoker" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + " loaded",
                MessageType.LogMessage);
        }

        public void OnUpdate_InvokerOneKeyCast()
        {
            if (this.pause || Variables.Hero == null || !Variables.Hero.IsValid || !Variables.Hero.IsAlive)
            {
                return;
            }

            //Alacrity
            if (Game.IsKeyDown(Key.Z) && !Game.IsChatOpen)
            {
                alacrity.invokeAlacrity();
            }
            
            //ChaosMeteor
            if (Game.IsKeyDown(Key.D) && !Game.IsChatOpen)
            {
                chaosMeteor.invokeChaosMeteor();
            }
         
            //Cold Snap
            if (Game.IsKeyDown(Key.Y) && !Game.IsChatOpen)
            {
                coldSnap.invokeColdSnap();
            }

            //Deafening Blast
            if (Game.IsKeyDown(Key.B) && !Game.IsChatOpen)
            {
                deafeningBlast.invokeDeafeningBlast();
            }

            //EMP
            if (Game.IsKeyDown(Key.C) && !Game.IsChatOpen)
            {
                emp.invokeEMP();
            }

            //Forge Spirit
            if (Game.IsKeyDown(Key.F) && !Game.IsChatOpen)
            {
                forgeSpirit.invokeForgeSpirit();
            }

            //Ghost Walk
            if (Game.IsKeyDown(Key.V) && !Game.IsChatOpen)
            {
                ghostWalk.invokeGhostWalk();
            }

            //Ice Wall
            if (Game.IsKeyDown(Key.G) && !Game.IsChatOpen)
            {
                iceWall.invokeIceWall();
            }

            //SunStrike
            if (Game.IsKeyDown(Key.T) && !Game.IsChatOpen)
            {
                sunStrike.invokeSunStrike();
            }

            //Tornado
            if (Game.IsKeyDown(Key.X) && !Game.IsChatOpen)
            {
                tornado.invokeTornado();
            }
            
        }

        public void OnWndProc(WndEventArgs args)
        {
            if (this.pause || Variables.Hero == null || !Variables.Hero.IsValid || !Variables.Hero.IsAlive)
            {
                return;
            }
        }

        public void OnClose()
        {
            this.pause = true;
            if (Variables.MenuManager != null)
            {
                Variables.MenuManager.Menu.RemoveFromMainMenu();
            }
            Variables.PowerTreadsSwitcher = null;
        }

        public void Player_OnExecuteOrder(Player sender, ExecuteOrderEventArgs args)
        {
            if (this.pause || Variables.Hero == null || !Variables.Hero.IsValid || !Variables.Hero.IsAlive)
            {
                return;
            }

            var spell = args.Ability;
            if ((Game.IsKeyDown(Key.D) && !Game.IsChatOpen && !chaosMeteor.invoked("invoker_chaos_meteor"))
                || (Game.IsKeyDown(Key.F) && !Game.IsChatOpen && !forgeSpirit.invoked("invoker_forge_spirit")))
            {
                if (args.Order == Order.Ability)
                {
                    args.Process = false;
                }
            }


            
        }

    }
}
