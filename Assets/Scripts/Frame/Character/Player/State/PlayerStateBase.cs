using OpenWorld.Framework.StateMachine;
using UnityEngine;

namespace OpenWorld.Framework.Character.Player
{
    public class PlayerStateBase : StateBase
    {
        protected PlayerController player;

        public override void Init(IStateMachineOwner owner)
        {
            base.Init(owner);
            player= owner as PlayerController;
        }

        protected virtual bool CheckAnimatorStateName(string stateName, out float normalizedTime) 
        {
            // 动画处于过度阶段的考虑，需要优先判断下一个姿态
            AnimatorStateInfo nextInfo = player.Model.Animator.GetNextAnimatorStateInfo(0);
            if (nextInfo.IsName(stateName)) 
            {
                normalizedTime = nextInfo.normalizedTime;
                return true;
            }
            AnimatorStateInfo currentInfo = player.Model.Animator.GetCurrentAnimatorStateInfo(0);
            normalizedTime = currentInfo.normalizedTime;
            return currentInfo.IsName(stateName);
        }
    }
}