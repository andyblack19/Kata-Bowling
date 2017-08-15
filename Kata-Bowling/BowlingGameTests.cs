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

        private static void RollAll(BowlingGame game, int pinsHit)
        {
            for (var i = 0; i < 20; i++)
                game.Roll(pinsHit);
        }
    }
}
