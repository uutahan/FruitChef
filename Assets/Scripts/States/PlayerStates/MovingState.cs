using SwordShield.Control;
using SwordShield.Core;
using SwordShield.Core.GameInputs;
using SwordShield.ICombat;
using SwordShield.IMovement;

using UnityEngine;

namespace SwordShield.States.PlayerStates
{
    public class MovingState : PlayerState
    {
        private IMover mover;
        private IHealth health;
        private Vector3 velocity;

        private float _horizontalMove = 0f;
        private float _verticalMove = 0f;
        private float runSpeed = 0f;

        public MovingState(Vector3 destination)
        {
            velocity = destination;
        }
        public MovingState()
        {
        }

        public void Enter(PlayerController player)
        {
            health = player.GetComponent<IHealth>();
            mover = player.GetComponent<IMover>();
            mover.MoverStart();
            mover.MoveTo(velocity);
        }

        public void Exit(PlayerController player)
        {
            mover.Cancel();
        }

        public PlayerState HandleInput(GameInput input)
        {
            if (health.IsDead)
            {
                return new DeadState();
            }

            if (input == GameInput.MoveInput) 
            {
                Vector3 moveVector = new Vector3(_verticalMove, 0, _horizontalMove);
                moveVector=Vector3.ClampMagnitude(moveVector, runSpeed);

                moveVector=Quaternion.Euler(0, Camera.main.transform.eulerAngles.y + 90, 0) * moveVector;

                mover.MoveTo(moveVector);
            }

            else if(input == GameInput.AttackInput)
            {
                return new AttackingState();
            }





            //if (input == GameInput.LeftClick)
            //{
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit[] hits = Physics.RaycastAll(ray);

            //    RaycastHit lastHit=new RaycastHit();
            //    foreach (RaycastHit hit in hits)
            //    {
            //        lastHit = hit;
            //        IPlayerTargetable target = hit.transform.gameObject.GetComponent<IPlayerTargetable>();

            //        if (fighter.CanAttack(target) == false)
            //        {
            //            continue;
            //        }

            //        return new AttackingState(target);
            //    }

            //    mover.MoveTo(lastHit.point);
            //}

            //stay in this state
            return null;
        }

        public void UpdateLoop(PlayerController player)
        {
            _horizontalMove = player.HorizantalMove;
            _verticalMove = player.VerticalMove;
            runSpeed = player.RunSpeed;
            

            mover.MoverUpdate();

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //bool hasHit = Physics.Raycast(ray, out hit);
            //if (hasHit)
            //{

            //    if (Input.GetMouseButton(0))
            //    {
                    
            //        mover.MoveTo(hit.point);
            //    }
            //}
        }
    }
}
