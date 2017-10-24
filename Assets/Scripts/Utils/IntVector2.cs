using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Class representing a 2D vector which elements are of int type.
    /// </summary>
    public struct IntVector2
    {
        public int x;
        public int y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(System.Object obj)
        {
            return obj is IntVector2 && this == (IntVector2)obj;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

        public static bool operator ==(IntVector2 first, IntVector2 second)
        {
            return first.x == second.x && first.y == second.y;
        }

        public static bool operator !=(IntVector2 first, IntVector2 second)
        {
            return !(first == second);
        }

        public static IntVector2 operator +(IntVector2 first, IntVector2 second)
        {
            return new IntVector2(first.x + second.x, first.y + second.y);
        }

        public static implicit operator IntVector2(Vector2 v)
        {
            return new IntVector2((int)Mathf.Round(v.x), (int)Mathf.Round(v.y));
        }

        public static int ManhattanDistance(IntVector2 first, IntVector2 second)
        {
            var dx = second.x - first.x;
            var dy = second.y - first.y;

            return Mathf.Abs(dx) + Mathf.Abs(dy);
        }
    }
}
