using SwordShield.Control;
using SwordShield.Core.GameInputs;

namespace SwordShield.States.PlayerStates
{
    public interface PlayerState
    {
        PlayerState HandleInput(GameInput input);
        void UpdateLoop(PlayerController player);

        void Enter(PlayerController player);
        void Exit(PlayerController player);
    }
}
