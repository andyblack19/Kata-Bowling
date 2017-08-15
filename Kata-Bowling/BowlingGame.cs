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
            var currentFrame = _frames.Single(x => x.Number == _currentFrameNumber);
            if (currentFrame.FirstRoll.HasValue)
            {
                currentFrame.SecondRoll = pins;
                MoveToNextFrame();
            }
            else
            {
                currentFrame.FirstRoll = pins;
            }
        }

        private void MoveToNextFrame()
        {
            _currentFrameNumber += 1;
        }

        public int Score()
        {
            var score = 0;
            foreach (var frame in _frames)
            {
                score += frame.Score();
                if (frame.IsSpare())
                {
                    var nextFrame = _frames[_frames.IndexOf(frame) + 1];
                    score += nextFrame?.FirstRoll ?? 0;
                }
            }
            return score;
        }
    }
}