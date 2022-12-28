using UnityEngine;

namespace StateAnimation.StateBehavior
{
    public sealed class CharacterBehaviorJump : CharacterBehavior
    {
        public CharacterBehaviorJump(Animator anim) : base(anim) {}

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_JUMP, true);
        }

        public override void Exit()
        {
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_JUMP, false);
        }
    }
}