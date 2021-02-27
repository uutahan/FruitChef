using UnityEngine;

using SwordShield.IMovement;
using SwordShield.ICombat;

namespace SwordShield.Combat
{
    public class ShieldedFighter : MonoBehaviour, IFighter
    {

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

            SpawnWeapon();
            SpawnShield();

            swordAttack = FindObjectOfType<SwordAttack>(); //sword.GetComponent<SwordAttack>();  
        }

        public void Cancel()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("cancelAttackTrigger");

            swordAttack.IsCollide = false;
        }

        public void FighterUpdate()
        {
            GetComponent<Animator>().ResetTrigger("cancelAttackTrigger");
            GetComponent<Animator>().SetTrigger("attack");
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

            Animator animator = GetComponent<Animator>();
            swordSpawn.Spawn(weaponParentTransform, animator);
        }

        ////attack animation start event
        //private void AttackAnimationStartEvent()
        //{
        //    swordAttack.IsCollide = true;
        //}

        ////attack animation end event
        //private void AttackAnimationEndEvent()
        //{
        //    swordAttack.IsCollide = false;
        //}

        //attack animation start event
        private void AttackBeginAnimEvent()
        {
            Debug.Log("ATTACK ANIM EVENT BEGIN");
            swordAttack.IsCollide = true;
        }

        //attack animation end event
        private void AttackEndAnimEvent()
        {
            Debug.Log("ATTACK ANIM EVENT END");
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
