using UnityEngine;

using SwordShield.IMovement;
using SwordShield.ICombat;
using System.Collections;

namespace SwordShield.Combat
{
    public class ShieldedFighter : MonoBehaviour, IFighter
    {
        private Animator animator;
        private AttackAnimation attackAnimation;

        private AudioSource audioSource = null;

        [SerializeField]
        public AudioClip audioClip;


        [SerializeField]
        private GameObject sword;

        private SwordAttack swordAttack;


        [SerializeField]
        protected Transform weaponParentTransform = null;




        [SerializeField]
        private Shield shield = null;

        [SerializeField]
        private Transform shieldParentTransform = null;


        private void Start() //called just once
        {
            audioSource = GetComponent<AudioSource>();

            animator = GetComponent<Animator>();

            attackAnimation = animator.GetBehaviour<AttackAnimation>();
            attackAnimation.AttackEnter += AttackStart;
            attackAnimation.AttackExit += AttackEnd;

            SpawnWeapon();
            SpawnShield();

            swordAttack = FindObjectOfType<SwordAttack>(); //sword.GetComponent<SwordAttack>();  
        }

        public void Cancel()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("cancelAttackTrigger");

            swordAttack.IsCollide = false;
        }

        public void FighterUpdate()
        {
            animator.ResetTrigger("cancelAttackTrigger");
            animator.SetTrigger("attack");
        }



        public void FighterStart()
        {
            swordAttack.IsCollide = false;
        }

        private void SpawnShield()
        {
            if (shield == null) return;

            shield.Spawn(shieldParentTransform);
        }

        
        protected void SpawnWeapon()
        {
            if (sword == null) return;
            SwordSpawn swordSpawn = sword.GetComponent<SwordSpawn>();
            if (swordSpawn == null) return;

            //Animator animator = GetComponent<Animator>();
            swordSpawn.Spawn(weaponParentTransform, animator);
        }

        private void AttackStart()
        {
            swordAttack.IsCollide = true;
            audioSource.PlayOneShot(audioClip);
        }

        private void AttackEnd()
        {
            swordAttack.IsCollide = false;
        }

        //attack animation end event
        private void AttackEndAnimEvent()
        {
            swordAttack.IsCollide = false;
        }

        public void Attack(ITargetable target)
        {
        }

        public bool CanAttack(ITargetable target)
        {
            return true;
        }

        //Animation Hit Event
        private void AnimationHitCallBack()
        {

        }
    }
}
