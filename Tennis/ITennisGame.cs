using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public interface ITennisGame
    {
        /// <summary>
        /// Update point of player who won the point
        /// </summary>
        /// <param name="playerNumber">1 - first player, 2 - second player</param>
        void PlayerScores(int playerNumber);

        /// <summary>
        /// Display game score of two players
        /// </summary>
        /// <returns></returns>
        string DisplayGameScore();
    }
}
