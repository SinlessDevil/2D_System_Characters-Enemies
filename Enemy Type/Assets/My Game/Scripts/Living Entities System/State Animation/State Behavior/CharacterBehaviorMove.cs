using UnityEngine;

namespace StateAnimation.StateBehavior
{
    public sealed class CharacterBehaviorMove : CharacterBehavior
    {
        public CharacterBehaviorMove(Animator anim) : base(anim) {}

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_MOVE, true);
        }

        public override void Exit()
        {
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_MOVE, false);
        }
    }
}