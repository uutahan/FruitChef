using UnityEngine;
using UnityEngine.AI;
using SwordShield.IMovement;

namespace SwordShield.Movement
{
    public class AIMover : Mover
    {
        [SerializeField]
        private AudioSource audioSourceAppleMove = null;


        public override void MoveTo(Vector3 destination)
        {
            if (!audioSourceAppleMove.isPlaying)
            {
                audioSourceAppleMove.PlayOneShot(audioClip,0.5f);
            }

            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public override void Cancel()
        {
            navMeshAgent.isStopped = true;
            //GetComponent<Animator>().SetFloat("forwardSpeed", 0);
        }

    }

}
