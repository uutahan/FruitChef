using SwordShield.Control;
using SwordShield.Core.GameInputs;
using SwordShield.IMovement;

namespace SwordShield.States.AIStates
{
    public class DeadState : AIState
    {
        private IMover mover;

        public AIState CheckStateChange()
        {
            return null;
        }

        public void Enter(AIController AI)
        {
            mover = AI.GetComponent<IMover>();
            mover.MoverStart();
            mover.EnableNavMeshAgent(false);
        }

        public void Exit(AIController AI)
        {
            
        }

        public void UpdateLoop(AIController AI)
        {
            
        }
    }
}
