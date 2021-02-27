using UnityEngine;
using SwordShield.ICombat;
using SwordShield.Core;

namespace SwordShield.Combat
{
    [RequireComponent(typeof(Health))]
    public class AICombatTarget : MonoBehaviour, IAITargetable
    {
        public Health getHealthComponent()
        {
            return GetComponent<Health>();
        }
    }
}
