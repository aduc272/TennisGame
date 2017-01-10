using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis;

namespace TennisTest
{
    [TestClass]
    public class TennisGameTest
    {
        TennisGame tennisGame;

        [TestInitialize]
        public void Init()
        {
            tennisGame = new TennisGame("player1", "player2");
        }

        [TestMethod]
        public void PlayerScoresTest_Nominal()
        {
            Assert.AreEqual(0, tennisGame.Player1.Point);
            Assert.AreEqual(0, tennisGame.Player2.Point);

            tennisGame.PlayerScores(1);
            Assert.AreEqual(1, tennisGame.Player1.Point);
            tennisGame.PlayerScores(1);
            Assert.AreEqual(2, tennisGame.Player1.Point);
            tennisGame.PlayerScores(1);
            Assert.AreEqual(3, tennisGame.Player1.Point);

            Assert.AreEqual(0, tennisGame.Player2.Point);
            tennisGame.PlayerScores(2);
            Assert.AreEqual(1, tennisGame.Player2.Point);
        }

        [TestMethod]
        public void PlayerScoresTest_InvalidInput_NoOneWinsPoint()
        {
            Assert.AreEqual(0, tennisGame.Player1.Point);
            Assert.AreEqual(0, tennisGame.Player2.Point);

            tennisGame.PlayerScores(3);
            Assert.AreEqual(0, tennisGame.Player1.Point);
            Assert.AreEqual(0, tennisGame.Player2.Point);

            tennisGame.PlayerScores(12);
            Assert.AreEqual(0, tennisGame.Player2.Point);            
            Assert.AreEqual(0, tennisGame.Player2.Point);
        }

        [TestMethod]
        public void DisplayGameScoreTest_NormalScores()
        {
            CheckScores(0, 0, "love-all");
            CheckScores(1, 1, "fifteen-all");
            CheckScores(2, 2, "thirty-all");            
            CheckScores(1, 0, "fifteen-love");
            CheckScores(0, 1, "love-fifteen");
            CheckScores(2, 0, "thirty-love");
            CheckScores(0, 2, "love-thirty");
            CheckScores(3, 0, "forty-love");
            CheckScores(0, 3, "love-forty");            
            CheckScores(2, 1, "thirty-fifteen");
            CheckScores(1, 2, "fifteen-thirty");
            CheckScores(3, 1, "forty-fifteen");
            CheckScores(1, 3, "fifteen-forty");           
            CheckScores(3, 2, "forty-thirty");
            CheckScores(2, 3, "thirty-forty");
        }

        [TestMethod]
        public void DisplayGameScoreTest_Deuce()
        {
            CheckScores(3, 3, "deuce");
            CheckScores(4, 4, "deuce");
        }

        [TestMethod]
        public void DisplayGameScoreTest_Advantage()
        {
            CheckScores(4, 3, "Advantage player1");
            CheckScores(3, 4, "Advantage player2");
            CheckScores(5, 4, "Advantage player1");
            CheckScores(4, 5, "Advantage player2");
            CheckScores(15, 14, "Advantage player1");
            CheckScores(14, 15, "Advantage player2");
        }

        [TestMethod]
        public void DisplayGameScoreTest_Wingame()
        {
            CheckScores(4, 0, "Game for player1");
            CheckScores(0, 4, "Game for player2");
            CheckScores(4, 1, "Game for player1");
            CheckScores(1, 4, "Game for player2");
            CheckScores(4, 2, "Game for player1");
            CheckScores(2, 4, "Game for player2");
            CheckScores(6, 4, "Game for player1");
            CheckScores(4, 6, "Game for player2");
        }

        private void CheckScores(int player1Score, int player2Score, string expectedScore)
        {
            tennisGame.Player1.Point = player1Score;
            tennisGame.Player2.Point = player2Score;
            Assert.AreEqual(expectedScore, tennisGame.DisplayGameScore());
        }        
    }
}
