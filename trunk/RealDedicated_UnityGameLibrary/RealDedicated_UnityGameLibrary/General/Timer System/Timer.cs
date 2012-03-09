using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class Timer : MonoBehaviour
    {
        #region Members
        public double timerRate;
        public double timerActivateTime;
        public string messageToReturn;
        protected bool repeatingTimer;
        #endregion

        #region Methods
        private void SetTimerActivateTime()
        {
            this.timerActivateTime = Time.time + this.timerRate;
        } 

        private void Update()
        {
            if (Time.time >= this.timerActivateTime)
            {
                this.ActivateTimer();

                if (this.repeatingTimer)
                    this.SetTimerActivateTime();
                else
                    this.DestroyTimer();
            }
        }

        private void ActivateTimer()
        {
            this.gameObject.SendMessage(this.messageToReturn, null, SendMessageOptions.DontRequireReceiver);
        }

        private void DestroyTimer()
        {
            Destroy(this);
        }
        #endregion

        #region Events
        public void SetProperties(double newTimerRate, string newMessageToReturn, bool timerRepeats)
        {
            this.timerRate = newTimerRate;
            this.SetTimerActivateTime();

            this.messageToReturn = newMessageToReturn;
            this.repeatingTimer = timerRepeats;
        }
        #endregion

    }
}
