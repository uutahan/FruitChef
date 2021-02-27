using SwordShield.Control;
using SwordShield.Core;
using SwordShield.ICombat;
using SwordShield.IMovement;
using UnityEngine;

namespace SwordShield.States.AIStates
{
    public class ChasingState : AIState
    {
        private IHealth health;
        private IFighter fighter;
        private IAITargetable initialTarget;
        private IMover mover;
        private GameObject playerTarget;

        public ChasingState()
        {
            playerTarget = GameObject.FindWithTag("Player");
            this.initialTarget = playerTarget.GetComponent<IAITargetable>();
        }

        public void Enter(AIController AI)
        {
            mover = AI.GetComponent<IMover>();
            health = AI.GetComponent<IHealth>();
            fighter = AI.GetComponent<IFighter>();
            fighter.FighterStart();
            fighter.Attack(initialTarget);
        }

        public void Exit(AIController AI)
        {
            fighter.Cancel();
        }

        public AIState CheckStateChange()
        {
            if (health.IsDead)
            {
                return new DeadState();
            }

            

            return null;
        }

        public void UpdateLoop(AIController player)
        {
            fighter.FighterUpdate();
            mover.MoverUpdate();
        }
    }
}
