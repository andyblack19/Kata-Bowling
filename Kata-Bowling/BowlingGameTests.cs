using NUnit.Framework;

namespace Kata_Bowling
{
    public class BowlingGameTests
    {
        [Test]
        public void Game_score_is_zero_when_no_pins_hit()
        {
            var game = new BowlingGame();
            RollAll(game, 0);
            Assert.That(game.Score(), Is.EqualTo(0));
        }

        [Test]
        public void Game_score_is_twenty_when_1_pin_hit_every_roll()
        {
            var game = new BowlingGame();
            RollAll(game, 1);
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
            RollMany(game, 16, 1);
            Assert.That(game.Score(), Is.EqualTo(29));
        }

        private static void RollMany(BowlingGame game, int times, int pinsHit)
        {
            for (var i = 0; i < times; i++)
                game.Roll(pinsHit);
        }

        private static void RollAll(BowlingGame game, int pinsHit)
        {
            for (var i = 0; i < 20; i++)
                game.Roll(pinsHit);
        }
    }
}
