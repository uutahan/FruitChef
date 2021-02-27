using UnityEngine;

namespace SwordShield.Core
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private float health = 100;

        private bool _isDead = false;

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public bool IsDead
        {
            get
            {
                return _isDead;
            }
        }

        public void TakeDamage(float damage)
        {
            float newHealth = health - damage;
            health = Mathf.Max(newHealth, 0);

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (_isDead == false)
            {
                _isDead = true;
                GetComponent<Animator>().SetTrigger("dieTrigger");
            }
        }
    }
}
