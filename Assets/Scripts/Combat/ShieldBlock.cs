using UnityEngine;

namespace SwordShield.Combat
{
    public class ShieldBlock : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem panEffect = null;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Projectile>() == null) return;

            Destroy(other.gameObject);

            if (panEffect != null)
            {
                Vector3 rot = other.transform.rotation.eulerAngles;
                //rot = new Vector3(rot.x, rot.y + 180, rot.z);
                ParticleSystem newEffect = Instantiate(panEffect, other.transform.position, Quaternion.Euler(rot));

                Destroy(newEffect.gameObject, 2f);
            }
        }
    }
}
