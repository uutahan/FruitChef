using SwordShield.Control;
using SwordShield.Core.GameInputs;
using SwordShield.IMovement;

namespace SwordShield.States.PlayerStates
{
    public class DeadState : PlayerState
    {
        private IMover mover;

        public void Enter(PlayerController player)
        {
            mover = player.GetComponent<IMover>();
            mover.MoverStart();
            mover.EnableNavMeshAgent(false);
        }

        public void Exit(PlayerController player)
        {
            
        }

        public PlayerState HandleInput(GameInput input)
        {
            return null;
        }

        public void UpdateLoop(PlayerController player)
        {
            
        }
    }
}
