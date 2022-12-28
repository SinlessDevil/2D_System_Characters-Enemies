using UnityEngine;

namespace StateAnimation.StateBehavior
{
    public class CharacterBehaviorAttack : CharacterBehavior
    {
        public CharacterBehaviorAttack(Animator anim) : base(anim) { }

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_ATTACK, true);
        }

        public override void Exit()
        {
            _anim.SetBool(DictionaryAnimState.NAME_ANIM_ATTACK, false);
        }
    }
}