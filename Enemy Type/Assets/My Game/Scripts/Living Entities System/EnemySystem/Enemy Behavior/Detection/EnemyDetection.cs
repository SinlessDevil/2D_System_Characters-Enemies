using System;
using UnityEngine;

namespace EnemySystem.EnemyBehavior.Detection
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class EnemyDetection : MonoBehaviour{
        public event Action<PlayerSystem.Character> OnVisiblyChangeCharacterEvent;

        public event Action<bool> OnSwipeAreaEvent;

        protected void SetReferenceTarget(PlayerSystem.Character character)
        {
            OnVisiblyChangeCharacterEvent?.Invoke(character);
        }

        protected void SetCurrentArea(bool _isState){
            OnSwipeAreaEvent?.Invoke(_isState);
        }
    }
}