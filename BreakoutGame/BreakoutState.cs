using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreakoutGame
{
    class BreakoutState
    {
        bool[,] bricks = new bool[5, 5];
        // Position of the left hand side of the paddle

        Ball _ball = new Ball(50, 50, 100, 400);
        Board _board;
        Paddle _paddle = new Paddle(new Rectangle(200, 500, 100, 20));
        DateTime _lastTick;
        List<Brick> _bricks = new List<Brick>();

        public BreakoutState(int boardWidth, int boardHeight)
        {
            _board = new Board(new Rectangle(0, 0, boardWidth, boardHeight));
            _lastTick = DateTime.Now;
            _bricks.Add(new Brick(new Rectangle(400, 100, 40, 10)));
            _bricks.Add(new Brick(new Rectangle(440, 100, 40, 10)));
            _bricks.Add(new Brick(new Rectangle(480, 100, 40, 10)));
        }

        public void setPaddlePos(int pos)
        {
            int boundedPos = Math.Min(Math.Max(_board.Geometry.X, pos), _board.Geometry.Width - _paddle.Geometry.Width);
            _paddle.SetLocation(boundedPos);
        }

        public void Tick()
        {
            TimeSpan tickInterval = DateTime.Now - _lastTick;
            _lastTick = DateTime.Now;
            ProcessCollisions();
            _ball.Tick(tickInterval);
        }

        public Queue<IRenderable> GetRenderables()
        {
            Queue<IRenderable> ret = new Queue<IRenderable>();

            ret.Enqueue(_board);
            ret.Enqueue(_ball);
            ret.Enqueue(_paddle);
            foreach(Brick brick in _bricks)
            {
                ret.Enqueue(brick);
            }

            return ret;
        }

        private void ProcessCollisions()
        {
            // Paddle
            if(_ball.Geometry.IntersectsWith(_paddle.Geometry) && _ball.Velocity.Y > 0)
            {
                // TODO: Set angle of collision based on collision point difference vs center of paddle as function of paddle width
                System.Console.WriteLine("bounce new {0}", _ball.Velocity);
                _ball.Velocity = new System.Numerics.Vector2(_ball.Velocity.X, -_ball.Velocity.Y);
            }

            // Top Wall
            if(_ball.Geometry.Y <= 0 && _ball.Velocity.Y < 0)
            {
                _ball.Velocity = new System.Numerics.Vector2(_ball.Velocity.X, -_ball.Velocity.Y);
            }

            // Left wall
            if(_ball.Geometry.X <= 0 && _ball.Velocity.X < 0)
            {
                _ball.Velocity = new System.Numerics.Vector2(-_ball.Velocity.X, _ball.Velocity.Y);
            }

            // Right wall
            int rightEdgeX = _ball.Geometry.X + _ball.Geometry.Width;
            if (rightEdgeX >= _board.Geometry.Width && _ball.Velocity.X > 0)
            {
                _ball.Velocity = new System.Numerics.Vector2(-_ball.Velocity.X, _ball.Velocity.Y);
            }

            // Bricks
            for(int i = 0; i < _bricks.Count; i++)
            {
                if(_ball.Geometry.IntersectsWith(_bricks[i].Geometry) && _ball.Velocity.Y < 0)
                {
                    _ball.Velocity = new System.Numerics.Vector2(_ball.Velocity.X, -_ball.Velocity.Y);
                }
            }

        }
    }
}
