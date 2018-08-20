using System;
using System.Collections.Generic;

namespace AoC2017.Day19
{
    public class Day19Part1
    {
        private string[] _diagram;
        private PositionInfo _currentPosition;
        private readonly List<char> _visitedNodes = new List<char>();
        private Direction _direction = Direction.Down;

        public string Solution(string input)
        {
            ParseInput(input);

            FindStartPosition();

            FollowPath();

            return new string(_visitedNodes.ToArray());
        }

        private void FollowPath()
        {
            while (true)
            {
                var nextPosition = GetStraightPositionInfo();
                if (nextPosition.IsOutOfBounds || nextPosition.Char == ' ')
                {
                    if (!ChangeDirection())
                    {
                        break;
                    }
                }
                else
                {
                    if (char.IsLetter(nextPosition.Char))
                    {
                        _visitedNodes.Add(nextPosition.Char);
                    }
                    _currentPosition = nextPosition;
                }
            }

        }

        private struct PositionInfo
        {
            public (int x, int y) Position;
            public bool IsOutOfBounds;
            public char Char;
        }

        private PositionInfo GetPositionInfo((int x, int y) position)
        {
            var isOutOfBounds = IsOutOfBounds(position);
            return new PositionInfo
            {
                Position = position,
                IsOutOfBounds = isOutOfBounds,
                Char = isOutOfBounds
                    ? default(char)
                    : _diagram[position.y][position.x]
            };
        }

        private PositionInfo GetStraightPositionInfo()
        {
            return GetPositionInfo(GetRelativePosition(_direction));
        }

        private bool ChangeDirection()
        {
            var leftDirection = (Direction)(((byte)_direction + 3) % 4);
            var rightDirection = (Direction)(((byte)_direction + 1) % 4);

            if (CanDirectionBeFollowed(leftDirection))
            {
                _direction = leftDirection;
                return true;
            }

            if (CanDirectionBeFollowed(rightDirection))
            {
                _direction = rightDirection;
                return true;
            }

            return false;
        }


        private (int x, int y) GetRelativePosition(Direction direction)
        {
            var (x, y) = _currentPosition.Position;
            switch (direction)
            {
                case Direction.Up:
                    return (x, y - 1);
                case Direction.Right:
                    return (x + 1, y);
                case Direction.Down:
                    return (x, y + 1);
                case Direction.Left:
                    return (x - 1, y);
            }
            throw new InvalidOperationException();
        }

        private bool CanDirectionBeFollowed(Direction direction)
        {
            var position = GetPositionInfo(GetRelativePosition(direction));
            return !position.IsOutOfBounds && position.Char != ' ';
        }


        private bool IsOutOfBounds((int x, int y) position)
        {
            return position.x < 0 || position.y < 0 || position.x >= _diagram[position.y].Length || position.y >= _diagram.Length;
        }


        private void FindStartPosition()
        {
            var x = _diagram[0].IndexOf('|');
            x = x > -1 ? x : _diagram[1].IndexOf('|');
            _currentPosition = GetPositionInfo((x, 0));
        }

        private void ParseInput(string input)
        {
            _diagram = input.Split(Environment.NewLine);
        }

        public enum Direction : byte
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }
    }

}
