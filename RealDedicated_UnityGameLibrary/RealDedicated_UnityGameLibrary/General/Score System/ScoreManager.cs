using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ScoreManager : MonoBehaviour
    {
        [System.Serializable]
        public sealed class Score
        {
            public string scoreName;
            public float score;

            public Score(string scoreName, float score)
            {
                this.scoreName = scoreName;
                this.score = score;
            }
        }

        #region Members
        [UnityEngine.SerializeField]
        private Score[] scores;

        public delegate void ScoreHandler(string scoreName, string valueName);
        public delegate void ScoreHandlerLong(string scoreName, string valueName, string valueMapName);
        public static event ScoreHandler scoreUpdate;
        #endregion

        #region Properties
        public Score[] Scores
        {
            get { return this.scores; }
            set { this.scores = value; }
        }
        #endregion

        public void OnEnable()
        {
            ScoreManager.scoreUpdate += new ScoreHandler(ScoreManager_scoreUpdate);
        }

        public void OnDisable()
        {
            ScoreManager.scoreUpdate -= ScoreManager_scoreUpdate;
        }

        #region Events
        public Score GetScore(string nameOfScore)
        {
            Score tempScore = null;

            foreach (Score childScore in this.Scores)
            {
                if (childScore.scoreName == nameOfScore)
                {
                    tempScore = childScore;
                    break;
                }
            }

            return tempScore;
        }

        public void ScoreManager_scoreUpdate(string scoreName, string valueName)
        {
            Debug.Log("Short Score Updater was called");
        }

        public void ScoreManager_scoreUpdate(string scoreName, string valueName, string valueMapName)
        {
            Debug.Log("LOOONG Score Updater was called; hurray!");
        }
        #endregion
    }
}
