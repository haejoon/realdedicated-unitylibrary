using UnityEngine;

namespace RealDedicated_UnityGameLibrary.General.Score_System
{
    public class CSVToScoreValueSheetParser : MonoBehaviour
    {
        public TextAsset csvFile;
        public char separator;

        public void Awake()
        {
            if (this.csvFile != null && this.separator != null)
                this.CreateScoreValueSheet();
        }

        private void CreateScoreValueSheet()
        {
            this.gameObject.AddComponent<ScoreValueSheet>();

            ScoreValueSheet tempValueSheet = this.gameObject.GetComponent<ScoreValueSheet>();
            tempValueSheet.ValueSheetName = this.csvFile.name;
            string[] parsedCSV = this.ParseCSV();

            tempValueSheet.ValueMap = new ScoreValueSheet.ValueItem[parsedCSV.Length];

            this.SetValues(parsedCSV, tempValueSheet);
        }

        private string[] ParseCSV()
        {
            string[] parsedCSVFile = this.csvFile.text.Split('\n');

            Debug.Log("New Lines: " + parsedCSVFile.ToString());

            return parsedCSVFile;
        }

        private void SetValues(string[] parsedCSV, ScoreValueSheet valueSheet)
        {
            for (int i = 0; i < parsedCSV.Length; i++)
            {
                valueSheet.ValueMap[i] = this.GetValueItem(parsedCSV[i]);
            }
        }

        private ScoreValueSheet.ValueItem GetValueItem(string valueString)
        {
            ScoreValueSheet.ValueItem tempValueItem = null;

            string[] splitValueString = valueString.Split(this.separator);
            
            float tempScore = 0;
            float parsedFloat = 0;
            if (float.TryParse(splitValueString[1].ToString(), out parsedFloat))
            {
                tempScore = parsedFloat;
                Debug.Log("Successfully parsed float");
            }

            tempValueItem = new ScoreValueSheet.ValueItem(splitValueString[0], tempScore);

            return tempValueItem;
        }

    }
}
