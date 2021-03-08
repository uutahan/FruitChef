using UnityEngine;

namespace SwordShield.Core
{
    public class EnterScreenGetNormalBestScore : MonoBehaviour
    {
        private TMPro.TMP_Text normalBestScore;

        void Start()
        {
            normalBestScore = GetComponent<TMPro.TextMeshProUGUI>();

            int bestScore = PlayerPrefs.GetInt("NormalBestScore", 0);
            normalBestScore.text = "BEST SCORE: " + bestScore.ToString();
        }
    }
}
