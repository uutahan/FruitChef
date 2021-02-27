using SwordShield.Core;
using UnityEngine;

namespace SwordShield.IMovement
{
    public interface IMover : IAction
    {
        void MoverStart();
        void MoverUpdate();
        void MoveTo(Vector3 velocity); //cancels attack action
        void EnableNavMeshAgent(bool isEnable);
    }
}

