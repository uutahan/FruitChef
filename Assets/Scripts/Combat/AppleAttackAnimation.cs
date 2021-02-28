using UnityEngine;

namespace SwordShield.Combat
{
    public class AppleAttackAnimation : StateMachineBehaviour
    {
        public event Notify AppleAttackExit;
        public event Notify AppleAttackEnter;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AppleAttackEnter?.Invoke();
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AppleAttackExit?.Invoke();
        }

    }
}
