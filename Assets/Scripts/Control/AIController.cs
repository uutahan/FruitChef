using SwordShield.States.AIStates;
using UnityEngine;

namespace SwordShield.Control
{
    public class AIController : MonoBehaviour
    {
        private AIState _state;

        void Start()
        {
            
            _state = new ChasingState();
            _state.Enter(this);
        }

        void Update()
        {
            UpdateState();
            _state.UpdateLoop(this);
        }

        private void UpdateState()
        {
            AIState state = _state.CheckStateChange();

            if (state != null)
            {
                _state.Exit(this);
                _state = state;
                _state.Enter(this);
            }
        }
    }
}
