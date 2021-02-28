using UnityEngine;

namespace SwordShield.Combat
{
    public delegate void Notify();

    public class AttackAnimation : StateMachineBehaviour
    {
        public event Notify AttackExit;
        public event Notify AttackEnter;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AttackEnter?.Invoke();
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AttackExit?.Invoke();
        }

    }
}
