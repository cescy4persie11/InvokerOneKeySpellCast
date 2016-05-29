using Ensage;
using Ensage.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvokerLegacyCfg
{
    public class Bootstrap
    {
        private readonly InvokerSharp invokerSharp;

        public Bootstrap()
        {
            this.invokerSharp = new InvokerSharp();
        }

        public void SubscribeEvents()
        {
            Events.OnLoad += this.Events_Onload;
            Events.OnClose += this.Events_OnClose;
            Game.OnUpdate += this.Game_OnUpdate;
            //Game.OnWndProc += this.Game_OnWndProc;
            Drawing.OnDraw += this.Drawing_OnDraw;          
            Player.OnExecuteOrder += this.Player_OnExecuteOrder;
        }

        private void Drawing_OnDraw(EventArgs args)
        {
            this.invokerSharp.OnDraw();
        }

        private void Events_Onload(object sender, EventArgs e)
        {
            this.invokerSharp.OnLoad();
        }

        private void Events_OnClose(object sender, EventArgs e)
        {
            this.invokerSharp.OnClose();
        }

        private void Game_OnUpdate(EventArgs args)
        {
            this.invokerSharp.OnUpdate_InvokerOneKeyCast();
        }

        private void Game_OnWndProc(WndEventArgs args)
        {
            //this.visageSharp.OnWndProc(args);
        }

        private void Player_OnExecuteOrder(Player sender, ExecuteOrderEventArgs args)
        {
            if (sender.Equals(ObjectManager.LocalPlayer))
            {
                this.invokerSharp.Player_OnExecuteOrder(sender, args);
            }
        }
    }
}
