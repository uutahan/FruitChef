using System.Collections;
using UnityEngine;

namespace SwordShield.Core
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private float health = 100;

        private bool _isDead = false;

        [SerializeField]
        private GameObject gameOverPanel = null;

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

                StartCoroutine(GameOverScreen());
            }
        }

        private IEnumerator GameOverScreen()
        {
            yield return new WaitForSeconds(1.5f);

            if(gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}
