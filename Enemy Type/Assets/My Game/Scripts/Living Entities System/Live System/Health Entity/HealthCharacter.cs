using System;

namespace LiveSystem.HealthEntitySystem
{
    public sealed class HealthCharacter : HealthEntity
    {
        public event Action<int> OnHealthChangeEvent;
        public event Action<int> OnHealthChangeByDefouldEvent;
        public event Action OnGameOverEvent;

        protected override void Start()
        {
            base.Start();
            OnHealthChangeByDefouldEvent?.Invoke(_maxHealth);
        }

        public override void ApplyDamage(int damage)
        {
            base.ApplyDamage(damage);

            if (OnGameOverEvent != null)
                OnHealthChange(_health);
        }

        private void OnHealthChange(int value)
        {
            OnHealthChangeEvent?.Invoke(value);
        }

        public override void Dead()
        {
            OnGameOverEvent?.Invoke();
        }
    }
}