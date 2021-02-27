using SwordShield.Control;
using SwordShield.Core.GameInputs;

namespace SwordShield.States.AIStates
{
    public interface AIState
    {
        AIState CheckStateChange();
        void UpdateLoop(AIController player);

        void Enter(AIController player);
        void Exit(AIController player);
    }
}
