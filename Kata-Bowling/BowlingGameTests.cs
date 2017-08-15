using NUnit.Framework;

namespace Kata_Bowling
{
    public class BowlingGameTests
    {
        private static void RollMany(BowlingGame game, int times, int pinsHit)
        {
            for (var i = 0; i < times; i++)
                game.Roll(pinsHit);
        }

        [Test]
        public void Game_score_is_zero_when_no_pins_hit()
        {
            var game = new BowlingGame();
            RollMany(game, 20, 0);
            Assert.That(game.Score(), Is.EqualTo(0));
        }

        [Test]
        public void Game_score_is_twenty_when_1_pin_hit_every_roll()
        {
            var game = new BowlingGame();
            RollMany(game, 20, 1);
            Assert.That(game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void Rolling_a_spare_gives_next_roll_as_bonus()
        {
            var game = new BowlingGame();
            game.Roll(5);
            game.Roll(5);
            game.Roll(1);
            game.Roll(1);
            RollMany(game, 16, 0);
            Assert.That(game.Score(), Is.EqualTo(13));
        }

        [Test]
        public void Rolling_a_strike_gives_next_2_rolls_in_next_frame_as_bonus()
        {
            var game = new BowlingGame();
            game.Roll(10);
            game.Roll(3);
            game.Roll(1);
            RollMany(game, 16, 0);
            Assert.That(game.Score(), Is.EqualTo(18));
        }

        [Test]
        public void Rolling_2_strikes_gives_next_2_rolls_as_bonus()
        {
            var game = new BowlingGame();
            game.Roll(10);
            game.Roll(10);
            game.Roll(3);
            game.Roll(1);
            RollMany(game, 14, 0);
            Assert.That(game.Score(), Is.EqualTo(38));
        }

        [Test]
        public void Rolling_a_spare_in_tenth_frame_gives_bonus_roll()
        {
            var game = new BowlingGame();
            RollMany(game, 18, 0);
            game.Roll(5);
            game.Roll(5);
            game.Roll(1);
            Assert.That(game.Score(), Is.EqualTo(11));
        }
    }
}