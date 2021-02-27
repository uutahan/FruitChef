using SwordShield.Core;
using UnityEngine;

namespace SwordShield.ICombat
{
    public interface IFighter : IAction
    {
        void Attack(ITargetable target);
        void FighterStart();
        void FighterUpdate();
        bool CanAttack(ITargetable target);
    }
}
