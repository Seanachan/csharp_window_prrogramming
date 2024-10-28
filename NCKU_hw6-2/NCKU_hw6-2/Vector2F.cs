using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_hw6_2
{
    [Serializable]
    public class Vector2F
    {
        private float _x, _y;

        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        public Vector2F(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Vector2F()  // Default constructor
        {
            _x = _y = 0;
        }

        public static Vector2F operator +(Vector2F a, Vector2F b) => new Vector2F(a._x + b._x, a._y + b._y);
        public static Vector2F operator -(Vector2F a, Vector2F b) => new Vector2F(a._x - b._x, a._y - b._y);
        public static Vector2F operator *(Vector2F a, float b) => new Vector2F(a._x * b, a._y * b);
        public static Vector2F operator /(Vector2F a, float b) => new Vector2F(a._x / b, a._y / b);

        public float Length() => (float)Math.Sqrt(_x * _x + _y * _y);

        public override string ToString() => $"({_x:F4}, {_y:F4})";
    }

}
