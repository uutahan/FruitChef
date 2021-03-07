using UnityEngine;

namespace SwordShield.Core
{
    public class Game : MonoBehaviour
    {

        [SerializeField]
        public bool isNormalMode;

        private static Game instance;


        void Awake()
        {
            //gameobject persist over the scenes
            DontDestroyOnLoad(this);

            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this);
            }
        }


    }
}
