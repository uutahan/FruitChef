using UnityEngine;

namespace SwordShield.Combat
{
    public class SwordSpawn : MonoBehaviour
    {
        [SerializeField]
        private AnimatorOverrideController weaponAnimatorOverride = null;

        

        public void Spawn(Transform weaponParentTransform, Animator animator)
        {
            if (gameObject != null)
            {
                Instantiate(gameObject, weaponParentTransform);
            }
            if (weaponAnimatorOverride != null)
            {
                //animator.runtimeAnimatorController = weaponAnimatorOverride;
            }
        }

    }
}
