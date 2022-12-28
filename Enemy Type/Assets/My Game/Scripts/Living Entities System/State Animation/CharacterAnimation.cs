using System;
using System.Collections.Generic;
using UnityEngine;
using StateAnimation.StateBehavior;

namespace StateAnimation
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private Dictionary<Type, ICharacterBehavior> _behaviorsMap;
        private ICharacterBehavior _behaviorCurrent;

        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            this.InitBehaviors();
            SetBehaviorByDefault();
        }

        private void InitBehaviors()
        {
            this._behaviorsMap = new Dictionary<Type, ICharacterBehavior>();

            this._behaviorsMap[typeof(CharacterBehaviorIdile)] = new CharacterBehaviorIdile(_anim);
            this._behaviorsMap[typeof(CharacterBehaviorMove)] = new CharacterBehaviorMove(_anim);
            this._behaviorsMap[typeof(CharacterBehaviorJump)] = new CharacterBehaviorJump(_anim);
            this._behaviorsMap[typeof(CharacterBehaviorAttack)] = new CharacterBehaviorAttack(_anim);
        }
        private void SetBehavior(ICharacterBehavior newBehavior){
            if(this._behaviorCurrent != null){
                this._behaviorCurrent.Exit();
            }

            this._behaviorCurrent = newBehavior;
            this._behaviorCurrent.Enter();
        }
        private void SetBehaviorByDefault(){
            SetBehaviorIdile();
        }

        private ICharacterBehavior GetBehavior<T>() where T : ICharacterBehavior{
            var type = typeof(T);
            return this._behaviorsMap[type];
        }

        //----------------------------------------------------------------------------------------------------------

        public void SetBehaviorIdile(){
            var _behaviorByDefault = this.GetBehavior<CharacterBehaviorIdile>();
            this.SetBehavior(_behaviorByDefault);
        }

        public void SetBehaviorMove(){
            var _behaviorByMove = this.GetBehavior<CharacterBehaviorMove>();
            this.SetBehavior(_behaviorByMove);
        }

        public void SetBehaviorJump(){
            var _behaviorByJump = this.GetBehavior<CharacterBehaviorJump>();
            this.SetBehavior(_behaviorByJump);
        }

        public void SetBehaviorAttack()
        {
            var _behaviorByAttack = this.GetBehavior<CharacterBehaviorAttack>();
            this.SetBehavior(_behaviorByAttack);
        }
    }
}