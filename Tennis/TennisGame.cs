using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class TennisGame : ITennisGame
    {
        public Player Player1;
        public Player Player2;

        public TennisGame(string player1, string player2)
        {
            Player1 = new Player(player1);
            Player2 = new Player(player2);
        }

        // playerNumer indicates the player who won the point: 1 - first player, 2 - second player    
        public void PlayerScores(int playerNumber)
        {
            if(TennisPlayerEnum.One == (TennisPlayerEnum)playerNumber)
            {
                Player1.WinsPoint();
            }
            else if(TennisPlayerEnum.Two == (TennisPlayerEnum)playerNumber)
            {
                Player2.WinsPoint();
            }            
        }

        public string DisplayGameScore()
        {
            string result;            
            
            if (NoOneReachesMinGamePoint() && IsNotFirstDeuce())
            {
                // No one ended game and there's even no deuce => display points 0, 1, 2, 3.
                result = DisplayNormalScores();
            }
            else
            {
                // There is deuce, advantage or someone ended game => display DEUCE, ADVANTAGE, GAME.
                result = DisplaySpecialScores();
            }

            return result;
        }    

        // Display normal scores : 0, 1, 2, 3 
        private string DisplayNormalScores()
        {
            var result = string.Empty;
            result = Player1.EqualsPoint(Player2) 
                ? TranslatePoint(Player1) + GameConstants.SCORE_SEPARATOR + GameConstants.SAME_SCORE_SUFFIX // like fifteen-all
                : TranslatePoint(Player1) + GameConstants.SCORE_SEPARATOR + TranslatePoint(Player2); // like fifteen-love

            return result;
        }

        // Display special scores : display DEUCE, ADVANTAGE or GAME 
        private string DisplaySpecialScores()
        {
            var result = string.Empty;
                        
            if (Player1.EqualsPoint(Player2)) // DEUCE
            {                
                result = GameConstants.DEUCE;
            }
            else // ADVANTAGE or GAME 
            {                
                var leadPlayer = Player1.IsLeadingPoint(Player2) ? Player1 : Player2;
                result = LeadEnoughToWin(Player1, Player2) 
                    ? GameConstants.WON_GAME + leadPlayer.Name // "Game for playerXX"
                    : GameConstants.ADVANTAGE + leadPlayer.Name; // "Advantage playerXX"
            }

            return result;
        }

        // zero to three points are described as "love", "fifteen", "thirty", and "forty" respectively.
        private string TranslatePoint(Player player)
        {
            var result = string.Empty;
            switch (player.Point)
            {
                case 0:
                    result = GameConstants.LOVE; break;
                case 1:
                    result = GameConstants.FIFTEEN; break;
                case 2:
                    result = GameConstants.THIRTY; break;
                case 3:
                    result = GameConstants.FORTY; break;
            };

            return result;
        }

        private bool NoOneReachesMinGamePoint()
        {
            return Player1.Point < GameConstants.MIN_GAME_POINT && Player2.Point < GameConstants.MIN_GAME_POINT;
        }

        private bool IsNotFirstDeuce()
        {
            return Player1.Point + Player2.Point < GameConstants.FIRST_DEUCE_SUM;
        }

        private bool LeadEnoughToWin(Player player1, Player player2)
        {
            return Math.Abs(player1.Point - player2.Point) >= GameConstants.MIN_POINT_DIFF_TO_WIN;
        }             
    }

    public enum TennisPlayerEnum
    {
        One = 1,
        Two = 2
    }
    public static class GameConstants
    {
        public const string LOVE = "love";
        public const string FIFTEEN = "fifteen";
        public const string THIRTY = "thirty";
        public const string FORTY = "forty";

        public const string SCORE_SEPARATOR = "-";
        public const string SAME_SCORE_SUFFIX = "all";
        public const string DEUCE = "deuce";
        public const string WON_GAME = "Game for ";
        public const string ADVANTAGE = "Advantage ";

        public const int MIN_GAME_POINT = 4;
        public const int MIN_POINT_DIFF_TO_WIN = 2;
        public const int FIRST_DEUCE_SUM = 6;
    }

}
