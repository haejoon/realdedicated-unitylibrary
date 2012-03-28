using UnityEngine;


namespace RealDedicated_UnityGameLibrary
{
    public class ValueMapReference : ReferencableObjectList
    {
        protected override void GetObjects()
        {
            base.GetObjects();

            ValueMap[] tempScoreSheets = this.gameObject.GetComponents<ValueMap>();
            ReferencableObject[] tempRefObjects = new ReferencableObject[tempScoreSheets.Length];
            Debug.Log("I found: " + tempScoreSheets.Length + " Score Sheets");

            for(int i = 0; i < tempRefObjects.Length; i++)
            {
                Debug.Log("Score sheet: " + i);
                tempRefObjects[i] = new ReferencableObject();
                tempRefObjects[i].ObjectName = tempScoreSheets[i].ValueMapName;
                tempRefObjects[i].ObjectToReference = tempScoreSheets[i];
            }

            this.Objects = new ReferencableObject[tempRefObjects.Length];
            this.Objects = tempRefObjects;
        }

        protected override void NameObjects()
        {
            for (int i = 0; i < this.Objects.Length; i++)
            {
                string scoreSheetName = (this.Objects[i].ObjectToReference as ValueMap).ValueMapName;

                if (scoreSheetName != "")
                {
                    this.Objects[i].ObjectName = scoreSheetName;
                }
            }

            base.NameObjects();
        }

        /// <summary>
        /// Returns a score from a connected value. 
        /// </summary>
        /// <param name="connectedValue"></param>
        /// <returns></returns>
        protected virtual float GetScoreFromValue(string connectedValue)
        {
            foreach (ReferencableObject childObject in this.Objects)
            {
                ValueMap.ValueItem[] valueMap = (childObject.ObjectToReference as ValueMap).ValueItems;

                foreach (ValueMap.ValueItem childValueItem in valueMap)
                {
                    if (childValueItem.value == connectedValue)
                    {
                        return childValueItem.score;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Returns a score from a connected value from a specific ScoreSheet
        /// </summary>
        /// <param name="connectedValue"></param>
        /// <returns></returns>
        protected virtual float GetScoreFromValue(string connectedValue, string scoreSheetName)
        {
            foreach (ReferencableObject childObject in this.Objects)
            {
                if ((childObject.ObjectToReference as ValueMap).ValueMapName == scoreSheetName)
                {
                    ValueMap.ValueItem[] valueMap = (childObject.ObjectToReference as ValueMap).ValueItems;

                    foreach (ValueMap.ValueItem childValueItem in valueMap)
                    {
                        if (childValueItem.value == connectedValue)
                        {
                            return childValueItem.score;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
