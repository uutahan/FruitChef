using SwordShield.Core;
using UnityEngine;

namespace SwordShield.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1;

        [SerializeField]
        private float maxLifeTime = 10;

        private IHealth _target = null;
        private float _damage = 0;

        private void Start()
        {
            Vector3 toLook = getAimLocation();
            Vector3 newLook = new Vector3(toLook.x, gameObject.transform.position.y, toLook.z);
            transform.LookAt(newLook);
            Destroy(gameObject, maxLifeTime);
        }

        private void Update()
        {
            if (_target == null) { return; }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public IHealth Target
        {
            set
            {
                _target = value;
            }
        }

        public float Damage
        {
            set
            {
                _damage = value;
            }
        }

        private Vector3 getAimLocation()
        {
            CapsuleCollider collider = _target.GetGameObject().GetComponent<CapsuleCollider>();
            if (collider == null)
            {
                Debug.Log("Player collider null");
                return _target.GetGameObject().transform.position;
            }

            float height = collider.height;
            return _target.GetGameObject().transform.position + (Vector3.up * (height / 1.5f) );

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IHealth>() != _target) return;

            if (_target.IsDead) return;

            _target.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}
