using SwordShield.Control;
using SwordShield.Core;
using SwordShield.Core.GameInputs;
using SwordShield.ICombat;

using UnityEngine;

namespace SwordShield.States.PlayerStates
{
    public class AttackingState : PlayerState
    {
        private IHealth health;
        private IFighter fighter;

        private bool _isAttacked = false;


        private bool _isCollide;
        public bool IsCollide
        {
            get { return _isCollide; }
            set {_isCollide = value; }
        }

        //public AttackingState(IPlayerTargetable target)
        //{
        //    this.initialTarget = target;
        //}

        public AttackingState()
        {
            _isAttacked = false;
        }

        public void Enter(PlayerController player)
        {
            health = player.GetComponent<IHealth>();
            fighter = player.GetComponent<IFighter>();
            fighter.FighterStart();
            _isAttacked = false;
        }

        public void Exit(PlayerController player)
        {
            fighter.Cancel();
        }

        public PlayerState HandleInput(GameInput input)
        {
            if (health.IsDead)
            {
                return new DeadState();
            }

            if(input == GameInput.MoveInput)
            {
                return new MovingState();
            }


            else if (input == GameInput.AttackInput)
            {
                _isAttacked = false;
            }


            //stay in this state
            return null;
        }

        public void UpdateLoop(PlayerController player)
        {
            if(_isAttacked == false)
            {
                fighter.FighterUpdate();
                _isAttacked = true;
            }
            
        }
    }
}
