namespace Kata_Bowling
{
    public class BowlingGame
    {
        private int _score;

        public void Roll(int pins)
        {
            _score += pins;
        }

        public int Score() => _score;
    }
}