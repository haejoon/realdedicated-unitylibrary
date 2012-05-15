using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public static class MathExtensions
    {
        /// <summary>
        /// Returns an Angle that lies between -360 & 360
        /// </summary>
        /// <param name="mathf"></param>
        /// <param name="angleToClamp"></param>
        /// <returns></returns>
        public static float NormalizeAngle(this Mathf mathf, float angleToClamp)
        {
            do
            {
                if (angleToClamp < -360)
                    angleToClamp += 360;
                if (angleToClamp > 360)
                    angleToClamp -= 360;

            } while (angleToClamp < -360 || angleToClamp > 360);

            return angleToClamp;
        }
    }
}
