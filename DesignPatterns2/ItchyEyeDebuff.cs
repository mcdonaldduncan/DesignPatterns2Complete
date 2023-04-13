using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    public class ItchyEyeDebuff
    {
        public int Strength = 1;

        private List<IParticipant> participants = new List<IParticipant>();
        private int duration = 3;
        private int startTurn = 0;

        public ItchyEyeDebuff(int duration)
        {
            this.duration = duration;
        }

        /// <summary>
        /// Notify participants under the effect of poison
        /// </summary>
        /// <param name="startTurn"></param>
        /// <param name="currentTurn"></param>
        /// <param name="notificationString"></param>
        public void Notify(int startTurn, int currentTurn, out string notificationString)
        {
            notificationString = string.Empty;

            if (currentTurn > startTurn + duration) return;

            foreach (var participant in participants)
            {
                participant.Update(this);
            }

            notificationString = "Your eyes are very itchy!\n";
        }

        /// <summary>
        /// Attach new participant
        /// </summary>
        /// <param name="participant"></param>
        public void Attach(IParticipant participant)
        {
            participants.Add(participant);
        }

        /// <summary>
        /// Remove participant
        /// </summary>
        /// <param name="participant"></param>
        public void Remove(IParticipant participant)
        {
            participants.Remove(participant);
        }
    }
}
