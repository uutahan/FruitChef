using UnityEngine;
using SwordShield.ICombat;
using SwordShield.Core;

namespace SwordShield.Combat
{
    public class SwordAttack : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem effect = null;

        private bool _isCollide;

        public bool IsCollide
        {
            get { return _isCollide; }
            set { _isCollide = value; }
        }

        [SerializeField]
        private float _damage = 50f;

        public float Damage
        {
            set { _damage = value; }
            get { return _damage; }
        }

        private void Awake()
        {
           _isCollide = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isCollide == false) return;

            if (other.GetComponent<IPlayerTargetable>() == null) return;

            IHealth target = other.GetComponent<IHealth>();
            target.TakeDamage(_damage);

            if (target.IsDead)
            {
                Destroy(target.GetGameObject());
            }

            if(effect != null)
            {
                Vector3 rot = other.transform.rotation.eulerAngles;
                rot = new Vector3(rot.x, rot.y + 180, rot.z);
                ParticleSystem newEffect=Instantiate(effect, other.transform.position, Quaternion.Euler(rot));
                Destroy(newEffect.gameObject, 6f);
            }

            //particle.enableEmission = true;
        }
    }
}
