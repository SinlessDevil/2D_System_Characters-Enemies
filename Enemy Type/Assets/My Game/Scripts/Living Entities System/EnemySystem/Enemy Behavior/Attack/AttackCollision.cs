using UnityEngine;
using LiveSystem.HealthEntitySystem;
using System;

namespace EnemySystem.EnemyBehavior.Attack
{
    public class AttackCollision : MonoBehaviour
    {
        public event Action<HealthEntity> OnReferenceToHealthEntityEvent;

        private bool _isNearBy = false;

        public bool IsNearBy { get => _isNearBy; private set => _isNearBy = value; }

        private void OnTriggerEnter2D(Collider2D collision){
            if(collision.gameObject.TryGetComponent(out HealthEntity healthEntity))
            {
                IsNearBy = true;
                OnReferenceToHealthEntityEvent?.Invoke(healthEntity);
            }
        }
        private void OnTriggerExit2D(Collider2D collision){
            if (collision.gameObject.TryGetComponent(out HealthEntity healthEntity))
            {
                IsNearBy = true;
                OnReferenceToHealthEntityEvent?.Invoke(null);
            }
        }
    }
}