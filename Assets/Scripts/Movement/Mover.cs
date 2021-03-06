using UnityEngine;
using UnityEngine.AI;
using SwordShield.IMovement;

namespace SwordShield.Movement
{
    public class Mover : MonoBehaviour, IMover
    {
        protected NavMeshAgent navMeshAgent;

        private AudioSource audioSource = null;

        [SerializeField]
        protected AudioClip audioClip;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
           
        }

        public void EnableNavMeshAgent(bool isEnable)
        {
            navMeshAgent.enabled = isEnable;
        }

        public void MoverStart()
        {
            navMeshAgent=GetComponent<NavMeshAgent>();
        }

        public void MoverUpdate()
        {
            UpdateAnimator();
        }


        public virtual void MoveTo(Vector3 velocity)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioClip, 3);
            }

            navMeshAgent.velocity = velocity;
            navMeshAgent.isStopped = false;

            
        }

        public virtual void Cancel()
        {
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);

            

            float speed = localVelocity.z;
            //if(speed > 2)
            //{
            //    speed = 1;
            //}
            //else
            //{
            //    speed = 0;
            //}

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }

}
