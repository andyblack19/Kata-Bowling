namespace Kata_Bowling
{
    public class Frame
    {
        public int Number { get; set; }
        public int? FirstRoll { get; set; }
        public int? SecondRoll { get; set; }

        public int Score() => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault();
        public bool IsSpare() => !IsStrike() && Score() == 10;
        public bool IsStrike() => FirstRoll == 10;
    }
}