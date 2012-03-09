using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class TimerBuilder
    {
        #region Members

        #endregion

        #region Constructors
        public static void CreateOneShotTimer(GameObject timersObject, double timerLength, string messageToReturn)
        {
            CreateTimer(timersObject, timerLength, messageToReturn, false);
        }

        public static void CreateRepeatingTimer(GameObject timersObject, double timerLength, string messageToReturn)
        {
            CreateTimer(timersObject, timerLength, messageToReturn, true);
        }
        #endregion

        #region Methods
        private static void CreateTimer(GameObject timersObject, double timerLength, string messageToReturn, bool repeating)
        {
            timersObject.AddComponent<Timer>();
            timersObject.GetComponent<Timer>().SetProperties(timerLength, messageToReturn, repeating);
        }
        #endregion
    }
}
