using SwordShield.Combat;
using UnityEngine;
using SwordShield.Core;

namespace SwordShield.ICombat
{
    public interface ITargetable
    {
        Health getHealthComponent();
    }
}