using NUnit.Framework;

namespace Kata_Bowling
{
    public class BowlingGameTests
    {
        [Test]
        public void Game_score_is_zero_when_no_pins_hit()
        {
            var game = new BowlingGame();
            RollTwentyZeros(game);
            Assert.That(game.Score(), Is.EqualTo(0));
        }

        private static void RollTwentyZeros(BowlingGame game)
        {
            for (var i = 0; i < 20; i++)
                game.Roll(0);
        }
    }
}
