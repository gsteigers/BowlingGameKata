using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameKata
{
    [TestClass]
    public class BowlingGameTests
    {
        private BowlingGame game;
        [TestInitialize]
        public void Init()
        {
        }

        protected void setupGame()
        {
            game = new BowlingGame();
        }

        private void rollSpare()
        {
            game.roll(5);
            game.roll(5);
        }

        private void rollStrike()
        {
            game.roll(10);
        }

        [TestMethod]
        public void Rolling_no_pins_should_result_in_a_score_of_0()
        {
            setupGame();
            game.roll(0);

            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void Scoreless_game_should_result_in_a_score_of_0()
        {
            setupGame();
            for (int i = 0; i < 20; i++)
            {
                game.roll(0);
            }

            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void Rolling_pins_should_be_reflected_in_the_score()
        {
            setupGame();
            game.roll(5);

            Assert.AreEqual(5, game.score());
        }

        [TestMethod]
        public void Rolling_pins_should_be_reflected_in_the_final_score()
        {
            setupGame();
            for (int i = 0; i < 20; i++)
            {
                game.roll(1);
            }

            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void Rolling_a_spare_should_give_a_bonus_of_the_next_roll()
        {
            setupGame();
            rollSpare(); // spare
            game.roll(2);

            Assert.AreEqual(14, game.score());
        }

        [TestMethod]
        public void Rolling_a_strike_should_give_a_bonus_of_the_next_two_rolls()
        {
            setupGame();
            game.roll(10); //strike
            game.roll(4);
            game.roll(4);

            Assert.AreEqual(26, game.score());
        }

        [TestMethod]
        public void Roll_a_perfect_game_results_in_a_score_of_300()
        {
            setupGame();
            for (int i = 0; i < 12; i++)
            {
                rollStrike();
            }

            Assert.AreEqual(300, game.score());
        }

        [TestMethod]
        public void Highest_score_rolling_all_spares_should_result_in_190()
        {
            setupGame();
            for (int i = 0; i < 10; i++)
            {
                game.roll(9);
                game.roll(1);
            }
            game.roll(9);

            Assert.AreEqual(190, game.score());
        }
    }
}
