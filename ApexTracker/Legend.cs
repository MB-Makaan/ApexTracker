using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexTracker
{

    //class legend is sets up the data to be viewed when the user in the primary program requests to view the data.
    //viewing the data is done by pressing 1 on the prompt. The data is also set up to split into each line rather than one giant block.
    //character being the avatar the player is using, and all the other values from Kills, to Times Placed in Top 3 being the Top 3
    //being the total values the player using the program has achieved. These values can be updated in the data entry part of the program.

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
