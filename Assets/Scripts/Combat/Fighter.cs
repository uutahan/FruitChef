﻿using UnityEngine;
using SwordShield.ICombat;
using SwordShield.IMovement;
using SwordShield.Core;
using System.Collections;

namespace SwordShield.Combat
{
    public class Fighter : MonoBehaviour, IFighter
    {
        private AppleAttackAnimation appleAttackAnimation;
        private Animator animator;

        private bool isAttacking = false;

        protected IMover mover;

        [SerializeField]
        public Weapon weapon = null;

        [SerializeField]
        protected Transform weaponParentTransform = null;

        [SerializeField] 
        protected float timeBetweenAttacks=1f; //in sec.

        private float _weaponRange;

        public float WeaponRange
        {
            get
            {
                return _weaponRange;
            }

            set { _weaponRange = value; }
        }



        protected float timeSinceLastAttack= Mathf.Infinity; //in sec.
        
        protected IHealth target;



        private void AttackStart()
        {
            isAttacking = true;
        }

        private void AttackEnd()
        {
            isAttacking = false;
        }

        private void Start() //called just once
        {
            animator = GetComponent<Animator>();

            appleAttackAnimation = animator.GetBehaviour<AppleAttackAnimation>();
            appleAttackAnimation.AppleAttackEnter += AttackStart;
            appleAttackAnimation.AppleAttackExit += AttackEnd;

            SpawnWeapon();
        }

        public virtual void FighterStart() // called everytime state changes to fight.
        {
            mover = GetComponent<IMover>();
            mover.MoverStart();
        }

        protected void SpawnWeapon()
        {
            if (weapon == null) return;

            weapon.Spawn(weaponParentTransform, animator);
        }

        public void Attack(ITargetable target)
        {
            this.target = target.getHealthComponent();
        }

        public virtual void Cancel()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("cancelAttackTrigger");
            this.target = null;
        }

        public virtual void FighterUpdate()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (target.IsDead) return;

            float distance = Vector3.Distance(transform.position, target.GetGameObject().transform.position);

            bool isInRange = distance < _weaponRange;

            if (!isInRange)
            {
                if (!isAttacking)
                {
                    mover.MoveTo(target.GetGameObject().transform.position);
                }
            }
            else
            {
                mover.Cancel();
                AttackBehaviour();
            }
        }

        public bool CanAttack(ITargetable target)
        {
            if (target == null) { return false; }

            IHealth targetToTest = target.getHealthComponent();
            return (targetToTest != null) && (targetToTest.IsDead == false);
        }

        private void AttackBehaviour()
        {
            //TODO: Look target slowly according to timeSincelastattack and timebetween attacks.

            //transform.LookAt(target.GetGameObject().transform);

            float remainingTime=Mathf.Max(timeBetweenAttacks - timeSinceLastAttack, 0);
            float angularSpeed = 180 / remainingTime;

            var q = Quaternion.LookRotation(target.GetGameObject().transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, angularSpeed * Time.deltaTime);

            //float a = Mathf.Max(timeBetweenAttacks - timeSinceLastAttack, 0) / timeBetweenAttacks;
            //transform.rotation = Quaternion.Slerp(transform.rotation, q, 1-a);


            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                animator.ResetTrigger("cancelAttackTrigger");
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0;
                //since attack animation trigger is set,
                //this will trigger hit animation event.
            }
            
        }


        //Animation Hit Event
        private void AnimationHitCallBack()
        {
            if (target == null) return;

            if (weapon.HasProjectile())
            {
                weapon.LaunchProjectile(target, weaponParentTransform);
            }
            else
            {
                target.TakeDamage(weapon.WeaponDamage);
            }
            
            
        }
        //Animation Hit Event archer
        private void Shoot()
        {
            AnimationHitCallBack();
        }

        //Animation Hit Event archer
        private void AppleShoot()
        {
            AnimationHitCallBack();
        }


    }
}


