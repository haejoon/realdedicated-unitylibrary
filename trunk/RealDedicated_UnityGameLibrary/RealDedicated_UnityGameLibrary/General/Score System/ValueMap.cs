using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ValueMap : MonoBehaviour
    {
        [System.Serializable]
        public sealed class ValueItem
        {
            public string value;
            public float score;

            public ValueItem(string newValue, float newScore)
            {
                value = newValue;
                score = newScore;
            }
        }

        #region Members
        [UnityEngine.SerializeField]
        private string valueMapName;
        [UnityEngine.SerializeField]
        private ValueItem[] valueItems;
        #endregion

        #region Properties
        public string ValueMapName
        {
            get { return this.valueMapName; }
            set { this.valueMapName = value; }
        }

        public ValueItem[] ValueItems
        {
            get { return this.valueItems; }
            set { this.valueItems = value; }
        }
        #endregion

        /// <summary>
        /// Returns a score from a connected value. 
        /// </summary>
        /// <param name="connectedValue"></param>
        /// <returns></returns>
        public float GetScoreFromValue(string connectedValue)
        {
            foreach (ValueItem childValueItem in this.ValueItems)
            {
                if (childValueItem.value == connectedValue)
                {
                    return childValueItem.score;
                }
            }

            return 0;
        }
    }
}
