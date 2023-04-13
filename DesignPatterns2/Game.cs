using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns2.Constant;

namespace DesignPatterns2
{
    internal class Game<T, U> where T : IParticipant
                              where U : IParticipant
    {
        public Player Player;
        public Competitor Competitor;

        public int Turn;

        private ItchyEyeDebuff debuff;
        private int maxDebuffDuration = 2;
        private int debuffStartTurn = 0;

        private bool debuffActivated;
        private double debuffChance = .2;

        public Game(Player player, Competitor competitor)
        {
            Player = player;
            Competitor = competitor;
            Turn = 0;
        }

        public bool ExecuteTurn(out string playerOutput, out string competitorOutput)
        {
            playerOutput = string.Empty;

            if (!debuffActivated && R.NextDouble() <= debuffChance)
            {
                debuffActivated = true;
                debuffStartTurn = Turn;
                debuff = new ItchyEyeDebuff(R.Next(maxDebuffDuration));
                debuff.Attach(Player);
            }

            if (debuff != null)
            {
                debuff.Notify(debuffStartTurn, Turn, out string notificationString);
                playerOutput += notificationString;
            }

            Turn++;
            Player.TurnsRemaining--;
            Competitor.TurnsRemaining--;

            bool playerAlive;
            bool competitorAlive;

            if (Player.TurnsRemaining > 0)
            {
                playerOutput += $"{Player.Name} stares straight ahead, it looks like they will last about {Player.TurnsRemaining} more turns";
                playerAlive = true;
            }
            else
            {
                playerOutput = $"{Player.Name} gives in and blinks";
                playerAlive = false;
            }

            if (Competitor.TurnsRemaining > 0)
            {
                competitorOutput = $"{Competitor.Name} stares straight ahead, , it looks like they will last about {Competitor.TurnsRemaining} more turns";
                competitorAlive = true;
            }
            else
            {
                competitorOutput = $"{Competitor.Name} gives in and blinks";
                competitorAlive = false;
            }

            return competitorAlive && playerAlive;
        }
        
        public string DisplayPlayerInventory()
        {
            return Player.DisplayInventory();
        }

        public void UseFirstitem()
        {
            if (Player.Inventory == null || Player.Inventory.Count <= 0) return;

            int temp = Player.Inventory[0].GetEffect();
            Player.TurnsRemaining += temp;
            Player.Inventory.RemoveAt(0);
        }

        public string GetWinner()
        {
            return Player.TurnsRemaining > 0 ? "won" : "lost";
        }
    }
}
