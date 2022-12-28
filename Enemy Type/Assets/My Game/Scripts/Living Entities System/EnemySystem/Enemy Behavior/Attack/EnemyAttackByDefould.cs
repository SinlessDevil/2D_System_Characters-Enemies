using UnityEngine;
using System.Collections;
using LiveSystem.HealthEntitySystem;

namespace EnemySystem.EnemyBehavior.Attack
{
    public class EnemyAttackByDefould : MonoBehaviour{

        [SerializeField] private int _damage = 1;
        [SerializeField] private float _waitTimeCoolDown = 3f;

        private HealthEntity _healthEntity;
        private AttackCollision _collison;

        private bool _isCoolDown = false;

        private void Awake()
        {
            _collison = GetComponentInChildren<AttackCollision>();

            if (_collison == null)
                throw new System.Exception($"There is no AttackCollision component on the object in Child: {gameObject.name}");
        }
        public void Attack()
        {
            if (!_isCoolDown && _collison.IsNearBy){
                _healthEntity.ApplyDamage(_damage);
                CoolDownToAttack();
            }
        }

        public bool IsCoolDown { get => _isCoolDown; private set => _isCoolDown = value; }
        private void CoolDownToAttack()
        {
            StartCoroutine(WaitTimeToCoolDownRoutine());
        }
        private IEnumerator WaitTimeToCoolDownRoutine(){
            IsCoolDown = true;
            yield return new WaitForSeconds(_waitTimeCoolDown);
            IsCoolDown = false;
        }
    }
}