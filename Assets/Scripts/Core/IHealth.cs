using UnityEngine;

namespace SwordShield.Core
{
    public interface IHealth
    {
        void TakeDamage(float damage);
        bool IsDead {  get; }
        GameObject GetGameObject();

    }
}
