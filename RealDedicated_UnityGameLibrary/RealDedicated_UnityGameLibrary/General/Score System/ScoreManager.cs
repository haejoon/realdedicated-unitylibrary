using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    public class ScoreManager : MonoBehaviour
    {
        #region Static Instance
        private static ScoreManager classInstance = null;

        public static ScoreManager instance
        {
            get
            {
                if (classInstance == null)
                {
                    classInstance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
                }

                if (classInstance == null)
                {
                    GameObject newObj = new GameObject("ScoreManager");
                    classInstance = newObj.AddComponent(typeof(ScoreManager)) as ScoreManager;
                    Debug.Log("Could not find ScoreManager, so I made one");
                }

                return classInstance;
            }
        }
        #endregion

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
        private List<Score> scores = new List<Score>();

        public delegate void ScoreUpdater(Score scoreUpdated);
        public static event ScoreUpdater scoreUpdated;
        #endregion

        #region Properties
        public List<Score> Scores
        {
            get { return this.scores; }
            set { this.scores = value; }
        }
        #endregion

        #region Methods
        private Score CreateScore(string scoreName)
        {
            Score tempScore = new Score(scoreName, 0);
            this.Scores.Add(tempScore);

            if(scoreUpdated != null)
                scoreUpdated(tempScore);

            return tempScore;
        }

        private void AddToScoreActual(Score scoreToChange, float valueAdded)
        {
            scoreToChange.score += valueAdded;

            if (scoreUpdated != null)
                scoreUpdated(scoreToChange);
        }

        private Score GetScoreItem(string nameOfScore)
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

            if (tempScore == null)
                tempScore = this.CreateScore(nameOfScore);

            return tempScore;
        }
        #endregion

        #region Events
        public float GetScore(string nameOfScore)
        {
            return this.GetScoreItem(nameOfScore).score;
        }

        /// <summary>
        /// Adds a value to a score
        /// </summary>
        /// <param name="scoreName">Name of score to add to</param>
        /// <param name="valueToAdd">Point value added</param>
        public void AddToScore(string scoreName, float valueToAdd)
        {
            this.AddToScoreActual(this.GetScoreItem(scoreName), valueToAdd);
        }

        /// <summary>
        /// Adds a value to the score from the ValueMapReference, returns first value of that name
        /// </summary>
        /// <param name="scoreName">Name of score to add to</param>
        /// <param name="valueName">Name of value to add</param>
        public void AddToScore(string scoreName, string valueName)
        {
            this.AddToScoreActual(this.GetScoreItem(scoreName), ValueMapReference.instance.GetScoreFromValue(valueName));
        }

        /// <summary>
        ///  Adds a value to the score from a specific ValueMap
        /// </summary>
        /// <param name="scoreName">Name of score to add to</param>
        /// <param name="valueMapName">Name of ValueMap to reference</param>
        /// <param name="valueName">Name of value to add</param>
        public void AddToScore(string scoreName, string valueMapName, string valueName)
        {
            this.AddToScoreActual(this.GetScoreItem(scoreName), ValueMapReference.instance.GetScoreFromValue(valueName, valueMapName));
        }
        #endregion
    }
}
