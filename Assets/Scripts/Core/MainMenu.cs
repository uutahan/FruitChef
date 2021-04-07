using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordShield.Core
{
    public class MainMenu : MonoBehaviour
    {
        public Game game;
        //public GameObject TinySauce;
        //private GameObject ts ;

        public void PlayNormal()
        {
            //ts.OnGameStarted();
            game.isNormalMode = true;
            DontDestroyOnLoad(game);
            SceneManager.LoadScene(1);
        }

        public void PlaySurvival()
        {
            //ts.OnGameStarted();
            game.isNormalMode = false;
            DontDestroyOnLoad(game);
            SceneManager.LoadScene(1);
        }

        /*private void Start()
        {
            TinySauce = AssetDatabase.LoadAssetAtPath("Assets/VoodooPackages/TinySauce/Prefabs/TinySauce.prefab", typeof(GameObject));
            ts = Instantiate(TinySauce);
        }*/
    }
}
