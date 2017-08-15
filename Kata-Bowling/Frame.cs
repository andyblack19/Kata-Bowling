namespace Kata_Bowling
{
    public class Frame
    {
        public int Number { get; set; }
        public int? FirstRoll { get; private set; }
        public int? SecondRoll { get; private set; }

        public void AddScore(int pins)
        {
            if (FirstRoll == null)
                FirstRoll = pins;
            else
                SecondRoll = pins;
        }

        public int Score() => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault();
        public bool IsSpare() => !IsStrike() && Score() == 10;
        public bool IsStrike() => FirstRoll == 10;
        public bool IsComplete() => IsStrike() || SecondRoll.HasValue;
    }
}