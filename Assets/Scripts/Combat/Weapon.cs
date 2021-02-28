using SwordShield.Core;
using UnityEngine;

namespace SwordShield.Combat
{
    [CreateAssetMenu(fileName ="Weapon",menuName ="Weapons/Make New Weapon",order =0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField]
        private AnimatorOverrideController weaponAnimatorOverride = null;

        [SerializeField]
        public GameObject weaponPrefab=null;

        
        private float _weaponRange = 7f;


        [SerializeField]
        private float _weaponDamage = 20f;

        [SerializeField]
        private Projectile projectile = null;

        public bool HasProjectile()
        {
            return projectile != null;
        }

        public void LaunchProjectile(IHealth target, Transform projectileTransform)
        {
            Projectile projectileInstance = Instantiate(projectile, projectileTransform.position, Quaternion.identity);
            projectileInstance.Target = target;
            projectileInstance.Damage = _weaponDamage;
        }

        public void Spawn(Transform weaponParentTransform, Animator animator)
        {
            if(weaponPrefab != null)
            {
                Instantiate(weaponPrefab, weaponParentTransform);
            }
            if (weaponAnimatorOverride != null)
            {
                //animator.runtimeAnimatorController = weaponAnimatorOverride;
            }
        }

        public float WeaponRange
        {
            get
            {
                return _weaponRange;
            }

            set { _weaponRange = value; }
        }

        public float WeaponDamage
        {
            get
            {
                return _weaponDamage;
            }
        }
    }
}
