using UnityEngine;
using SwordShield.Combat;
using System.Collections;
using System;

namespace SwordShield.Core
{
    public class ScoreManager : MonoBehaviour
    {
        public Game game;

        [SerializeField]
        private GameObject scoreTextGO;

        private TMPro.TMP_Text textScore;

        [SerializeField]
        private GameObject bestScoreTextGO;

        private TMPro.TMP_Text textBestScore;

        [SerializeField]
        private GameObject gameOverPanel = null;

        [SerializeField]
        private GameObject endGameScoreGO;

        private TMPro.TMP_Text endGameTextScore;

        private int bestScore;

        private void Start()
        {
            textScore = scoreTextGO.GetComponent<TMPro.TextMeshProUGUI>();
            textBestScore = bestScoreTextGO.GetComponent<TMPro.TextMeshProUGUI>();
            endGameTextScore = endGameScoreGO.GetComponent<TMPro.TextMeshProUGUI>();

            if (game.isNormalMode)
            {
                bestScore = PlayerPrefs.GetInt("NormalBestScore", 0);
            }
            else if (!game.isNormalMode)
            {
                bestScore = PlayerPrefs.GetInt("SurvivalBestScore", 0);
            }

        }

        private IEnumerator GameOverScreen()
        {
            yield return new WaitForSeconds(1.5f);

            if (gameOverPanel != null)
            {
                string text = textScore.text;
                //string scoreInText=text.Substring(7);


                int score = int.Parse(text);

                if (score > bestScore)
                {
                    if (game.isNormalMode)
                    {
                        PlayerPrefs.SetInt("NormalBestScore", score);
                    }
                    else if (!game.isNormalMode)
                    {
                        PlayerPrefs.SetInt("SurvivalBestScore", score);
                    }

                    bestScore = score;
                }


                textBestScore.text = "BEST SCORE: " + bestScore;
                endGameTextScore.text = text;
                scoreTextGO.SetActive(false);
                gameOverPanel.SetActive(true);
                
            }
        }

        public void DoGameOver()
        {
            StartCoroutine(GameOverScreen());
        }
    }
}
