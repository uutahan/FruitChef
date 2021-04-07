using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwordShield.Core
{
    public class GameOver : MonoBehaviour
    {
        //public GameObject TinySauce;
        //private GameObject ts ;

        public void ReturnMainMenu()
        {
           
            //ts.OnGameFinished();
            SceneManager.LoadScene(0);
        }

        public void Retry()
        {
            //ts.OnGameFinished();
            //ts.OnGameStarted();
            SceneManager.LoadScene(1);
        }

        /*private void Start()
        {
            TinySauce = AssetDatabase.LoadAssetAtPath("Assets/VoodooPackages/TinySauce/Prefabs/TinySauce.prefab", typeof(GameObject));
            ts = Instantiate(TinySauce);
        }*/
    }
}
