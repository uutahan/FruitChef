using UnityEngine;
using UnityEngine.AI;
using SwordShield.IMovement;

namespace SwordShield.Movement
{
    public class AIMover : Mover
    {
        public override void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public override void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

    }

}
