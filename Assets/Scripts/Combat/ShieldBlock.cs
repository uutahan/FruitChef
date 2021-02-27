using UnityEngine;

namespace SwordShield.Combat
{
    public class ShieldBlock : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Projectile>() == null) return;

            Destroy(other.gameObject);
        }
    }
}
