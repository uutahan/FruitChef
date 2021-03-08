using UnityEngine;

namespace SwordShield.Core
{
    public class EnterScreenGetSurvivalBestScore : MonoBehaviour
    {
        private TMPro.TMP_Text survivalBestScore;

        void Start()
        {
            survivalBestScore = GetComponent<TMPro.TextMeshProUGUI>();

            int bestScore = PlayerPrefs.GetInt("SurvivalBestScore", 0);
            survivalBestScore.text = "BEST SCORE: " + bestScore.ToString();
        }
    }
}
