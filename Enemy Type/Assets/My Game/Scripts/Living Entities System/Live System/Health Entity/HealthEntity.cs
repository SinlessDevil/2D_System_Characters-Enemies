using UnityEngine;

namespace LiveSystem.HealthEntitySystem
{
    public abstract class HealthEntity : MonoBehaviour, IApplyDamage
    {
        [SerializeField] protected int _maxHealth = 10;
        protected int _health;

        protected virtual void Start()
        {
            SetHealthByDefould();
        }

        private void SetHealthByDefould()
        {
            _health = _maxHealth;
        }

        public virtual void ApplyDamage(int damage)
        {
            if(_health <= damage){
                _health = 0;
                Dead();
            }

            _health -= damage;
        }

        public abstract void Dead();
    }
}