using UnityEngine;

namespace RealDedicated_UnityGameLibrary.General.Score_System
{
    public class CSVToValueMapParser : MonoBehaviour
    {
        public TextAsset csvFile;
        public string separator = ",";

        public void Awake()
        {
            if (this.csvFile != null && this.separator != null)
                this.CreateScoreValueSheet();
        }

        private void CreateScoreValueSheet()
        {
            ValueMap tempValueSheet = this.gameObject.AddComponent<ValueMap>();
            tempValueSheet.ValueMapName = this.csvFile.name;
            string[] parsedCSV = this.ParseCSV();

            tempValueSheet.ValueItems = new ValueMap.ValueItem[parsedCSV.Length];

            this.SetValues(parsedCSV, tempValueSheet);

            Destroy(this);
        }

        private string[] ParseCSV()
        {
            string[] parsedCSVFile = this.csvFile.text.Split('\n');

            Debug.Log(this.csvFile.text);

            return parsedCSVFile;
        }

        private void SetValues(string[] parsedCSV, ValueMap valueSheet)
        {
            for (int i = 0; i < parsedCSV.Length; i++)
            {
                valueSheet.ValueItems[i] = this.GetValueItem(parsedCSV[i]);
            }
        }

        private ValueMap.ValueItem GetValueItem(string valueString)
        {
            ValueMap.ValueItem tempValueItem = null;

            string[] splitValueString = valueString.Split(this.separator[0]);
            
            float tempScore = 0;
            float parsedFloat = 0;
            if (float.TryParse(splitValueString[1].ToString(), out parsedFloat))
            {
                tempScore = parsedFloat;
            }

            tempValueItem = new ValueMap.ValueItem(splitValueString[0], tempScore);

            return tempValueItem;
        }

    }
}
