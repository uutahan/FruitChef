using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordShield.Core
{
    public class GameOver : MonoBehaviour
    {
        public void ReturnMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void Retry()
        {
            SceneManager.LoadScene(1);
        }
    }
}
