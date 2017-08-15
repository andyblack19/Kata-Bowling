using System;

namespace Kata_Bowling
{
    public class Frame
    {
        public int Number { get; set; }

        public int? FirstRoll { get; private set; }

        public int? SecondRoll { get; private set; }

        /// <summary>
        /// Bonus roll is only applicable when there is a Spare or Strike in the 10th frame
        /// </summary>
        public int? BonusRoll { get; private set; }

        public void AddScore(int pins)
        {
            if (FirstRoll == null)
                FirstRoll = pins;
            else if (SecondRoll == null)
                SecondRoll = pins;
            else if (BonusRoll == null && Number == 10)
                BonusRoll = pins;
            else
                throw new InvalidOperationException("This frame is complete.");
        }

        public int Score() => FirstRoll.GetValueOrDefault() + SecondRoll.GetValueOrDefault() + BonusRoll.GetValueOrDefault();
        public bool IsSpare() => !IsStrike() && Score() == 10;
        public bool IsStrike() => FirstRoll == 10;
        public bool IsComplete() => IsStrike() || SecondRoll.HasValue;
        public bool IsFinalFrame() => Number == 10;
    }
}