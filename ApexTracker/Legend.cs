using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexTracker
{
    public class Legend
    {
        public string character;
        public string kills;
        public string damageDone;
        public string killsAsKillLeader;
        public string winningKills;
        public string headshots;
        public string finishers;
        public string revives;
        public string gamesPlayed;
        public string winsWithFullSquad;
        public string timesPlacedTopThree;

        public static Legend FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Legend legend = new Legend
            {
                character = values[0],
                kills = values[1],
                damageDone = values[2],
                killsAsKillLeader = values[3],
                winningKills = values[4],
                headshots = values[5],
                finishers = values[6],
                revives = values[7],
                gamesPlayed = values[8],
                winsWithFullSquad = values[9],
                timesPlacedTopThree = values[10]
            };


            return legend;
        }
    }
}
