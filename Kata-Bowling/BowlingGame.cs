using System.Collections.Generic;
using System.Linq;

namespace Kata_Bowling
{
    public class BowlingGame
    {
        private int _currentFrameNumber = 1;
        private readonly List<Frame> _frames = new List<Frame>();

        public BowlingGame()
        {
            for (var i = 1; i <= 10; i++)
                _frames.Add(new Frame { Number = i });
        }

        public void Roll(int pins)
        {
            var frame = GetCurrentFrame();

            frame.AddScore(pins);

            if (frame.IsComplete() && !frame.IsFinalFrame())
                MoveToNextFrame();
        }

        public int Score()
        {
            var score = 0;
            foreach (var frame in _frames)
            {
                score += frame.Score();

                if (frame.IsFinalFrame()) continue;

                if (frame.IsSpare() || frame.IsStrike())
                    score += GetBonusScore(frame);
            }
            return score;
        }

        private int GetBonusScore(Frame frame)
        {
            if (frame.IsSpare())
                return GetNextFrame(frame).FirstRoll.GetValueOrDefault();
            
            if (frame.IsStrike())
                return GetNextFrame(frame).Score();
            
            return 0;
        }

        private void MoveToNextFrame()
        {
            _currentFrameNumber += 1;
        }

        private Frame GetCurrentFrame() => _frames.Single(x => x.Number == _currentFrameNumber);
        private Frame GetNextFrame(Frame frame) => _frames.Single(x => x.Number == frame.Number + 1);
    }
}