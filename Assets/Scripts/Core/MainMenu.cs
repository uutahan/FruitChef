using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordShield.Core
{
    public class MainMenu : MonoBehaviour
    {
        public Game game;

        public void PlayNormal()
        {
            game.isNormalMode = true;
            DontDestroyOnLoad(game);
            SceneManager.LoadScene(1);
        }

        public void PlaySurvival()
        {
            game.isNormalMode = false;
            DontDestroyOnLoad(game);
            SceneManager.LoadScene(1);
        }
    }
}
