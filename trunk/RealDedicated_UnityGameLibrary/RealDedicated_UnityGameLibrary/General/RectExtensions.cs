using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public static class RectExtensions
    {
        public static Rect screen(this Rect vector2)
        {
            return new Rect(0, 0, Screen.width, Screen.height);
        }
    }
}
