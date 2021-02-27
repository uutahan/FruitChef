using UnityEngine;
using SwordShield.Core.GameInputs;
using SwordShield.States.PlayerStates;

namespace SwordShield.Control
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerState _state;
        private Joystick joystick;

        [SerializeField]
        private float runSpeed=7f;

        private float _horizontalMove = 0f;
        private float _verticalMove = 0f;

        public float HorizantalMove
        {
            get { return _horizontalMove; }
        }

        public float VerticalMove
        {
            get { return _verticalMove; }
        }
        public float RunSpeed
        {
            get { return runSpeed; }
        }

        void Start()
        {
            joystick = FindObjectOfType<Joystick>();
            _state = new MovingState();
            _state.Enter(this);
        }

        void Update()
        {
            GameInput input;

            _verticalMove = 0;
            _horizontalMove = 0;

            if (joystick.Horizontal > 0.2f)
            {
                _horizontalMove = runSpeed;
            }
            else if (joystick.Horizontal < -0.2f)
            {
                _horizontalMove = -runSpeed;
            }

            if (joystick.Vertical > 0.2f)
            {
                _verticalMove = -runSpeed;
            }
            else if (joystick.Vertical < -0.2f)
            {
                _verticalMove = runSpeed;
            }



            if(_horizontalMove!=0 || _verticalMove != 0)
            {
                input = GameInput.MoveInput;
            }

            else if (Input.GetMouseButtonDown(1))
            {
                input = GameInput.AttackInput;
            }

            else
            {
                input = GameInput.None;
            }


            //if (Input.GetMouseButtonDown(0))
            //{
            //    input = GameInput.LeftClick;
            //}
            //else
            //{
            //    input = GameInput.None;
            //}

            HandleInput(input);
            _state.UpdateLoop(this);
        }

        private void HandleInput(GameInput input)
        {
            PlayerState state = _state.HandleInput(input);
            
            if (state != null)
            {
                _state.Exit(this);
                _state = state;
                _state.Enter(this);
            }
        }

    }

}
