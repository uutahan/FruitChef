using UnityEngine;

namespace SwordShield.Combat
{
    [CreateAssetMenu(fileName = "Shield", menuName = "Shields/Make New Shield", order = 0)]
    public class Shield : ScriptableObject
    {

        [SerializeField]
        private GameObject shieldPrefab = null;

        public void Spawn(Transform parentTransform)
        {
            if (shieldPrefab != null)
            {
                Instantiate(shieldPrefab, parentTransform);
            }
        }
    }
}
