using UnityEngine;

namespace StateAnimation.StateBehavior
{
    public sealed class CharacterBehaviorIdile : CharacterBehavior
    {
        public CharacterBehaviorIdile(Animator anim) : base(anim) {}

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_MOVE, false);
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_JUMP, false);
        }

        public override void Exit()
        {
           // Debug.Log("Exit Idile State");
        }
    }
}