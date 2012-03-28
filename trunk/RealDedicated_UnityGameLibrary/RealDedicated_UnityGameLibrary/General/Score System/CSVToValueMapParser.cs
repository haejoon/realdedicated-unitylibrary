using UnityEngine;

namespace RealDedicated_UnityGameLibrary.General.Score_System
{
    public class CSVToValueMapParser : MonoBehaviour
    {
        public TextAsset[] csvFiles;
        public string separator = ",";

        public void Awake()
        {
            if (this.csvFiles != null && this.separator != null)
                this.CreateScoreValueSheets();
        }

        private void CreateScoreValueSheets()
        {
            foreach (TextAsset csvFile in this.csvFiles)
            {
                ValueMap tempValueSheet = this.gameObject.AddComponent<ValueMap>();
                tempValueSheet.ValueMapName = csvFile.name;
                string[] parsedCSV = this.ParseCSV(csvFile);

                tempValueSheet.ValueItems = new ValueMap.ValueItem[parsedCSV.Length];

                this.SetValues(parsedCSV, tempValueSheet);
            }

            Destroy(this);
        }

        private string[] ParseCSV(TextAsset csvFile)
        {
            string[] parsedCSVFile = csvFile.text.Split('\n');

            Debug.Log(csvFile.text);

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
