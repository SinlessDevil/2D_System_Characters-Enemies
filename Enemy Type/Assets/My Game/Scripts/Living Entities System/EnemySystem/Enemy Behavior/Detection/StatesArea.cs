using UnityEngine;

namespace EnemySystem.EnemyBehavior.Detection
{
    public class StatesArea : MonoBehaviour{
        private EnemyTriggerDetectionArea _detectionArea;
        private EnemyVisibillityArea _visibiliyArea;

        private BoxCollider2D _colliderDetectionArea;
        private BoxCollider2D _colliderVisibiliyArea;

        private PlayerSystem.Character _targetPos;
        private void Awake(){
            _detectionArea = GetComponentInChildren<EnemyTriggerDetectionArea>();
            _visibiliyArea = GetComponentInChildren<EnemyVisibillityArea>();

            _colliderDetectionArea = _detectionArea.GetComponent<BoxCollider2D>();
            _colliderVisibiliyArea = _visibiliyArea.GetComponent<BoxCollider2D>();
        }

        private void OnEnable(){
            _visibiliyArea.OnVisiblyChangeCharacterEvent += SetTargetPosition;

            _detectionArea.OnSwipeAreaEvent += SwipeArea;
            _visibiliyArea.OnSwipeAreaEvent += SwipeArea;
        }

        private void OnDisable(){
            _visibiliyArea.OnVisiblyChangeCharacterEvent -= SetTargetPosition;

            _detectionArea.OnSwipeAreaEvent -= SwipeArea;
            _visibiliyArea.OnSwipeAreaEvent -= SwipeArea;
        }

        public PlayerSystem.Character GetTargetPosition()
        {
            return _targetPos;
        }
        private void SetTargetPosition(PlayerSystem.Character target)
        {
            _targetPos = target;
        }

        private void SwipeArea(bool isSate){
            _colliderDetectionArea.enabled = isSate;
            _colliderVisibiliyArea.enabled = !isSate;
        }
    }
}