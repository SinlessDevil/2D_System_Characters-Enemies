using UnityEngine;
using EnemySystem.EnemyBehavior.Attack;
using EnemySystem.EnemyBehavior.Movemant;
using EnemySystem.EnemyBehavior.Detection;
using StateAnimation;

namespace EnemySystem.EnemyBehavior
{
    [RequireComponent(typeof(EnemyPatrol),typeof(EnemyAttackByDefould),typeof(CharacterAnimation))]
    public class EnemyBehaviorByDefould : MonoBehaviour
    {
        private PlayerSystem.Character _target;

        private EnemyPatrol _patrol;
        private EnemyAttackByDefould _attack;
        private StatesArea _area;

        private CharacterAnimation _animation;

        private void Start()
        {
            _patrol = GetComponent<EnemyPatrol>();
            _attack = GetComponent<EnemyAttackByDefould>();
            _animation = GetComponent<CharacterAnimation>();

            _area = GetComponentInChildren<StatesArea>();

            if (_area == null)
                throw new System.Exception($"There is no StatesArea component on the object in Child: {gameObject.name}");
        }

        private void FixedUpdate()
        {
            _target = _area.GetTargetPosition();

            if (_target == null){
                if (_patrol.IsWaitTo){
                    ReadAnimIdile();
                    return;
                }
                ReadPatroll();
                ReadAnimMove();
            }

            if (_target != null){
                //To see if I've reached my destination
                if (transform.position.x == _target.transform.position.x){
                    Debug.Log("Yes");
                    ReadAnimIdile();
                    //I'll check for availability ÑoolDown
                    if (!_attack.IsCoolDown){
                        ReadAnimAttack();
                        return;
                    }
                    return;
                }
                Debug.Log("I GO TO TARGET");
                //Move to Target
                ReadMoveTo();
                ReadAnimMove();
            }
        }

        #region Methods Read State Behavior Logic
        private void ReadPatroll()
        {
            _patrol.Patroling();
        }
        private void ReadMoveTo()
        {
            _patrol.MoveTo(_target.transform);
        }
        #endregion

        #region Methods Read State Animation Behavior
        private void ReadAnimMove()
        {
            _animation.SetBehaviorMove();
        }
        private void ReadAnimIdile()
        {
            _animation.SetBehaviorIdile();
        }
        private void ReadAnimAttack()
        {
            _animation.SetBehaviorAttack();
        }
        #endregion
    }
}