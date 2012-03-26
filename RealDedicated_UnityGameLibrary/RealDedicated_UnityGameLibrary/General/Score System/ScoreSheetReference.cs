using UnityEngine;


namespace RealDedicated_UnityGameLibrary
{
    public class ScoreSheetReference : ReferencableObjectList
    {
        protected override void GetObjects()
        {
            base.GetObjects();

            ScoreValueSheet[] tempScoreSheets = this.GetComponents<ScoreValueSheet>();
            ReferencableObject[] tempRefObjects = new ReferencableObject[tempScoreSheets.Length];

            for(int i = 0; i < tempRefObjects.Length; i++)
            {
                tempRefObjects[i].ObjectName = tempScoreSheets[i].ValueSheetName;
                tempRefObjects[i].ObjectToReference = tempScoreSheets[i];
            }

            this.Objects = tempRefObjects;
        }

        protected override void NameObjects()
        {
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
                ScoreValueSheet.ValueItem[] valueMap = (childObject.ObjectToReference as ScoreValueSheet).ValueMap;

                foreach (ScoreValueSheet.ValueItem childValueItem in valueMap)
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
                if ((childObject.ObjectToReference as ScoreValueSheet).ValueSheetName == scoreSheetName)
                {
                    ScoreValueSheet.ValueItem[] valueMap = (childObject.ObjectToReference as ScoreValueSheet).ValueMap;

                    foreach (ScoreValueSheet.ValueItem childValueItem in valueMap)
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
