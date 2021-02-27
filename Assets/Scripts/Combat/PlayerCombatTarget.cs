using UnityEngine;
using SwordShield.ICombat;
using SwordShield.Core;

namespace SwordShield.Combat
{
    [RequireComponent(typeof(Health))]
    public class PlayerCombatTarget : MonoBehaviour, IPlayerTargetable
    {
        public Health getHealthComponent()
        {
            return GetComponent<Health>();
        }
    }
}
